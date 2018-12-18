﻿using System;
using EnsureThat;
using TodoAppLibrary.CryptoContext;
using TodoAppLibrary.Tools;
using TodoAppLibrary.UserContext.Exceptions;
using TodoAppLibrary.UserContext.Mapping;
using TodoAppLibrary.UserContext.Views;

namespace TodoAppLibrary.UserContext
{
    public class UserFacade : IUserFacade
    {
        public UserFacade(
            IUserRepository userRepository,
            ICryptoTool cryptoTool)
        {
            _userRepository = userRepository;
            _cryptoTool = cryptoTool;
        }

        public bool DoesUserExists(string email)
        {
            Ensure.String.IsNotEmptyOrWhitespace(email);

            return _userRepository.DoesUserExists(email);
        }

        public bool DoesUserExists(string email, string password)
        {
            Ensure.String.IsNotEmptyOrWhitespace(email);
            Ensure.String.IsNotEmptyOrWhitespace(password);

            if (!_userRepository.DoesUserExists(email))
                return false;

            var currentUser = _userRepository.GetUserByEmail(email);

            return _cryptoTool.DoesStringHashEqual(password, currentUser.Credentials.Password);
        }

        public void CreateNewUser(string username, string password, string email, DateTimeOffset dateOfBirth)
        {
            Ensure.String.IsNotEmptyOrWhitespace(username);
            Ensure.String.IsNotEmptyOrWhitespace(password);
            Ensure.String.IsNotEmptyOrWhitespace(email);
            Ensure.Any.IsNotDefault(dateOfBirth);

            Ensure.Bool.IsFalse(_userRepository.DoesUserExists(email), nameof(email),
                opt => opt.WithException(new UserAlreadyExistsException(email)));


            var passwordHash = _cryptoTool.GetHashWithSalt(password);

            var addingUser = new User(email, passwordHash, username, dateOfBirth);
            _userRepository.AddUser(addingUser);
        }

        public UserView GerUserInfo(Identifier userId)
        {
            Ensure.Any.IsNotNull(userId);

            var currentUser = _userRepository.GetUserById(userId);

            return currentUser.FromUserToView();
        }

        private readonly IUserRepository _userRepository;
        private readonly ICryptoTool _cryptoTool;
    }
}

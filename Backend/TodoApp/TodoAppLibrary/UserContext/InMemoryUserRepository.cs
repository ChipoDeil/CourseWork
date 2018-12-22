using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using EnsureThat;
using TodoAppLibrary.Tools;
using TodoAppLibrary.UserContext.Exceptions;

namespace TodoAppLibrary.UserContext
{
    public class InMemoryUserRepository : IUserRepository
    {
        public InMemoryUserRepository()
        {
            _users = new List<User>();
        }

        public bool DoesUserExists(string email)
        {
            return _users.Any(u => u.Credentials.Email == email);
        }

        public User GetUserByEmail(string email)
        {
            var currentUser = _users.FirstOrDefault(u => u.Credentials.Email == email);
            Ensure.Any.IsNotNull(currentUser, nameof(email),
                opt => opt.WithException(new UserNotFoundException(email)));

            return currentUser;
        }

        public User GetUserById(Identifier identifier)
        {
            var currentUser = _users.FirstOrDefault(u => u.UserInfo.Identifier.Id == identifier.Id);
            Ensure.Any.IsNotNull(currentUser, nameof(identifier),
                opt => opt.WithException(new UserNotFoundException(identifier)));
            return currentUser;
        }

        public Identifier AddUser(User user)
        {
            Ensure.Any.IsNotNull(user);
            var newId = new Identifier(IntIterator.GetNextInt());
            user.UserInfo.Identifier = newId;
            _users.Add(user);

            return newId;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        private readonly List<User> _users;
    }
}

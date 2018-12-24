using System;

namespace TodoAppLibrary.UserContext.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string email) : base($"user with email {email} already exists")
        {
        }
    }
}
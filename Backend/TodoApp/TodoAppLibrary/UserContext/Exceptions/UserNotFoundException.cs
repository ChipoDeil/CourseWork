using System;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.UserContext.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string email) : base($"User with email {email} not found")
        {
        }

        public UserNotFoundException(Identifier identifier) : base($"User with id {identifier.Id} not found")
        {
        }
    }
}

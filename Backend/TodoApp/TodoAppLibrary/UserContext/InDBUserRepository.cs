using System;
using System.Collections.Generic;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.UserContext
{
    public class InDBUserRepository : IUserRepository
    {
        public bool DoesUserExists(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(Identifier identifier)
        {
            throw new NotImplementedException();
        }

        public Identifier AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.UserContext
{
    public interface IUserRepository
    {
        bool DoesUserExists(string email);
        User GetUserByEmail(string email);
        User GetUserById(Identifier identifier);
        Identifier AddUser(User user);
        IEnumerable<User> GetAllUsers();
    }
}

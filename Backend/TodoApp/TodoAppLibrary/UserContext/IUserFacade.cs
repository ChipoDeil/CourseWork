using System;
using System.Collections.Generic;
using System.Text;
using TodoAppLibrary.Tools;
using TodoAppLibrary.UserContext.Views;

namespace TodoAppLibrary.UserContext
{
    public interface IUserFacade
    {
        bool DoesUserExists(string email);
        bool DoesUserExists(string email, string password);
        void CreateNewUser(string username, string password,
            string email, DateTimeOffset dateOfBirth);
        UserView GerUserInfo(Identifier userId);
        UserView GerUserInfoByEmail(string email);
        IEnumerable<UserView> GetUsersByUserName(string username);
    }
}

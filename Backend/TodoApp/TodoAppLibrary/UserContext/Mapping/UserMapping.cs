using System;
using System.Collections.Generic;
using System.Text;
using TodoAppLibrary.UserContext.Views;

namespace TodoAppLibrary.UserContext.Mapping
{
    public static class UserMapping
    {
        public static UserView FromUserToView(this User user)
        {
            return new UserView(user.UserInfo.Username,user.Credentials.Email, user.UserInfo.Photo, user.UserInfo.Identifier);
        }
    }
}

using System;
using EnsureThat;

namespace TodoAppLibrary.UserContext
{
    public class User
    {
        internal Credentials Credentials { get; set; }
        internal UserInfo UserInfo { get; set; }

        public User(string email, string password, string userName, DateTimeOffset dateOfBirth)
        {
            Ensure.String.IsNotEmptyOrWhitespace(email);
            Ensure.String.IsNotEmptyOrWhitespace(password);
            Ensure.String.IsNotEmptyOrWhitespace(userName);
            Ensure.Any.IsNotDefault(dateOfBirth);

            Credentials = new Credentials(email, password);
            UserInfo = new UserInfo(userName, dateOfBirth);
        }

        internal User(Credentials credentials, UserInfo userInfo)
        {
            Credentials = Ensure.Any.IsNotNull(credentials);
            UserInfo = Ensure.Any.IsNotNull(userInfo);
        }

        internal void AddPhoto(string fileName)
        {
            Ensure.String.IsNotEmptyOrWhitespace(fileName);
            UserInfo.Photo = fileName;
        }
    }
}

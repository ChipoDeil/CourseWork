using System;
using TodoAppLibrary.Tools;

namespace TodoAppLibrary.UserContext
{
    public class UserInfo
    {
        public UserInfo(string username, DateTimeOffset dateOfBirth)
        {
            Identifier = new Identifier();
            Username = username;
            DateOfBirth = dateOfBirth;
        }

        public Identifier Identifier { get; internal set; }
        public string Username { get; internal set; }
        public DateTimeOffset DateOfBirth { get; internal set; }
        public string Photo { get; internal set; }
    }
}
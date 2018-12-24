using TodoAppLibrary.Tools;

namespace TodoAppLibrary.UserContext.Views
{
    public class UserView
    {
        public UserView(
            string username,
            string email,
            string photo,
            Identifier identifier)
        {
            Username = username;
            Email = email;
            Photo = photo;
            Identifier = identifier;
        }

        public string Username { get; }
        public string Email { get; }
        public string Photo { get; }
        public Identifier Identifier { get; }
    }
}
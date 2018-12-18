using TodoAppLibrary.Tools;

namespace TodoAppLibrary.UserContext.Views
{
    public class UserView
    {
        public string Username { get; }
        public string Email { get; }
        public string Photo { get; }
        public Identifier Identifier { get; }

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
    }
}

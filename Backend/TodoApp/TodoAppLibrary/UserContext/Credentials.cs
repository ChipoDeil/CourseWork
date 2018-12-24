namespace TodoAppLibrary.UserContext
{
    public class Credentials
    {
        public Credentials(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; internal set; }
        public string Password { get; internal set; }
    }
}
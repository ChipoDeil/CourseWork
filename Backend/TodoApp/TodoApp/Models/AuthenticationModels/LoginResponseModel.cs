namespace TodoApp.Models.AuthenticationModels
{
    public class LoginResponseModel
    {
        public LoginResponseModel(
            string token,
            string username)
        {
            Token = token;
            Username = username;
        }

        /// <summary>
        ///     Токен пользователя
        /// </summary>
        public string Token { get; }

        /// <summary>
        ///     Username пользователя
        /// </summary>
        public string Username { get; }
    }
}
namespace TodoApp.Security
{
    public class Claims
    {
        public const string IdClaim = "UserId";

        public static class Roles
        {
            public const string RoleClaim = "Role";
            public const string User = "User";
        }
    }
}

namespace TodoApp.Security
{
    public interface IJwtIssuer
    {
        string IssueJwt(string role, int id);
    }
}

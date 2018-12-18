namespace TodoAppLibrary.CryptoContext
{
    public interface ICryptoTool
    {
        string GetHashWithSalt(string password);
        bool DoesStringHashEqual(string password, string passwordHash);
    }
}

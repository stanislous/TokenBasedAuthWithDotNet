namespace TokenBasedAuthWithDotNet;

public interface IJwtTokenManager
{
    string Authenticate(string userName, string password);

}
namespace RW7.DotNetSecurityTools.ClientCredentials
{
    public interface IClientSecretGenerator
    {
        string Generate(int length);
    }
}

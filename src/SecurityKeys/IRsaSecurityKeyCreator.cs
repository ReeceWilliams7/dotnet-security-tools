using Microsoft.IdentityModel.Tokens;

namespace RW7.DotNetSecurityTools.SecurityKeys
{
    public interface IRsaSecurityKeyCreator
    {
        RsaSecurityKey Create();
    }
}
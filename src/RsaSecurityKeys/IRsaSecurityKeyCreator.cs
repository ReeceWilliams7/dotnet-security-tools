using Microsoft.IdentityModel.Tokens;

namespace RW7.DotNetSecurityTools.RsaSecurityKeys
{
    public interface IRsaSecurityKeyCreator
    {
        RsaSecurityKey Create();
    }
}
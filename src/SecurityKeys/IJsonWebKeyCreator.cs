using RW7.DotNetSecurityTools.SecurityKeys.Models;

namespace RW7.DotNetSecurityTools.SecurityKeys
{
    public interface IJsonWebKeyCreator
    {
        JsonWebKeyOutput Create();
    }
}

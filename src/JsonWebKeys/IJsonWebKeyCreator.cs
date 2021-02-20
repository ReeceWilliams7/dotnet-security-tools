using RW7.DotNetSecurityTools.JsonWebKeys.Models;

namespace RW7.DotNetSecurityTools.JsonWebKeys
{
    public interface IJsonWebKeyCreator
    {
        JsonWebKeyOutput Create();
    }
}

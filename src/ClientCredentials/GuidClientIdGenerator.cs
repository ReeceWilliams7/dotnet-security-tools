using System;

namespace RW7.DotNetSecurityTools.ClientCredentials
{
    public class GuidClientIdGenerator : IClientIdGenerator
    {
        public string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

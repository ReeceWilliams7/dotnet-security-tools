using System.Security.Cryptography;

using RW7.DotNetSecurityTools.Core;

namespace RW7.DotNetSecurityTools.SecurityKeys.Extensions
{
    internal static class RSAExtensions
    {
        internal static string ExportPemEncodedPublicKey(this RSA rsa)
        {
            var keyBytes = rsa.ExportRSAPublicKey();
            var pemChars = PemEncoding.Write(PemEncodingLabels.RsaPublicKey, keyBytes);
            return new string(pemChars);
        }

        internal static string ExportPemEncodedPrivateKey(this RSA rsa)
        {
            var keyBytes = rsa.ExportRSAPrivateKey();
            var pemChars = PemEncoding.Write(PemEncodingLabels.RsaPrivateKey, keyBytes);
            return new string(pemChars);
        }
    }
}
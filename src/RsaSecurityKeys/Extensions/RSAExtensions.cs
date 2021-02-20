using System.Security.Cryptography;

using RW7.DotNetSecurityTools.Pem;

namespace RW7.DotNetSecurityTools.RsaSecurityKeys.Extensions
{
    public static class RSAExtensions
    {
        public static string ExportPemEncodedPublicKey(this RSA rsa)
        {
            var keyBytes = rsa.ExportRSAPublicKey();
            var pemChars = PemEncoding.Write(PemEncodingLabels.RsaPublicKey, keyBytes);
            return new string(pemChars);
        }

        public static string ExportPemEncodedPrivateKey(this RSA rsa)
        {
            var keyBytes = rsa.ExportRSAPrivateKey();
            var pemChars = PemEncoding.Write(PemEncodingLabels.RsaPrivateKey, keyBytes);
            return new string(pemChars);
        }
    }
}
using System;

namespace SecurityKeyCreator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = RW7.DotNetSecurityTools.SecurityKeys.SecurityKeyCreator.CreateSecurityKey();

            Console.WriteLine("Full JsonWebKey:");
            Console.WriteLine();
            Console.WriteLine(output.JsonWebKeyString);
            Console.WriteLine();

            Console.WriteLine("RSA Private Key");
            Console.WriteLine();
            Console.WriteLine(output.RsaPrivateKeyString);
            Console.WriteLine();

            Console.WriteLine("RSA Public Key");
            Console.WriteLine();
            Console.WriteLine(output.RsaPublicKeyString);
            Console.WriteLine();

            Console.Read();
        }
    }
}

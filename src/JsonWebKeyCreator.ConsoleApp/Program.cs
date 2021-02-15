using System;

namespace SecurityKeyCreator.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var output = RW7.DotNetSecurityTools.SecurityKeys.JsonWebKeyCreator.CreateSecurityKey();

            WriteSection("JsonWebKey", output.JsonWebKey);

            WriteSectionDivider();

            WriteSection("Base64 Encoded JsonWebKey", output.Base64JsonWebKey);

            WriteSectionDivider();

            WriteSection("RSA Private Key", output.RsaPrivateKey);

            WriteSectionDivider();

            WriteSection("RSA Public Key", output.RsaPublicKey);

            Console.Read();
        }

        private static void WriteSection(string sectionTitle, string sectionValue)
        {
            WriteSectionBorder();
            Console.WriteLine($"{sectionTitle}:");
            Console.WriteLine();
            Console.WriteLine(sectionValue);
            Console.WriteLine();
            WriteSectionBorder();
        }

        private static void WriteSectionBorder()
        {
            Console.WriteLine("******************************************");
        }

        private static void WriteSectionDivider()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
        }
    }
}

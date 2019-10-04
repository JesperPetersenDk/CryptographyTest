using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var text1 = hashPassword("Hello world - Jesper vi tester lige password", true);
            Console.WriteLine(text1);

            var text2 = hashPassword("Hello world - Jesper vi tester lige password", false);
            Console.WriteLine(text2);

        }

        private static string hashPassword(string text, bool replace)
        {
            string plainText = text;
            SHA512 hashSVC = SHA512.Create();

            //Returnes 512 bits (8 bits /byte, 64 bytes) for hash.
            byte[] hash = hashSVC.ComputeHash(Encoding.UTF8.GetBytes(plainText));

            var hashValue = BitConverter.ToString(hash);

            return (replace) ? hashValue.Replace("-", "") : hashValue;
        }
    }
}

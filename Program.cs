using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringText = "Hello world - Jesper vi tester lige password";

            var text1 = hashPassword(stringText, true);
            Console.WriteLine("Text 1: " + text1);

            var text2 = hashPassword(stringText, false);
            Console.WriteLine("Text 2: " + text2);

            Random r = new Random();
            var rText = r.Next(5, 200).ToString();
            var text3 = hashPassword(rText + stringText, true);
            Console.WriteLine("Text 3: " + rText + " - " + text3);

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

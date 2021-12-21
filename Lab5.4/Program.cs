using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Lab5_4
{
    public class PBKDF2
    {
        public static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[32];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public static byte[] HashPassword(byte[] toBeHashed, byte[] salt, int numberOfRounds, System.Security.Cryptography.HashAlgorithmName hashAlgorithm)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, hashAlgorithm))
            {
                return rfc2898.GetBytes(20);
            }
        }


    }
    class Program
    {
        public static void HashPassword(string passwordToHash, int numberOfRounds)
        {
            var sw = new Stopwatch();
            sw.Start();
            var hashedPassword = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(passwordToHash), PBKDF2.GenerateSalt(), numberOfRounds, HashAlgorithmName.SHA512);
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Password to hash : " + passwordToHash);
            Console.WriteLine("Hashed Password : " + Convert.ToBase64String(hashedPassword));
            Console.WriteLine("Iterations <" + numberOfRounds + "> Elapsed Time: " + sw.ElapsedMilliseconds + "ms");
        }

        static void Main(string[] args)
        {
            const string passwordToHash = "this-is-some-password";
            HashPassword(passwordToHash, 70000);
            HashPassword(passwordToHash, 120000);
            HashPassword(passwordToHash, 170000);
            HashPassword(passwordToHash, 220000);
            HashPassword(passwordToHash, 270000);
            HashPassword(passwordToHash, 320000);
            HashPassword(passwordToHash, 370000);
            HashPassword(passwordToHash, 420000);
            HashPassword(passwordToHash, 470000);
            HashPassword(passwordToHash, 520000);

            Console.ReadKey();
        }
    } 
}

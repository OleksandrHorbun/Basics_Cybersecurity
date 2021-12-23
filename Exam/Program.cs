using System;
using System.Security.Cryptography;
using System.Text;

//Oleksandr Horbun, variant 15, Exam exercise 18

namespace Exam
{
    public class PBKDF2
    {
        const int hash_bytes = 32;
        public static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[32];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public static byte[] HashPasswordSHA256(byte[] password, byte[] salt, int numberOfRounds, System.Security.Cryptography.HashAlgorithmName hashAlgorithm)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, numberOfRounds, hashAlgorithm))
            {
                return rfc2898.GetBytes(hash_bytes);
            }
        }

        public static byte[] HashPasswordSHA512(byte[] password, byte[] salt, int numberOfRounds, System.Security.Cryptography.HashAlgorithmName hashAlgorithm)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, numberOfRounds, hashAlgorithm))
            {
                return rfc2898.GetBytes(hash_bytes);
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberIterations = 18000;
            Console.WriteLine("Enter some password");
            string password = Console.ReadLine();
            Console.WriteLine();

            var hashedPasswordSHA256 = PBKDF2.HashPasswordSHA256(Encoding.UTF8.GetBytes(password), PBKDF2.GenerateSalt(), numberIterations, HashAlgorithmName.SHA256);
            var hashedPasswordSHA512 = PBKDF2.HashPasswordSHA512(Encoding.UTF8.GetBytes(password), PBKDF2.GenerateSalt(), numberIterations, HashAlgorithmName.SHA512);
            

            Console.WriteLine("Password to hash : " + password);
            Console.WriteLine();
            Console.WriteLine("Hashed Password via SHA256: " + Convert.ToBase64String(hashedPasswordSHA256));
            Console.WriteLine("Hashed Password via SHA512: " + Convert.ToBase64String(hashedPasswordSHA512));

            Console.ReadKey();
        }
    }
}
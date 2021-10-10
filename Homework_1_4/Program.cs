//made by Oleksandr_Horbun
using System;
using System.Security.Cryptography;

namespace Homework_1_4
{
    class Program
    {
        public static string RandomNumber(int bytes) //Generate cryptographic random numbers
        {
            using (var rndNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[bytes];
                //Console.WriteLine(Convert.ToBase64String(randomNumber));
                rndNumberGenerator.GetBytes(randomNumber); //Initalize random generation
                //Console.WriteLine(Convert.ToBase64String(randomNumber));
                return Convert.ToBase64String(randomNumber);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Please, enter amount of cryptographic random numbers ---> ");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please, enter amount of bytes ---> ");
            int bytes = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine(i + 1 + ". Random number = " + RandomNumber(bytes));
            } //Cycle

            Console.ReadKey();
        }
    }
}

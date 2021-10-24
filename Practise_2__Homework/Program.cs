//made by Oleksandr_Horbun
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Homework_2__1
{
    class Program
    {
        //GET
        public static byte[] Get_from_file(string source)
        {
            byte[] data = File.ReadAllBytes(source).ToArray();
            return data;
        }

        //Print
        public static void Print_bytes(byte[] data) 
        {
            foreach (byte i in data)
            {
                Console.WriteLine(i + "\n");
            }
            Console.WriteLine();
        }

        //Generate a key
        public static byte[] Gen_random_key(byte[] data)
        {
            var generator = new RNGCryptoServiceProvider();
            byte[] random_key = new byte[data.Length];
            generator.GetBytes(random_key);
            return random_key;
        }

        //Encrypt message
        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            byte[] encryptedData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                encryptedData[i] = (byte)(data[i] ^ key[i]);
            }
            return encryptedData;
        }

        //Write into file.dat
        public static void Write_into_file (byte[] encryptedData)
        {
            File.WriteAllBytes("../../../ffile.dat", encryptedData);
        }

        //Decrypt with a key
        public static byte[] Decrypt (byte[] data, byte[] key)
        {
            byte[] decryptedData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                decryptedData[i] = (byte)(data[i] ^ key[i]);
            }
            return decryptedData;
        }

        //MAIN
        static void Main(string[] args)
        {
            //Exercise 2.1

            /*string source;
            //Console.WriteLine("Enter a path to the file");
            Console.ReadLine(string);*/
            string source = "../../../ffile.txt";
            byte[] data = Get_from_file(source);
            Console.WriteLine("Data (string) = " + Encoding.ASCII.GetString(data) + "\n");
            Print_bytes(data);
            
            byte[] key = Gen_random_key(data);
            byte[] encryptedData = Encrypt(data, key);
            Console.WriteLine("Encrypted (string) = " + Encoding.ASCII.GetString(encryptedData) + "\n");
            Print_bytes(encryptedData);
            Write_into_file(encryptedData);

            //Exercise 2.2
            byte[] decryptedData = Decrypt(encryptedData, key);
            Console.WriteLine("Decrypted (string) = " + Encoding.ASCII.GetString(decryptedData));
            
            Console.ReadKey();
        }
    }
}

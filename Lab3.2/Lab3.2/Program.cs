using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Lab3_2
{
    
    class Program
    {
        public static byte[] ComputeHashMd5(byte[] dataForHash)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(dataForHash);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hash MD5: po1MVkAE7IjUUwu61XxgNg==");
            Console.WriteLine("GUID: {564c8da6-0440-88ec-d453-0bbad57c6036}");
            List<char> Test = new List<char>();
            for (char i = '0'; i <= '9'; i++) { Test.Add(i); }

            Console.WriteLine("\nBruteforce started. Just wait.\n");
            foreach (char a in Test)
                foreach (char b in Test)
                    foreach (char c in Test)
                        foreach (char d in Test)
                            foreach (char e in Test)
                                foreach (char f in Test)
                                    foreach (char g in Test)
                                        foreach (char h in Test)
                                        {
                                            string password = new string(new[] { a, b, c, d, e, f, g, h });
                                            var md5ForStr = ComputeHashMd5(Encoding.Unicode.GetBytes(password));
                                            if (Convert.ToBase64String(md5ForStr) == "po1MVkAE7IjUUwu61XxgNg==")
                                            {
                                                Console.WriteLine($"Password find: {password}");
                                                Console.ReadKey();
                                                return;
                                            }
                                        }
        }
    }
}

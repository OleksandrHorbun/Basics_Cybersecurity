//made by Oleksandr_Horbun
using System;

namespace Homework_1_3
{
    class Program
    {
        public static int Pseudo_randomNumber(Random rand) //Return NEXT pseudo-random number
        {
            return rand.Next(0, 10);
        }

        static void Main(string[] args)
        {
            Console.Write("Please, enter a number for random pseudo-generation ---> ");
            int ran = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random(ran); //Initalize pseudo-random
            Console.Write("Please, enter amount of numbers ---> ");
            int amount = Convert.ToInt32(Console.ReadLine()); 

            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine(i + 1 + ". Random number = " + Pseudo_randomNumber(rand));
            } //Cycle

            Console.ReadKey();
        }
    }
}
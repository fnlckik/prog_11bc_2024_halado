using System;

namespace Erme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 50;
            Random r = new Random();

            Console.WriteLine("a) Érme dobása 50-szer:");
            for (int i = 0; i < n; i++)
            {
                // int erme = r.Next(1, 3); // 1, 2
                int erme = r.Next(2); // 0 => fej, 1 => iras
                if (erme == 0)
                {
                    Console.Write("F ");
                }
                else
                {
                    Console.Write("I ");
                }
            }

            Console.ReadKey();
        }
    }
}

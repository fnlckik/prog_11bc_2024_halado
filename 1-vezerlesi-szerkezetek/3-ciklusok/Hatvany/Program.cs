using System;

namespace Hatvany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Alap: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Kitevő: ");
            int k = Convert.ToInt32(Console.ReadLine());

            double er = 1;
            for (int i = 0; i < k; i++)
            {
                er *= a; // er = er * a;
            }

            Console.WriteLine($"Hatvány: {er}");

            Console.ReadKey();
        }
    }
}

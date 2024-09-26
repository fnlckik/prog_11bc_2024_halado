using System;

namespace Osztok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Deklaráció (hely foglalás a memóriában)
            int n;
            do
            {
                Console.Write("n: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n <= 0);

            // a) Osztók: 12 => 1 2 3 4 6 12
            Console.WriteLine("Osztói: ");
            for (int i = 1; i <= n/2; i++)
            {
                if (n % i == 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine(n);

            Console.ReadKey();
        }
    }
}

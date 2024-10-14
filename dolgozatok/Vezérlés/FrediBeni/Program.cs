using System;

namespace FrediBeni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int f = 8, b = 8;
            do
            {
                int r1 = r.Next(2);
                int r2 = r.Next(2);
                char erme1 = r1 == 0 ? 'F' : 'I';
                char erme2 = r2 == 0 ? 'F' : 'I';
                if (erme1 == 'F' || erme2 == 'F')
                {
                    f--; b++;
                }
                else
                {
                    b--; f++;
                }
                Console.WriteLine($"{erme1} {erme2} {f} {b}");
            } while (f > 0 && b > 0);

            if (f > 0) Console.WriteLine("Frédi nyert!");
            else Console.WriteLine("Béni nyert!");

            Console.ReadKey();
        }
    }
}

using System;

namespace Fuggvenyek
{
    internal class Program
    {
        static double Kerulet(double a, double b)
        {
            return 2 * (a + b);
        }

        /*
            if (a % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            } 
        */
        static bool ParosE(int a)
        {
            return a % 2 == 0;
        }

        static int Max(int[] t)
        {
            int maxe = t[0];
            for (int i = 1; i < t.Length; i++)
            {
                if (maxe < t[i])
                {
                    maxe = t[i];
                }
            }
            return maxe;
        }

        static void Main(string[] args)
        {
            // C#: PascalCase (WriteLine)
            // JS: camalCase (addEventListener)
            // python: snake_case 
            // CSS: kebab-case, hyphen-case (background-color)
            // 1. Kerület
            Console.WriteLine(Kerulet(3, 5));
            Console.WriteLine(Kerulet(1.25, 4));
            Console.WriteLine(Kerulet(10, 50));

            // 2. Páros-e?
            Console.WriteLine("-------");
            Console.WriteLine(ParosE(5));
            Console.WriteLine(ParosE(162));

            // 3. Maximum érték
            Console.WriteLine("-------");
            Console.WriteLine(Max(new int[] { 4, 7, -3, 12, 7, 14, -1 }));
        }
    }
}

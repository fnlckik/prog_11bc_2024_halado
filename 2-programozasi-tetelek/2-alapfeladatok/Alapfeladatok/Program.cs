using System;

namespace Alapfeladatok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] x = { 5, 7, 2, 2, 9, -1, 4, -3, 9, 3, 2, 1 };

            // F4 - Eldöntés
            int i = 0;
            while (i < x.Length && !(x[i] < 0))
            {
                i++;
            }
            if (i < x.Length) // Benne vagyok még a tömbben.
            {
                Console.WriteLine("4. Van negatív elem!");
            }
            else
            {
                Console.WriteLine("4. Nincs negatív elem!");
            }

            // F5 - Kiválasztás
            /*
            i = 0;
            bool megvan = x[0] == 9;
            while (!megvan)
            {
                i++;
                megvan = x[i] == 9;
            }
            */
            i = 0;
            while (!(x[i] == 9))
            {
                i++;
            }
            Console.WriteLine($"5. Az első 9-es helye: {i+1}");

            // F6 - Keresés = Eldöntés + Kiválasztás
            // x[i] % 2 != 0
            // x[i] % 2 == 1
            i = 0;
            while (i < x.Length && !(x[i] % 2 == 0))
            {
                i++;
            }
            if (i < x.Length)
            {
                Console.WriteLine($"6. Van páros: {i+1}. elem, értéke: {x[i]}");
            }
            else
            {
                Console.WriteLine("6. Nincs páros!");
            }

            Console.ReadKey();
        }
    }
}

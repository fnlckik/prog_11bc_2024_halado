using System;

namespace Telefon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Konstans: fordítási időben tudnunk kell az értékét
            // (és az nem változhat a program futása során)
            const int n = 12;
            // a) For ciklussal
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i+1}. Nem mobilozok órán!");
            }

            Console.WriteLine();

            // b) While ciklussal
            int j = 0;
            while (j < n)
            {
                Console.WriteLine($"{j + 1}. Nem mobilozok órán!");
                j++;
            }

            Console.ReadKey();
        }
    }
}

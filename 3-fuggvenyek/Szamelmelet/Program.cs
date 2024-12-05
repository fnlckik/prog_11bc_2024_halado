using System;

namespace Szamelmelet
{
    internal class Program
    {
        static bool PrimE(int p)
        {
            if (p < 2)
            {
                return false;
            }
            int i = 2;
            while (i < Math.Sqrt(p) && p % i != 0)
            {
                i++;
            }
            return p % i != 0; // Prím: kiléptünk, mert nincs osztó
        }

        static void Main(string[] args)
        {
            Console.WriteLine(PrimE(17)); // true
            Console.WriteLine(PrimE(24)); // false
            Console.WriteLine(PrimE(9)); // false 
            Console.WriteLine(PrimE(1));
        }
    }
}

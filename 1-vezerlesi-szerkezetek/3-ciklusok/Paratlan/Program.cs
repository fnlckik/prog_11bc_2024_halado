using System;

namespace Paratlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            const int n = 7;

            string szam = "";
            for (int i = 0; i < n; i++)
            {
                int szamjegy = r.Next(10); // 0, 1, 2, ... 9
                if (szamjegy % 2 == 0)
                {
                    szamjegy++;
                }
                szam += szamjegy; // "1773" + 7
                // Console.Write(szamjegy);
            }

            Console.Write($"A generált szám: {szam}");

            Console.ReadKey();
        }
    }
}

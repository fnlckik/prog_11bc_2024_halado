using System;
using System.Linq;

namespace Jogositvany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Elnevezési konvenciók
            // PascalCase - C# (ReadLine)
            // camelCase - JS (addEventListener)
            int n = Convert.ToInt32(Console.ReadLine());

            // Statikus tömbök
            // - tömbök méretei fixek
            // - fordítási időben tudni kell a méretüket (!!!)
            string[] nevek = new string[100];
            int[] korok = new int[100];
            bool[] jogsik = new bool[100];

            // if-else
            /*
            if (adatok[2] == "I") jogsik[i] = true;
            else jogsik[i] = false;
            */
            // ternary
            // jogsik[i] = adatok[2] == "I" ? true : false;
            int i;
            for (i = 0; i < n; i++)
            {
                string sor = Console.ReadLine(); // "Daniel 30 I"
                string[] adatok = sor.Split(' '); // { "Daniel", "30", "I" }
                nevek[i] = adatok[0]; // { "Daniel", "Marta", ..., "Henrik", "", "", ... }
                korok[i] = Convert.ToInt32(adatok[1]); // int.Parse()
                jogsik[i] = adatok[2] == "I";
            }

            // F2 - Megszámolás
            int db = 0;
            for (i = 0; i < n; i++)
            {
                if (jogsik[i])
                {
                    db++;
                }
            }
            double szazalek = (double) db / n * 100;
            Console.WriteLine($"2. {szazalek}%");

            // F3 - Keresés -> while


            //Console.ReadKey();
        }
    }
}

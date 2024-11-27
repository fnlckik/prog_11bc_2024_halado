using System;

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
            Console.WriteLine($"2. {szazalek:0.}%");

            // F3 - Keresés -> while
            // !(korok[i] > 30 && !jogsik[i])
            // korok[i] <= 30 || jogsik[i]
            // NEM(A és B) = NEM(A) VAGY NEM(B) -> de Morgan azonosság
            i = 0;
            while (i < n && !(korok[i] > 30 && !jogsik[i]))
            {
                i++;
            }
            if (i < n)
            {
                Console.WriteLine($"3. {nevek[i]}");
            }
            else
            {
                Console.WriteLine("3. Nincs ilyen!");
            }

            // F4 - Minimax
            int mine = korok[0];
            int maxe = korok[0];
            for (i = 0; i < n; i++)
            {
                if (korok[i] < mine)
                {
                    mine = korok[i];
                }
                if (korok[i] > maxe)
                {
                    maxe = korok[i];
                }
            }
            Console.WriteLine($"4. {maxe - mine}");

            // F5 - Megszámolás
            int dbA = 0;
            int dbB = 0;
            for (i = 0; i < n; i++)
            {
                if (korok[i] >= 20 && jogsik[i])
                {
                    dbA++;
                }
                else if (jogsik[i])
                {
                    dbB++;
                }
            }
            if (dbA > dbB)
            {
                Console.WriteLine("5. A legalább 20 évesek közül többen rendelkeznek jogsival, mint a 20 év alattiak.");
            }
            else // dbA <= dbB
            {
                Console.WriteLine("5. A 20 év alattiak közül legalább annyian rendelkeznek jogsival, mint a legalább 20 évesek.");
            }

            // F6 - Keresés
            i = 0;
            while (i < n && !(nevek[i][0] == 'F'))
            {
                i++;
            }
            if (i < n)
            {
                Console.WriteLine($"6. {nevek[i]}");
            }
            else
            {
                Console.WriteLine("6. Nincs \"F\" betűvel kezdődő!");
            }

            // F7 - Összegzés
            int osszeg = 0;
            for (i = n-1; i > n-11; i--)
            {
                osszeg += korok[i];
            }
            double atlag = (double)osszeg / 10;
            Console.WriteLine($"7. {atlag}");

            // F7 - MO2
            // korok[n-1]: utolsó elem (hátulról az 1.)
            // korok[n-2]: utolsó előtti (hátulról a 2.)
            // ...
            // korok[n-10]: (hárulról a 10.)
            osszeg = 0;
            for (i = 1; i <= 10; i++)
            {
                osszeg += korok[n-i];
            }
            Console.WriteLine($"7. {(double)osszeg / 10}");

            //Console.ReadKey();
        }
    }
}

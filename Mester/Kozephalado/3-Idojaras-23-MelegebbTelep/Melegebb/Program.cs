using System;

namespace Melegebb
{
    internal class Program
    {
        static void Beolvas(int[,] h, out int n, out int m)
        {
            string[] elsosor = Console.ReadLine().Split(' ');
            n = Convert.ToInt32(elsosor[0]);
            m = Convert.ToInt32(elsosor[1]);
            for (int i = 0; i < n; i++)
            {
                string[] sor = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    h[i, j] = Convert.ToInt32(sor[j]);
                }
            }
        }

        // Melegebb-e az x. település az y. településnél?
        static bool MelegebbE(int[,] h, int m, int x, int y)
        {
            bool melegebb = true;
            int i = 0; // i. nap
            while (i < m && melegebb)
            {
                melegebb = h[x, i] > h[y, i];
                i++;
            }
            return melegebb;
        }

        static int Keres(int[,] h, int n, int m)
        {
            int i = 0; // A keresett település indexe!
            bool megvanE = false; // Megvan-e már a keresett település?
            while (i < n && !megvanE)
            {
                int j = 0; // Másik település indexe!
                while (j < n && !megvanE)
                {
                    megvanE = MelegebbE(h, m, i, j); // Melegebb-e az i. a j. településnél?
                    j++;
                }
                i++;
            }
            return megvanE ? i : -1;
        }

        static void Main(string[] args)
        {
            int[,] h = new int[1000, 1000];
            Beolvas(h, out int n, out int m);
            // n: települések (sorok) száma
            // m: napok (oszlopok) száma

            //Console.WriteLine(MelegebbE(h, m, 0, 1)); // false
            //Console.WriteLine(MelegebbE(h, m, 2, 0)); // true
            //Console.WriteLine(MelegebbE(h, m, 2, 1)); // false

            int telepules = Keres(h, n, m);
            Console.WriteLine(telepules);
        }
    }
}

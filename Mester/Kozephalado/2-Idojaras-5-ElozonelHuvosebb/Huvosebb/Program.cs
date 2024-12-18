using System;

namespace Huvosebb
{
    internal class Program
    {
        static void SorOlvas(int[,] h, int i, int m)
        {
            string[] sor = Console.ReadLine().Split(' ');
            for (int j = 0; j < m; j++)
            {
                h[i, j] = Convert.ToInt32(sor[j]);
            }
        }

        static void Beolvas(int[,] h, out int n, out int m)
        {
            string[] elsosor = Console.ReadLine().Split(' ');
            n = Convert.ToInt32(elsosor[0]);
            m = Convert.ToInt32(elsosor[1]);
            for (int i = 0; i < n; i++)
            {
                SorOlvas(h, i, m);
            }
        }

        static bool HuvosE(int[,] h, int i, int n)
        {
            int j = 0; // telepules
            while (j < n && !(h[j, i] < h[j, i-1]))
            {
                j++;
            }
            return j < n;
        }

        static void Kivalogat(int[,] h, int n, int m, int[] huvosnapok, out int db)
        {
            db = 0;
            for (int i = 1; i < m; i++) // oszlop: nap
            {
                if (HuvosE(h, i, n))
                {
                    huvosnapok[db] = i + 1;
                    db++;
                }
            }
        }

        static void Kiir(int[] x, int n)
        {
            Console.Write(n + " ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(x[i] + " ");
            }
        }

        static void Main(string[] args)
        {
            int[,] h = new int[1000, 1000];
            Beolvas(h, out int n, out int m);

            int[] huvosnapok = new int[1000];
            Kivalogat(h, n, m, huvosnapok, out int db);

            Kiir(huvosnapok, db);
        }
    }
}

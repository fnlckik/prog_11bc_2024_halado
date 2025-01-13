using System;

namespace Halak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] h = new int[70, 20];
            Beolvas(h, out int n, out int m);
            Feladat2(h, n, m);
            Feladat3(h, n, m);
        }

        static void Feladat3(int[,] h, int n, int m)
        {
            Console.Write("3. feladat: ");
            for (int i = 0; i < n; i++) // i. sor
            {
                int j = 0;
                while (j < m && !(h[i, j] == 0))
                {
                    j++;
                }
                if (j < m)
                {
                    Console.Write(i + 1 + " ");
                }
            }
            Console.WriteLine();
        }

        static void Feladat2(int[,] h, int n, int m)
        {
            Console.Write("2. feladat: ");
            for (int i = 0; i < m; i++) // i. oszlop
            {
                int s = 0;
                for (int j = 0; j < n; j++) // j. sor
                {
                    s += h[j, i];
                }
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }

        static void Beolvas(int[,] h, out int n, out int m)
        {
            string[] sor = Console.ReadLine().Split(' ');
            n = Convert.ToInt32(sor[0]);
            m = Convert.ToInt32(sor[1]);
            for (int i = 0; i < n; i++)
            {
                sor = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    h[i, j] = Convert.ToInt32(sor[j]);
                }
            }
        }
    }
}

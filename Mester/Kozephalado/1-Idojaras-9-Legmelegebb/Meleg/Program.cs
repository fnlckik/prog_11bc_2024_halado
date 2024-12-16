using System;

namespace Meleg
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

        static int Maximum(int[,] h, int n, int m)
        {
            int maxe = h[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (h[i, j] > maxe) maxe = h[i, j];
                }
            }
            return maxe;
        }

        static void Kivalogat(int[,] h, int n, int m, int[] melegek, out int db)
        {
            db = 0;
            int maxe = Maximum(h, n, m);
            Console.WriteLine(maxe);
        }

        static void Kiir(int[] x, int n)
        {
            // ???
        }

        static void Main(string[] args)
        {
            int[,] h = new int[1000, 1000];
            Beolvas(h, out int n, out int m);

            int[] melegek = new int[1000];
            Kivalogat(h, n, m, melegek, out int db);

            //int[] melegek = Kivalogat(h, n, m, out int db);

            //int[] melegek = new int[1000];
            //int db = Kivalogat(h, n, m, melegek);

            Kiir(melegek, db);
        }
    }
}

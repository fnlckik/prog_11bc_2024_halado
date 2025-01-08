using System;

namespace AtlagosanLegmeleg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] h = new int[1000, 1000];
            Beolvas(h, out int n, out int m);

            //Console.WriteLine($"{Atlag(h, m, 0):f2}");
            int maxi = Maximum(h, n, m);
            Console.WriteLine(maxi);
        }

        static int Maximum(int[,] h, int n, int m)
        {
            int maxi = 0;
            double maxe = Atlag(h, m, 0);
            for (int i = 1; i < n; i++)
            {
                double aktualis = Atlag(h, m, i);
                if (aktualis > maxe)
                {
                    maxi = i;
                    maxe = aktualis;
                }
            }
            return maxi + 1;
        }

        // Mennyi az átlaga az i. sor (település) hőmérsékleteinek?
        static double Atlag(int[,] h, int m, int i)
        {
            int s = 0;
            for (int j = 0; j < m; j++)
            {
                s += h[i, j];
            }
            return (double)s / m;
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

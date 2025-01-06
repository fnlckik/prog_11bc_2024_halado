using System;

namespace Kalapacs
{
    internal class Program
    {
        static void Beolvas(int[,] dobasok, out int n)
        {
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] sor = Console.ReadLine().Split(' ');
                for (int j = 0; j < 6; j++)
                {
                    dobasok[i, j] = Convert.ToInt32(sor[j]);
                }
            }
        }

        static void Main(string[] args)
        {
            int[,] dobasok = new int[100, 6];
            Beolvas(dobasok, out int n); // n: versenyzők száma
            //Kiir(dobasok, n);

            //Console.WriteLine(MegbizhatoE(dobasok, 0)); // true
            //Console.WriteLine(MegbizhatoE(dobasok, 1)); // false
            Kivalogat(dobasok, n);
        }

        static void Kivalogat(int[,] dobasok, int n)
        {
            int[] megbizhatok = new int[100];
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                if (MegbizhatoE(dobasok, i))
                {
                    megbizhatok[db] = i + 1;
                    db++;
                }
            }

            Console.WriteLine(db);
            for (int i = 0; i < db; i++)
            {
                Console.Write(megbizhatok[i] + " ");
            }
        }

        static bool MegbizhatoE(int[,] dobasok, int i)
        {
            int j = 0;
            int mine = dobasok[i, 0];
            int maxe = dobasok[i, 0];
            bool megbizhatoE = true;
            while (j < 6 && megbizhatoE)
            {
                if (dobasok[i, j] < mine) mine = dobasok[i, j];
                if (dobasok[i, j] > maxe) maxe = dobasok[i, j];
                megbizhatoE = dobasok[i, j] != -1 && maxe - mine <= 500;
                j++;
            }
            return megbizhatoE;
        }

        // Az i. versenyző (sor) megbízható-e?
        static bool LassuMegbizhatoE(int[,] dobasok, int i)
        {
            // Min?
            int mine = dobasok[i, 0];
            for (int j = 0; j < 6; j++)
            {
                if (dobasok[i, j] < mine)
                {
                    mine = dobasok[i, j];
                }
            }

            // Max?
            int maxe = dobasok[i, 0];
            for (int j = 0; j < 6; j++)
            {
                if (dobasok[i, j] > maxe)
                {
                    maxe = dobasok[i, j];
                }
            }

            // Eldöntés
            if (mine == -1) return false;
            else if (maxe - mine > 500) return false;
            else return true;
        }

        static void Kiir(int[,] dobasok, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(dobasok[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

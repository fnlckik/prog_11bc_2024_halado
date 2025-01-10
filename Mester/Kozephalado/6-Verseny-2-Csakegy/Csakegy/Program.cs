using System;

namespace Csakegy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n; // tanulók száma
            int m; // versenyek száma
            int[] hatarok = new int[100]; // hatarok[i]: az i. verseny alsó határa
            int[,] tanulok = new int[100, 100]; // tanulok[i, j]: i. versenyen j. tanulo ki volt?
            int[,] pontok = new int[100, 100]; // pontok[i, j]: i. versenyen j. tanuló pontszáma
            int[] indulok = new int[100]; // indulok[i]: az i. versenyen indulók száma
            Beolvas(out n, out m, hatarok, tanulok, pontok, indulok);

            int[] t = new int[100];
            Megszamol(tanulok, t, n, m, indulok);
        }

        static void Megszamol(int[,] tanulok, int[] t, int n, int m, int[] indulok)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < indulok[i]; j++)
                {
                    t[tanulok[i, j] - 1]++;
                }
            }

            // t[i]: az i. tanuló hány versenyen indult
            for (int i = 0; i < n; i++)
            {
                Console.Write(t[i] + " ");
            }
        }

        static void Beolvas(out int n, out int m, int[] hatarok, int[,] tanulok, int[,] pontok, int[] indulok)
        {
            string[] sor = Console.ReadLine().Split(' ');
            n = Convert.ToInt32(sor[0]);
            m = Convert.ToInt32(sor[1]);
            sor = Console.ReadLine().Split(' ');
            int i;
            for (i = 0; i < m; i++)
            {
                hatarok[i] = Convert.ToInt32(sor[i]);
            }

            for (i = 0; i < m; i++)
            {
                sor = Console.ReadLine().Split(' '); // {"3", "1", "10", "2", "30", "3", "10"}
                indulok[i] = Convert.ToInt32(sor[0]);
                for (int j = 0; j < indulok[i]; j++)
                {
                    tanulok[i, j] = Convert.ToInt32(sor[2 * j + 1]); // páratlan indexek
                    pontok[i, j] = Convert.ToInt32(sor[2 * j + 2]); // tanulókat követők
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Nehezek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> minek = new List<int>();
            List<List<int>> pontok = new List<List<int>>();
            Beolvas(minek, pontok);
        }

        static void Beolvas(List<int> minek, List<List<int>> pontok)
        {
            string[] sor = Console.ReadLine().Split(' ');
            int n = int.Parse(sor[1]); // versenyek száma

            // Minimum ponthatárok beolvasása
            sor = Console.ReadLine().Split(' ');
            foreach (string pont in sor)
            {
                minek.Add(int.Parse(pont));
            }

            // Pontok beolvasása
            for (int i = 0; i < n; i++)
            {
                sor = Console.ReadLine().Split(' ');
                // ???
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace Dijazottak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> nevek = new List<string>();
            List<int> pontok = new List<int>();
            Beolvas(nevek, pontok, out int maxpont);

            List<string> a = new List<string>(); // I. díjasok
            List<string> b = new List<string>(); // II. díjasok
            List<string> c = new List<string>(); // III. díjasok
            List<string> d = new List<string>(); // nem díjasok
            Kivalogatas(nevek, pontok, maxpont, a, b, c, d);
        }

        static void Kivalogatas(List<string> nevek, List<int> pontok, int maxpont, List<string> a, List<string> b, List<string> c, List<string> d)
        {
            for (int i = 0; i < nevek.Count; i++)
            {
                if ((double)pontok[i] / maxpont * 100 >= 90)
                {
                    a.Add(nevek[i]);
                }
                else if ((double)pontok[i] / maxpont * 100 >= 80)
                {
                    b.Add(nevek[i]);
                }
            }
        }

        static void Beolvas(List<string> nevek, List<int> pontok, out int maxpont)
        {
            //List<string> sor = new List<string>(Console.ReadLine().Split(' '));
            string[] sor = Console.ReadLine().Split(' ');
            maxpont = int.Parse(sor[1]);
            int n = int.Parse(sor[0]);
            for (int i = 0; i < n; i++)
            {
                sor = Console.ReadLine().Split(';');
                nevek.Add(sor[0]);
                pontok.Add(int.Parse(sor[1]));
            }
        }
    }
}

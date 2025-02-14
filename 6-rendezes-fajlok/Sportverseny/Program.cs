using System;
using System.Collections.Generic;
using System.IO;

namespace Sportverseny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> nevek = new List<string>();
            List<string> orszagok = new List<string>();
            List<int> pontok = new List<int>();
            Beolvas(nevek, orszagok, pontok);
            Rendez(nevek, orszagok, pontok);
            Kiir(nevek, orszagok, pontok);
        }

        static void Rendez(List<string> nevek, List<string> orszagok, List<int> pontok)
        {
            for (int i = 0; i < nevek.Count; i++)
            {
                // Maximum kiválasztásos rendezés (selection sort)
                // k: Ki az, aki a i-dik helyre kell kerüljön?
                int k = i;
                for (int j = k+1; j < nevek.Count; j++)
                {
                    if (pontok[j] > pontok[k] || 
                        pontok[j] == pontok[k] && nevek[j].CompareTo(nevek[k]) == -1)
                    {
                        k = j;
                    }
                }
                Csere(nevek, i, k);
                Csere(orszagok, i, k);
                Csere(pontok, i, k);
            }
        }

        static void Csere<T>(List<T> nevek, int i, int k)
        {
            (nevek[i], nevek[k]) = (nevek[k], nevek[i]);
        }

        static void Kiir(List<string> nevek, List<string> orszagok, List<int> pontok)
        {
            StreamWriter writer = new StreamWriter("minta.txt");
            for (int i = 0; i < nevek.Count; i++)
            {
                writer.WriteLine($"{i+1}. {nevek[i]} ({orszagok[i]}) => {pontok[i]}");
            }
            writer.Close();
        }

        static void Beolvas(List<string> nevek, List<string> orszagok, List<int> pontok)
        {
            StreamReader reader = new StreamReader("eredmeny.csv");
            while (!reader.EndOfStream)
            {
                string[] sor = reader.ReadLine().Split(',');
                nevek.Add(sor[0]);
                orszagok.Add(sor[1]);
                pontok.Add(int.Parse(sor[2]));
            }
            reader.Close();
        }
    }
}

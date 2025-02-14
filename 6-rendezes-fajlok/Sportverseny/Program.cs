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
            Kiir(nevek, orszagok, pontok);
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

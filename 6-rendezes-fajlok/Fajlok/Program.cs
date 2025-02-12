using System;
using System.Collections.Generic;
using System.IO;

namespace Fajlok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> kedvencek = new Dictionary<string, int>();
            //Olvas(kedvencek);
            //Olvas2(kedvencek);
            //Olvas3(kedvencek);
            Olvas4(kedvencek);
            Kiir(kedvencek);
        }

        // Nem javasolt!
        static void Olvas4(Dictionary<string, int> kedvencek)
        {
            string[] sorok = File.ReadAllText("primek.txt").Split('\n');
            foreach (string sor in sorok)
            {
                if (sor != "")
                {
                    string[] adatok = sor.Split(' ');
                    kedvencek.Add(adatok[0], int.Parse(adatok[1]));
                }
            }
        }

        // Nem javasolt!
        static void Olvas3(Dictionary<string, int> kedvencek)
        {
            StreamReader reader = new StreamReader("primek.txt");
            //string tartalom = reader.ReadToEnd();
            string[] sorok = reader.ReadToEnd().Split('\n');
            foreach (string sor in sorok)
            {
                if (sor != "")
                {
                    string[] adatok = sor.Split(' ');
                    kedvencek.Add(adatok[0], int.Parse(adatok[1]));
                }
            }
            reader.Close();
        }

        static void Kiir(Dictionary<string, int> kedvencek)
        {
            //foreach (string kulcs in kedvencek.Keys)
            //{
            //    Console.WriteLine($"{kulcs}: {kedvencek[kulcs]}");
            //}
            foreach (KeyValuePair<string, int> elem in kedvencek)
            {
                Console.WriteLine($"{elem.Key}: {elem.Value}");
            }
        }

        static void Olvas2(Dictionary<string, int> kedvencek)
        {
            StreamReader reader = new StreamReader("primek.txt");
            while (!reader.EndOfStream)
            {
                string sor = reader.ReadLine();
                string[] adatok = sor.Split(' ');
                kedvencek.Add(adatok[0], int.Parse(adatok[1]));
            }
            reader.Close();
        }

        static void Olvas(Dictionary<string, int> kedvencek)
        {
            //StreamReader reader = new StreamReader("../../primek.txt");
            //StreamReader reader = new StreamReader("H:\\24-25\\prog_11bc_2024_halado\\6-rendezes-fajlok\\Fajlok\\bin\\Debug\\primek.txt");
            //StreamReader reader = new StreamReader(@"H:/24-25/prog_11bc_2024_halado/6-rendezes-fajlok/Fajlok/bin/Debug/primek.txt");
            StreamReader reader = new StreamReader("primek.txt");
            string sor = reader.ReadLine();
            while (sor != null)
            {
                Console.WriteLine(sor);
                sor = reader.ReadLine();
            }
            reader.Close();
        }
    }
}

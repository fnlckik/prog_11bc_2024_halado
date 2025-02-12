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
            Olvas2(kedvencek);
            //Olvas3(kedvencek);
            //Olvas4(kedvencek);
            //Olvas5(kedvencek);
            //Olvas6(kedvencek);
            //Olvas7(kedvencek);

            Ir(kedvencek);
        }

        static void Ir(Dictionary<string, int> kedvencek)
        {
            // Hozzáfűzés (append): true
            //StreamWriter writer = new StreamWriter("nemprimek.txt", true);
            StreamWriter writer = new StreamWriter("nemprimek.txt");
            foreach (string nev in kedvencek.Keys)
            {
                writer.WriteLine($"{nev} -- {kedvencek[nev] * 5}");
            }
            writer.Close();
            File.WriteAllText("valami.txt", "Ez a tartalom\nIzébigyó!");
        }

        // C# programozók nagyon szeretik
        // Gond: Flatten your code (clean code)
        static void Olvas7(Dictionary<string, int> kedvencek)
        {
            using (StreamReader reader = new StreamReader("primek.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string sor = reader.ReadLine();
                    string[] adatok = sor.Split(' ');
                    kedvencek.Add(adatok[0], int.Parse(adatok[1]));
                }
            }
        }

        // Manóka függvény
        static void Olvas6(Dictionary<string, int> kedvencek)
        {
            StreamReader reader = new StreamReader("primek.txt");
            string nev = "";
            string szam = "";
            bool szokoz = false;
            while (!reader.EndOfStream)
            {
                char c = (char)reader.Read();
                //Console.Write(c);
                if (c == ' ')
                {
                    szokoz = true;
                }
                else if (c == '\n')
                {
                    szokoz = false;
                    kedvencek.Add(nev, int.Parse(szam));
                    nev = "";
                    szam = "";
                }
                else if (!szokoz)
                {
                    nev += c;
                }
                else
                {
                    szam += c;
                }
            }
            reader.Close();
        }

        static void Olvas5(Dictionary<string, int> kedvencek)
        {
            string[] sorok = File.ReadAllLines("primek.txt");
            //Console.WriteLine(sorok.Length);
            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(' ');
                kedvencek.Add(adatok[0], int.Parse(adatok[1]));
            }
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

        // FNL favourite
        // const int fene = 205
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

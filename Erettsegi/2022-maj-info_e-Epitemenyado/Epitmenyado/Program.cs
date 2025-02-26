using System;
using System.Collections.Generic;
using System.IO;

namespace Epitmenyado
{
    internal class Program
    {
        struct Epulet
        {
            public string adoszam;
            public string utca;
            public string hsz;
            public char tipus; // adó típusa
            public int terulet;
        }

        static void Main(string[] args)
        {
            List<Epulet> epuletek = new List<Epulet>();
            Dictionary<char, int> adok = new Dictionary<char, int>();
            Beolvas(epuletek, adok);
            F2(epuletek);
            //F3(epuletek);
            Console.WriteLine(Ado('C', 180, adok));
        }

        // 'C', 180 + Dictionary
        static int Ado(char adosav, int alapterulet, Dictionary<char, int> adok)
        {
            //int ado;
            //if (adosav == 'A')
            //{
            //    ado = adok['A'] * alapterulet;
            //}
            //else if (adosav == 'B')
            //{
            //    ado = adok['B'] * alapterulet;
            //}
            //else
            //{
            //    ado = adok['C'] * alapterulet;
            //}
            //if (ado < 10000) ado = 0;
            //return ado;
            int ado = adok[adosav] * alapterulet;
            return ado >= 10000 ? ado : 0;
        }

        static void F3(List<Epulet> epuletek)
        {
            // 68396
            Console.Write("3. feladat. Egy tulajdonos adószáma: ");
            string adoszam = Console.ReadLine();
            int db = 0;
            foreach (Epulet epulet in epuletek)
            {
                if (epulet.adoszam == adoszam)
                {
                    Console.WriteLine($"{epulet.utca} utca {epulet.hsz}");
                    db++;
                }
            }
            if (db == 0)
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }
        }

        static void F2(List<Epulet> epuletek)
        {
            Console.WriteLine($"2. feladat. A mintában {epuletek.Count} telek szerepel.");
        }

        static void Beolvas(List<Epulet> epuletek, Dictionary<char, int> adok)
        {
            StreamReader sr = new StreamReader("utca.txt");
            string[] sor = sr.ReadLine().Split(' '); // { "800", "600", "100" }
            adok.Add('A', int.Parse(sor[0]));
            adok.Add('B', int.Parse(sor[1]));
            adok.Add('C', int.Parse(sor[2]));
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine().Split(' ');
                Epulet epulet;
                epulet.adoszam = sor[0];
                epulet.utca = sor[1];
                epulet.hsz = sor[2];
                epulet.tipus = char.Parse(sor[3]);
                epulet.terulet = int.Parse(sor[4]);
                epuletek.Add(epulet);
            }
            sr.Close();
        }
    }
}

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

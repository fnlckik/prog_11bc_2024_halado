using System;
using System.Collections.Generic;
using System.IO;

namespace Sorozatok
{
    internal class Program
    {
        struct Sorozat
        {
            public string datum;
            public string cim;
            public string epizod;
            public int hossz;
            public bool lattaE;
        }

        static void Main(string[] args)
        {
            List<Sorozat> sorozatok = new List<Sorozat>();
            Beolvas(sorozatok);
            Console.WriteLine(sorozatok.Count);
        }

        static void Beolvas(List<Sorozat> sorozatok)
        {
            StreamReader sr = new StreamReader("lista.txt");
            while (!sr.EndOfStream)
            {
                Sorozat s = new Sorozat
                {
                    datum = sr.ReadLine(),
                    cim = sr.ReadLine(),
                    epizod = sr.ReadLine(),
                    hossz = int.Parse(sr.ReadLine()),
                    lattaE = sr.ReadLine() == "1"
                };
                sorozatok.Add(s);
            }
            sr.Close();
        }
    }
}

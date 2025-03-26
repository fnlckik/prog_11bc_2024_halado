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
            public DateTime? date;
            public string cim;
            public string epizod;
            public int hossz;
            public bool lattaE;
        }

        static void Main(string[] args)
        {
            List<Sorozat> sorozatok = new List<Sorozat>();

            // Dátumok kezelése
            //DateTime d = new DateTime();
            //DateTime d = DateTime.Now;
            DateTime d = new DateTime(2024, 2, 29);
            //DateTime d = new DateTime(2025, 3, 15, 18, 12, 37);
            //Console.WriteLine($"{d.Year}-{d.Month:00}-{d.Day:00}");
            //DateTime karacsony = new DateTime(2025, 12, 25);
            DateTime nyariszunet = new DateTime(2025, 6, 13);
            //Console.WriteLine(d < karacsony);
            //Console.WriteLine($"Hány nap van Karácsonyig: {nyariszunet - d}");
            //Console.WriteLine(d.ToShortDateString());

            Beolvas(sorozatok);
            //Kiir(sorozatok);

        }

        static void Kiir(List<Sorozat> sorozatok)
        {
            foreach (Sorozat sorozat in sorozatok)
            {
                if (sorozat.date != null)
                {
                    DateTime d = Convert.ToDateTime(sorozat.date);
                    Console.WriteLine(d.ToShortDateString());
                }
                else
                {
                    Console.WriteLine(sorozat.date);
                }
            }
        }

        static void Beolvas(List<Sorozat> sorozatok)
        {
            StreamReader sr = new StreamReader("lista.txt");
            while (!sr.EndOfStream)
            {
                Sorozat s;
                s.datum = sr.ReadLine();
                if (s.datum == "NI")
                {
                    s.date = null;
                }
                else
                {
                    string[] darabolt = s.datum.Split('.'); // { "2017", "07", "16" }
                    int ev = int.Parse(darabolt[0]);
                    int honap = int.Parse(darabolt[1]);
                    int nap = int.Parse(darabolt[2]);
                    DateTime? d = new DateTime(ev, honap, nap);
                    s.date = d;
                }
                s.cim = sr.ReadLine();
                s.epizod = sr.ReadLine();
                s.hossz = int.Parse(sr.ReadLine());
                s.lattaE = sr.ReadLine() == "1";
                sorozatok.Add(s);
            }
            sr.Close();
        }
    }
}

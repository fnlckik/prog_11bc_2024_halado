using System;
using System.Collections.Generic;
using System.IO;

namespace Jelek
{
    internal class Program
    {
        struct Jel
        {
            public TimeSpan ido;
            public int x, y;
            public int ora, perc, mp;
        }

        static void Main(string[] args)
        {
            //DateTime d = new DateTime(2025, 03, 31, 12, 23, 41);
            //TimeSpan t = new TimeSpan(12, 23, 41);
            //Console.WriteLine(t);
            List<Jel> jelek = new List<Jel>();
            Beolvas(jelek);
            //F2(jelek);

            TimeSpan t1 = new TimeSpan(12, 14, 20);
            TimeSpan t2 = new TimeSpan(13, 17, 5);
            //TimeSpan diff = t2 - t1;
            //Console.WriteLine(diff.Hours * 3600 + diff.Minutes * 60 + diff.Seconds);
            //Console.WriteLine(diff.TotalSeconds);

            Console.WriteLine(Eltelt(t2, t1));
            Console.WriteLine(Eltelt(12, 14, 20, 13, 17, 5));
        }

        // Function overloading (függvény túlterhelés)
        static int Eltelt(int o1, int p1, int mp1, int o2, int p2, int mp2)
        {
            int ido1 = 3600 * o1 + 60 * p1 + mp1;
            int ido2 = 3600 * o2 + 60 * p2 + mp2;
            int diff = Math.Abs(ido2 - ido1);
            return diff;
        }

        static int Eltelt(TimeSpan t1, TimeSpan t2)
        {
            TimeSpan diff = t2 - t1;
            return Math.Abs((int)diff.TotalSeconds);
        }

        static void F2(List<Jel> jelek)
        {
            Console.WriteLine("2. feladat");
            Console.Write("Adja meg a jel sorszámát! ");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine($"x={jelek[i-1].x} y={jelek[i-1].y}");
        }

        static void Beolvas(List<Jel> jelek)
        {
            StreamReader sr = new StreamReader("jel.txt");
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split();
                int ora = int.Parse(sor[0]);
                int perc = int.Parse(sor[1]);
                int mp = int.Parse(sor[2]);
                Jel jel = new Jel
                {
                    ora = ora,
                    perc = perc,
                    mp = mp,
                    ido = new TimeSpan(ora, perc, mp),
                    x = int.Parse(sor[3]),
                    y = int.Parse(sor[4])
                };
                //Jel jel = new Jel();
                //jel.x = int.Parse(sor[3]);
                //jel.y = int.Parse(sor[4]);
                jelek.Add(jel);
            }
            sr.Close();
        }
    }
}

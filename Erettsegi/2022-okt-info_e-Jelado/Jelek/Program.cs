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

            //Console.WriteLine(Eltelt(t2, t1));
            //Console.WriteLine(Eltelt(12, 14, 20, 13, 17, 5));
            F4(jelek);
            //F4Regi(jelek);

            F5(jelek);
            F6(jelek);
            F7(jelek);
        }

        static void F7(List<Jel> jelek)
        {
            StreamWriter sw = new StreamWriter("kimaradt.txt");
            for (int i = 0; i < jelek.Count - 1; i++)
            {
                int idoelteres = Eltelt(jelek[i].ido, jelek[i + 1].ido);
                int idoDarab = (int)Math.Ceiling((double)idoelteres / (5 * 60) - 1);
                //int idoDb = (idoelteres - 1) / (5 * 60);

                int xElteres = Math.Abs(jelek[i].x - jelek[i + 1].x);
                int xDarab = (int)Math.Ceiling((double)xElteres / 10 - 1);

                int yElteres = Math.Abs(jelek[i].y - jelek[i + 1].y);
                int yDarab = (int)Math.Ceiling((double)yElteres / 10 - 1);

                int helyDarab = xDarab > yDarab ? xDarab : yDarab;
                //int helyDarab = Math.Max(xDarab, yDarab);

                TimeSpan ido = jelek[i + 1].ido;

                if (idoDarab != 0 || helyDarab != 0)
                {
                    if (idoDarab > helyDarab)
                    {
                        sw.WriteLine($"{ido.Hours} {ido.Minutes} {ido.Seconds} időeltérés {idoDarab}");
                    }
                    else
                    {
                        sw.WriteLine($"{ido.Hours} {ido.Minutes} {ido.Seconds} koordináta-eltérés {helyDarab}");
                    }
                }
            }
            sw.Close();
        }

        static void F6(List<Jel> jelek)
        {
            double osszeg = 0;
            for (int i = 1; i < jelek.Count; i++)
            {
                double x = Math.Pow(jelek[i].x - jelek[i - 1].x, 2);
                double y = Math.Pow(jelek[i].y - jelek[i - 1].y, 2);
                double d = Math.Sqrt(x + y);
                osszeg += d;
            }
            Console.WriteLine("\n6. feladat");
            Console.WriteLine($"Elmozdulás: {osszeg:0.000} egység");
        }

        static void F5(List<Jel> jelek)
        {
            // Kéne: minX, minY, maxX, maxY
        }

        static void F4Regi(List<Jel> jelek)
        {
            Console.WriteLine("\n4. feladat");
            Jel elso = jelek[0];
            Jel utso = jelek[jelek.Count - 1];
            int eltelt = Eltelt(elso.ora, elso.perc, elso.mp, utso.ora, utso.perc, utso.mp);
            int ora = eltelt / 3600;
            int perc = eltelt % 3600 / 60;
            int mp = eltelt % 60;
            Console.WriteLine($"Időtartam: {ora:00}:{perc:00}:{mp:00}");
        }

        static void F4(List<Jel> jelek)
        {
            Console.WriteLine("\n4. feladat");
            int eltelt = Eltelt(jelek[0].ido, jelek[jelek.Count - 1].ido);
            TimeSpan ido = new TimeSpan(0, 0, eltelt);
            Console.WriteLine($"Időtartam: {ido}");
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

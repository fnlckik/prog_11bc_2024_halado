﻿using System;
using System.Collections.Generic;

namespace konyvek
{
    // Mit lát a felhasználó? (view)
    internal class Program
    {
        static void Main(string[] args)
        {
            // F1
            Kiadas kiadas = new Kiadas("kiadas.txt");
            //Console.WriteLine(kiadas.Konyvek.Count);

            // F2
            //Console.WriteLine(kiadas.Konyvek[0].SzerzoE("Szobonya Erzsébet")); // true
            //Console.WriteLine(kiadas.Konyvek[0].SzerzoE("Benedek Elek")); // false
            Console.WriteLine("2. feladat:");
            Console.Write("Szerző: ");
            string nev = "Benedek Elek"; //Console.ReadLine();
            int szerzoDb = kiadas.KiadasokSzama(nev);
            Console.WriteLine($"{szerzoDb} könyvkiadás");

            // F3
            Console.WriteLine("3. feladat:");
            Tuple<int, int> maxPeldany = kiadas.MaxPeldany();
            Console.WriteLine($"Legnagyobb példányszám: {maxPeldany.Item1}, előfordult {maxPeldany.Item2} alkalommal");

            // F4
            Console.WriteLine("4. feladat:");
            Konyv kulfoldiNepszeru = kiadas.KulfoldiNepszeru(40000);
            Console.WriteLine(kulfoldiNepszeru);

            // F5


            // F6
            Console.WriteLine("6. feladat:");
            Console.WriteLine("Legalább kétszer, nagyobb példányszámban újra kiadott könyvek:");
            HashSet<string> cimek = kiadas.UjraKiadottak();
            foreach (string cim in cimek)
            {
                Console.WriteLine(cim);
            }
        }
    }
}

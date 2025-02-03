using System;
using System.Collections.Generic;

namespace Szotar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // asszociáció ~ képzettársítás
            // Dictionary ~ Map ~ Hasító tábla ~ függvény ~ asszociatív tömb
            // szótár: kulcs-érték párok sokasága (kulcs egyedi)
            Dictionary<string, string> magyarAngol = new Dictionary<string, string>();
            magyarAngol.Add("kutya", "dog");
            magyarAngol.Add("macska", "cat");
            magyarAngol.Add("kecske", "goat");
            magyarAngol.Add("alma", "apple");
            magyarAngol.Add("teknős", "turtle");

            magyarAngol.Remove("alma");

            Console.WriteLine("Szavak száma: " + magyarAngol.Count);

            Console.WriteLine("A kutya szó angolul: " + magyarAngol["kutya"]);

            // HIBA!!!
            //Console.WriteLine("Az egér szó angolul: " + magyarAngol["egér"]);
            Console.WriteLine("Tudjuk-e az egér szót angolul? " + magyarAngol.ContainsKey("egér")); // false

            // HIBA!!! Kulcs egyedi kell legyen!
            //magyarAngol.Add("kutya", "hound");

            Kiir(magyarAngol);

            // --------------------------------------------
            Console.Clear();

            // Egy tálban gyümölcsök vannak. Melyik gyümölcsből van a legtöbb?
            List<string> gyumolcsok = new List<string> { "narancs", "alma", "szilva",
                                                         "narancs", "alma", "alma",
                                                         "körte", "alma", "narancs" };
            // Ötlet: egy szótárban számoljuk meg, hogy melyik gyümölcsből hány van?
            Dictionary<string, int> mennyisegek = Megszamol(gyumolcsok);
            Kiir(mennyisegek);

            Leggyakoribb(mennyisegek);

            // Átlagosan hány van egy gyümölcsből a tálban? (összegzés)
            Atlag(mennyisegek);

            // Van-e olyan gyümölcs, amiből pontosan 1 darab van?
            // Ha van, akkor adjunk meg egyet!
            string gy = PontEgy(mennyisegek);
            Console.WriteLine("Csak egy van a tálban a következő gyümölcsből: " +  gy);
        }

        static string PontEgy(Dictionary<string, int> mennyisegek)
        {
            foreach (string item in mennyisegek.Keys)
            {
                if (mennyisegek[item] == 1)
                {
                    return item;
                }
            }
            return "-";
        }

        static void Atlag(Dictionary<string, int> mennyisegek)
        {
            int ossz = 0;
            foreach (string item in mennyisegek.Keys)
            {
                ossz += mennyisegek[item];
            }

            double atlag = (double)ossz / mennyisegek.Count;
            Console.WriteLine("Átlagos mennyiség egy gyümölcsből: " + atlag);
        }

        static void Leggyakoribb(Dictionary<string, int> mennyisegek)
        {
            int maxert = Int32.MinValue;
            string maxkulcs = "-";
            foreach (string gyumolcs in mennyisegek.Keys)
            {
                if (mennyisegek[gyumolcs] > maxert)
                {
                    maxkulcs = gyumolcs;
                    maxert = mennyisegek[gyumolcs];
                }
            }
            Console.WriteLine("Leggyakoribb gyümölcs: " + maxkulcs);
        }

        // narancs: 3, alma: 4, szilva: 1, körte: 1
        static Dictionary<string, int> Megszamol(List<string> gyumolcsok)
        {
            Dictionary<string, int> mennyisegek = new Dictionary<string, int>();
            foreach (string gyumolcs in gyumolcsok)
            {
                if (!mennyisegek.ContainsKey(gyumolcs))
                {
                    mennyisegek.Add(gyumolcs, 1);
                }
                else
                {
                    mennyisegek[gyumolcs]++;
                }
            }
            return mennyisegek;
        }

        static void Kiir<TKey, TValue>(Dictionary<TKey, TValue> szotar)
        {
            Console.WriteLine("\nSzótár:");
            // Dictionary<string, string>.KeyCollection kulcsok = szotar.Keys;
            foreach (TKey kulcs in szotar.Keys)
            {
                Console.WriteLine(kulcs + " - " + szotar[kulcs]);
            }
        }
    }
}

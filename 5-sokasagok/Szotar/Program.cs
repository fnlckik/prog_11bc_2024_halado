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
        }

        static Dictionary<string, int> Megszamol(List<string> gyumolcsok)
        {
            Dictionary<string, int> mennyisegek = new Dictionary<string, int>();
            // ???
            return mennyisegek;
        }

        static void Kiir(Dictionary<string, string> szotar)
        {
            Console.WriteLine("\nMagyar - Angol szótár:");
            // Dictionary<string, string>.KeyCollection kulcsok = szotar.Keys;
            foreach (string kulcs in szotar.Keys)
            {
                Console.WriteLine(kulcs + " - " + szotar[kulcs]);
            }
        }
    }
}

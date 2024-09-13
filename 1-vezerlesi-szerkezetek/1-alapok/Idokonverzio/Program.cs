using System;

namespace Idokonverzio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ora, perc, masodperc;
            Random r = new Random();
            ora = r.Next(24);
            perc = r.Next(60);
            masodperc = r.Next(60);

            Console.WriteLine($"Időpont: {ora:00}:{perc:00}:{masodperc:00}");

            int idopont = ora * 3600 + perc * 60 + masodperc;
            Console.WriteLine($"A nap kezdete óta {idopont} másodperc telt el.");

            // Váltsuk vissza!
            int hour, minute, second;
            hour = idopont / 3600;
            int maradek = idopont % 3600;
            minute = maradek / 60;
            second = maradek % 60;

            Console.WriteLine($"A nap kezdete óta {hour} óra {minute} perc és {second} másodperc telt el.");

            Console.ReadKey();
        }
    }
}

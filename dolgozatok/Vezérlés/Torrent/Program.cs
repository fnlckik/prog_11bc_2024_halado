using System;

namespace Torrent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int v = 95; // Letöltési sebesség (Mbps)
            int s = 0; // Mennyit töltött le? (Mb)
            for (int i = 0; i < 12; i++)
            {
                s += v;
                Console.WriteLine($"Sebesség: {v} Mbps, Letöltve: {s*0.125*60} MB");
                int irany = r.Next(2); // 0 v 1
                v += irany == 0 ? 5 : -5;
            }

            double atlag = (double) s / 12;
            Console.WriteLine($"Átlagsebesség: {atlag:.00}");
            if (atlag < 90)
            {
                Console.WriteLine("Még a MÁV is gyorsabb ennél!");
            }

            Console.ReadKey();
        }
    }
}

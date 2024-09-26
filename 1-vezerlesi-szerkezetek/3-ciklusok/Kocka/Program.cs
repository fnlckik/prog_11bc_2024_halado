using System;

namespace Kocka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Dobások száma: ");
            int n = Convert.ToInt32(Console.ReadLine());

            // Veszélyes változónevek:
            // i, l, I, 1
            // o, O, 0

            // a) Dobjunk n-szer a kockával
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                int aktualis = r.Next(1, 7);
                Console.Write(aktualis + " ");
            }

            // b) Dobáljuk a kockát amíg 6-ost nem kapunk!


            Console.ReadKey();
        }
    }
}

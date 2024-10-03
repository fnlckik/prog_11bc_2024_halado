using System;

namespace Erme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 50;
            Random r = new Random();

            // a) 50-szer dobjuk fel
            Console.WriteLine("a) Érme dobása 50-szer:");
            int dbF = 0;
            for (int i = 0; i < n; i++)
            {
                // int erme = r.Next(1, 3); // 1, 2
                int erme = r.Next(2); // 0 => fej, 1 => iras
                if (erme == 0)
                {
                    Console.Write("F ");
                    dbF++;
                }
                else
                {
                    Console.Write("I ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Fejek száma: {dbF}");
            Console.WriteLine($"Írások száma: {n - dbF}");

            // b) Addig dobáljuk az érmét,
            // amíg egymás után 4 írást nem kapunk
            Console.WriteLine("b) Dobálás 4 egymást követő írásig:");
            int irasok = 0;
            do
            {
                int dobas = r.Next(2); // 0 => fej, 1 => iras
                if (dobas == 0)
                {
                    Console.Write("F ");
                    irasok = 0;
                }
                else
                {
                    Console.Write("I ");
                    irasok++;
                }
                // irasok = ++irasok;
                // irasok++;
                //irasok = dobas == 0 ? 0 : ++irasok; WOW

                // Balazs
                //irasok = dobas == 0 ? 0 : irasok + 1;
                //char erme = dobas == 0 ? 'F' : 'I';
                //Console.Write(erme + " ");
            } while (irasok < 4);

            Console.ReadKey();
        }
    }
}

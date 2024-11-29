using System;

namespace Tejarak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Deklaráció
            int n, also, felso;
            int[] arak = new int[100];

            // Beolvasás
            string[] darabok = Console.ReadLine().Split(' ');
            n = Convert.ToInt32(darabok[0]);
            also = Convert.ToInt32(darabok[1]);
            felso = Convert.ToInt32(darabok[2]);

            int i;
            for (i = 0; i < n; i++)
            {
                arak[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Feldolgozás - megszámolás
            int db = 0;
            for (i = 0; i < n; i++)
            {
                if (also <= arak[i] && arak[i] <= felso)
                {
                    db++;
                }
            }

            // Kiírás
            Console.WriteLine(db);
        }
    }
}

using System;

namespace Gyumolcsok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] gyumolcsok = { "cigánymeggy", "görögdinnye", "paradicsom" };
            Console.WriteLine("a) Egyesével:");
            Console.WriteLine(gyumolcsok[0]);
            Console.WriteLine(gyumolcsok[1]);
            Console.WriteLine(gyumolcsok[2]);

            Console.WriteLine();
            Console.WriteLine("b) Ciklussal");
            for (int i = 0; i < gyumolcsok.Length; i++)
            {
                Console.WriteLine(gyumolcsok[i]);
            }

            Console.WriteLine();
            Console.WriteLine("c) Foreach (titkos tanok)");
            foreach (string gy in gyumolcsok)
            {
                Console.WriteLine(gy);
            }

            Console.ReadKey();
        }
    }
}

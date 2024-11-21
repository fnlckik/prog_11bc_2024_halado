using System;

namespace Jogositvany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Elnevezési konvenciók
            // PascalCase - C# (ReadLine)
            // camelCase - JS (addEventListener)
            int n = Convert.ToInt32(Console.ReadLine());

            // Statikus tömbök
            // - tömbök méretei fixek
            // - fordítási időben tudni kell a méretüket (!!!)
            string[] nevek = new string[100];
            int[] korok = new int[100];
            bool[] jogsik = new bool[100];

            int i;
            for (i = 0; i < n; i++)
            {
                string sor = Console.ReadLine();
                string[] adatok = sor.Split(' ');
                Console.WriteLine(adatok);
            }

            //Console.ReadKey();
        }
    }
}

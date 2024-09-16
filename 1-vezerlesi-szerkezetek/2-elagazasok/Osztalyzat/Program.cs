using System;

namespace Osztalyzat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int jegy = r.Next(1, 6);

            // 1. if-else
            if (jegy == 1) Console.WriteLine("Elégtelen!");
            else if (jegy == 2) Console.WriteLine("Elégséges!");
            else if (jegy == 3) Console.WriteLine("Közepes!");
            else if (jegy == 4) Console.WriteLine("Jó!");
            else Console.WriteLine("Jeles!");

            // 2. switch
            switch (jegy)
            {
                case 1:
                    Console.WriteLine("Elégtelen!");
                    break;
                case 2:
                    Console.WriteLine("Elégséges!");
                    break;
                case 3:
                    Console.WriteLine("Közepes!");
                    break;
                case 4:
                    Console.WriteLine("Jó!");
                    break;
                case 5:
                    Console.WriteLine("Jeles!");
                    break;
            }

            // 3. tömbök (?)

            Console.ReadKey();
        }
    }
}

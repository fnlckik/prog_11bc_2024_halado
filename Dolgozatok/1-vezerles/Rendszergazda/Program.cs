using System;

namespace Rendszergazda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ido = 7 * 60 + 52;
            bool megvan = false;
            const int utolso = 15 * 60 - 25;
            Random r = new Random();
            Console.WriteLine("07:52");
            do
            {
                ido += 25;
                Console.WriteLine($"{ido / 60:00}:{ido % 60:00}");
                double p = r.NextDouble(); // megvan => 1-től 5-ig
                if (p <= 0.05) megvan = true;
            } while (!megvan && ido <= utolso);

            if (megvan) Console.WriteLine("Megtaláltuk :)");
            else Console.WriteLine("Nem találtuk meg :(");

            Console.ReadKey();
        }
    }
}

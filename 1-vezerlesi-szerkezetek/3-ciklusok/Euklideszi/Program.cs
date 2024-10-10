using System;

namespace Euklideszi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b: ");
            int b = Convert.ToInt32(Console.ReadLine());

            int eredetiA = a, eredetiB = b;

            // Mj: a.ToString().PadLeft(4)
            int r = a % b;
            while (r != 0)
            {
                Console.WriteLine($"{a} = {a/b} * {b} + {r}");
                a = b;
                b = r;
                r = a % b;
            }
            Console.WriteLine($"{a} = {a / b} * {b} + {r}");

            Console.WriteLine($"({eredetiA}, {eredetiB}) = {b}");
            Console.WriteLine($"[{eredetiA}, {eredetiB}] = {(eredetiA * eredetiB) / b}");

            Console.ReadKey();
        }
    }
}

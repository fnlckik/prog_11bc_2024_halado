using System;

namespace Hatvanyok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int hatvany = 2;
            while (n % hatvany == 0)
            {
                Console.Write(hatvany + " ");
                hatvany *= 2;
            }

            Console.ReadKey();
        }
    }
}

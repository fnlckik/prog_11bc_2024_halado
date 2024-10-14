using System;

namespace Parameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            if (args.Length > 0)
            {
                Console.WriteLine(args[0]);
            }
            Console.ReadKey();
        }
    }
}

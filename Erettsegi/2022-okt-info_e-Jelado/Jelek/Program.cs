using System;
using System.Collections.Generic;

namespace Jelek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DateTime d = new DateTime(2025, 03, 31, 12, 23, 41);
            TimeSpan t = new TimeSpan(12, 23, 41);
            Console.WriteLine(t);
        }
    }
}

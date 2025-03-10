using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tizedespont
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = 5.2;
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine(CultureInfo.CurrentCulture);
            Console.WriteLine(x);

            string s1 = "áfonya";
            string s2 = "afonya";
            Console.WriteLine(s1.CompareTo(s2));

            // Immutable
            string s = "alma;körte;banán;dinnye;áfonya";
            //s = s.Replace(";", " ");
            string uj = "";
            for (int i = 0; i < s.Length; i++)
            {
                uj += s[i] == ';' ? ' ' : s[i];
            }
            //uj = new String(uj.Reverse().ToArray());
            uj = String.Join("", uj.Reverse().ToList());
            Console.WriteLine(uj);
        }
    }
}

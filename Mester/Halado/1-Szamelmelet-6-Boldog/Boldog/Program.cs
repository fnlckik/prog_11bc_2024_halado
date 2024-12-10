using System;

namespace Boldog
{
    internal class Program
    {
        // Negyzet(23) == 4 + 9 == 13
        static int Negyzet(int n)
        {
            string jegyek = Convert.ToString(n); // "23"
            int s = 0;
            for (int i = 0; i < jegyek.Length; i++)
            {
                // Konvertálni kéne!
                //s += jegyek[i] * jegyek[i]; // '2'*'2'
                int jegy = Convert.ToInt32(Convert.ToString(jegyek[i]));
                s +=  (int)Math.Pow(jegy, 2);
            }
            return s;
        }

        // BoldogE(13) == true
        static bool BoldogE(int n)
        {
            while (n >= 10)
            {
                //Console.Write(n + " ");
                n = Negyzet(n);
            }
            return n == 1 || n == 7;
        }

        static void Boldogak(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                if (BoldogE(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        static void Main(string[] args)
        {
            int a, b;
            string[] sor = Console.ReadLine().Split();
            a = Convert.ToInt32(sor[0]);
            b = Convert.ToInt32(sor[1]);
            Boldogak(a, b);
        }
    }
}

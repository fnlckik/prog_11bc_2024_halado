using System;

namespace Eljarasok
{
    internal class Program
    {
        static void Kiir(string s)
        {
            Random r = new Random();
            int n = r.Next(3, 10);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(s);
            }
        }

        // out parameter: kimenő paraméter
        // Az eljárásban kap értéket!
        static void Beolvas(out int n)
        {
            n = Convert.ToInt32(Console.ReadLine());
        }

        static void Duplaz(ref int a)
        {
            if (a % 2 == 1)
            {
                a *= 2;
            }
        }

        static void Novel(int[] t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                t[i]++;
            }
        }

        static void Main(string[] args)
        {
            // F4
            Kiir("Fakopáncs.");

            // F5
            Beolvas(out int n);
            Console.WriteLine(Math.Sqrt(n));

            // F6
            int a = 12;
            Duplaz(ref a);
            Console.WriteLine(a);

            // F7 - a tömbök átadása cím szerint történik
            int[] t = { 7, 4, -6, 114, 2 };
            Novel(t);
            for (int i = 0; i < t.Length; i++)
            {
                Console.Write(t[i] + " ");
            }
        }
    }
}

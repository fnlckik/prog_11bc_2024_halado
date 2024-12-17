using System;

namespace Fuggvenyek
{
    internal class Program
    {
        static double Atfogo(double a, double b)
        {
            return Math.Sqrt(a * a + b * b);
        }

        static void Modosit(ref int n)
        {
            Random r = new Random();
            if (r.Next(2) == 0)
            {
                n++;
            }
            else
            {
                n--;
            }
        }

        static bool VanBenneA(string s)
        {
            int i = 0;
            while (i < s.Length && !(s[i] == 'a' || s[i] == 'A'))
            {
                i++;
            }
            return i < s.Length;
        }

        static string[] KivalogatAbetusek(string[] szavak, out int db)
        {
            string[] x = new string[1000];
            db = 0;
            for (int i = 0; i < szavak.Length; i++)
            {
                if (VanBenneA(szavak[i]))
                {
                    x[db] = szavak[i];
                    db++;
                }
            }
            return x;
        }

        static void Kiir(string[] x, int n)
        {
            for (int i = 0; i < n-1; i++)
            {
                Console.Write(x[i] + " - ");
            }
            Console.Write(x[n-1]);
        }

        static void Main(string[] args)
        {
            // F1
            Console.WriteLine("1. feladat:");
            Console.WriteLine(Atfogo(5, 12));
            Console.WriteLine($"{Atfogo(2, 7):0.00}");

            // F2
            Console.WriteLine("\n2. feladat:");
            int n = 5;
            Modosit(ref n);
            Console.WriteLine(n);

            // F3
            Console.WriteLine("\n3. feladat:");
            Console.WriteLine(VanBenneA("labda"));
            Console.WriteLine(VanBenneA("Alex"));
            Console.WriteLine(VanBenneA("fekete"));

            // F4
            string[] szavak = { "Arany", "bauxit", "vese", "kisegér", "Réka", "Baranya", "rendszergazda", "vödör" };
            string[] abetusek = KivalogatAbetusek(szavak, out int db);

            // F5
            Console.WriteLine("\n5. feladat:");
            Kiir(abetusek, db);
        }
    }
}

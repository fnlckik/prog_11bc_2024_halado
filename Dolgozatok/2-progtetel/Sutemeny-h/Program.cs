using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Sutemeny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // F1
            string[] osztalyok = new string[20];
            int[] kostolok = new int[20];
            double[] pontok = new double[20];
            int n = Convert.ToInt32(Console.ReadLine());
            int i;
            for (i = 0; i < n; i++)
            {
                string sor = Console.ReadLine();
                string[] adatok = sor.Split(' ');
                osztalyok[i] = adatok[0];
                kostolok[i] = Convert.ToInt32(adatok[1]);
                pontok[i] = Convert.ToDouble(adatok[2]);
            }

            // F2
            int maxi = 0;
            for (i = 0; i < n; i++)
            {
                if (pontok[i] > pontok[maxi])
                {
                    maxi = i;
                }
            }
            Console.WriteLine($"2. feladat: {osztalyok[maxi]}");

            // F3
            int s = 0;
            int db = 0;
            for (i = 0; i < n; i++)
            {
                if (osztalyok[i][0] == '9')
                {
                    s += kostolok[i];
                    db++;
                }
            }
            Console.WriteLine($"3. feladat: {(double)s / db:0.0}");

            // F4
            i = 0;
            while (i < n && !(pontok[i] < 1 && kostolok[i] > 40))
            {
                i++;
            }
            if (i < n)
            {
                Console.WriteLine($"4. feladat: {osztalyok[i]}");
            }
            else
            {
                Console.WriteLine("4. feladat: -");
            }

            // F5
            i = 0;
            while (i < n && !(pontok[i] >= 3.5))
            {
                i++;
            }
            if (i < n)
            {
                int mini = i;
                for (int j = mini+1; j < n; j++)
                {
                    if (kostolok[j] < kostolok[mini] && pontok[j] >= 3.5)
                    {
                        mini = j;
                    }
                }
                Console.WriteLine($"5. feladat: {osztalyok[mini]}");
            }
            else
            {
                Console.WriteLine("5. feladat: - ");
            }

            // Bónusz!
            /*
            i = 0;
            int k = 0;
            bool megvan = false;
            while (i < n && !megvan)
            {
                k = i+1;
                while (k < n && kostolok[i] != kostolok[k])
                {
                    k++;
                }
                megvan = k < n;
                if (!megvan)
                {
                    i++;
                }
            }
            if (megvan)
            {
                Console.WriteLine($"6. Bónusz: {osztalyok[i]}, {osztalyok[k]}");
            }
            */
        }
    }
}

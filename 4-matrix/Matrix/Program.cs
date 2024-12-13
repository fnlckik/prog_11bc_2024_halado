using System;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] t = new int[3] { 2, 6, 1 };
            int[,] matrix = new int[3,4] {
                { 8, 3, 21, 4 },
                { 1, -5, 7, 13 },
                { 3, 3, 10, -1 }
            };

            // F1
            Console.WriteLine($"2. sor 3. eleme: {matrix[1, 2]}"); // 7
            Console.WriteLine("Sorok száma: " + matrix.GetLength(0));
            Console.WriteLine("Oszlopok száma: " + matrix.GetLength(1));

            // F2
            //Console.WriteLine(matrix.Length);
            int n = matrix.GetLength(0); // sorok száma
            int m = matrix.GetLength(1); // oszlopok száma
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            // F3
            int s = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    s += matrix[i, j];
                }
            }
            Console.WriteLine("Elemek összege: " + s);

            // F4
            int maxi = 0, maxj = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[maxi, maxj])
                    {
                        maxi = i;
                        maxj = j;
                    }
                }
            }
            // ertek = matrix[maxi, maxj]
            Console.WriteLine($"Maximális elem helye: {maxi+1}, {maxj+1}");

            // F5 - a
            Console.Write("Soronként összeg: ");
            for (int i = 0; i < n; i++)
            {
                int sorosszeg = 0;
                for (int j = 0; j < m; j++)
                {
                    sorosszeg += matrix[i, j];
                }
                Console.Write(sorosszeg + " ");
            }
            Console.WriteLine();

            // F5 - b
            Console.Write("Oszloponként összeg: ");
            for (int i = 0; i < m; i++) // i: oszlop
            {
                int oszloposszeg = 0;
                for (int j = 0; j < n; j++) // j: sor
                {
                    oszloposszeg += matrix[j, i];
                }
                Console.Write(oszloposszeg + " ");
            }
            Console.WriteLine();
        }
    }
}

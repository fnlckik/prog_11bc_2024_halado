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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
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
        }
    }
}

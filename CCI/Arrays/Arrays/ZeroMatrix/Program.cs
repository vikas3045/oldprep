using System;
using System.Collections.Generic;

namespace ZeroMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
            {
                { 1, 2, 0 },
                { 4, 5, 6 },
                { 7, 0, 9 },
                { 10, 11, 12}
            };

            DisplayMatrix(matrix);

            ZeroMatrix(matrix);

            Console.WriteLine();
            DisplayMatrix(matrix);

            Console.ReadLine();
        }

        private static void ZeroMatrix(int[,] matrix)
        {
            List<int> cols = new List<int>();
            List<int> rows = new List<int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            foreach (var row in rows)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            foreach (var col in cols)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = 0;
                }
            }
        }

        private static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}

using System;

namespace PrintSpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = {
                {1,   2,  3,  4,  5,  6},
                {7,   8,  9, 10, 11, 12},
                {13, 14, 15, 16, 17, 18}
            };

            PrintSpiralMatrix(matrix);

            Console.ReadLine();
        }

        private static void PrintSpiralMatrix(int[,] matrix)
        {
            int row = 0;
            int col = 0;
            int rowSize = matrix.GetLength(0);
            int colSize = matrix.GetLength(1);

            while (row < rowSize && col < colSize)
            {
                // Print first row
                for (int i = col; i < colSize; i++)
                    Console.Write(matrix[row, i] + " ");
                row++;

                // Print last col
                for (int i = row; i < rowSize; i++)
                    Console.Write(matrix[i, colSize - 1] + " ");
                colSize--;

                // Print last row
                if (row < rowSize)
                {
                    for (int i = colSize - 1; i >= col; i--)
                        Console.Write(matrix[rowSize - 1, i] + " ");
                    rowSize--;
                }

                // Print first col
                if (col < colSize)
                {
                    for (int i = rowSize - 1; i >= row; i--)
                        Console.Write(matrix[i, col] + " ");
                    col++;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter 4x4 matrix: \n");
            //int[,] matrix = new int[3, 3];

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write("Enter value for ({0},{1}): ", i, j);
            //        matrix[i, j] = Convert.ToInt16(Console.ReadLine());
            //    }
            //}

            //int[,] matrix = new int[,]
            //{
            //    { 1, 2, 3 },
            //    { 4, 5, 6 },
            //    { 7, 8, 9 }
            //};

            int[,] matrix = new int[,]
            {
                { 1, 2, 3 ,11 },
                { 4, 5, 6, 12 },
                { 7, 8, 9, 13 },
                { 14, 15, 16, 17 }
            };

            Print(matrix);

            RotateMatrix(matrix);

            Console.WriteLine();

            Print(matrix);

            Console.ReadLine();
        }

        private static void Print(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + "\t");
                }

                Console.WriteLine();
            }
        }

        private static void RotateMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            if (matrix.Length == 0 || matrix.GetLength(0) != matrix.GetLength(1))
                return;

            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i <= last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first, i];

                    // left -> top
                    matrix[first, i] = matrix[last - offset, first];

                    // bottom -> left
                    matrix[last - offset, first] = matrix[last, last - offset];

                    // right -> bottom
                    matrix[last, last - offset] = matrix[i, last];

                    // top -> right
                    matrix[i, last] = top;
                }
            }
        }

        // Below method is just spiral traversal with movement by 1 place and 
        // is not the solution for rotation of matrix
        private static void MovementBy1(int[,] matrix)
        {
            int row = 0; int col = 0;
            int rowSize = matrix.GetLength(0);
            int colSize = matrix.GetLength(1);
            int previous; int current;

            while (row < rowSize && col < colSize)
            {
                if (row + 1 == rowSize || col + 1 == colSize)
                    break;

                // Get the previous element
                previous = matrix[row + 1, col];

                // Process the first row
                for (int i = col; i < colSize; i++)
                {
                    current = matrix[row, i];
                    matrix[row, i] = previous;
                    previous = current;
                }
                row++;

                // Process the last col
                for (int i = row; i < rowSize; i++)
                {
                    current = matrix[i, colSize - 1];
                    matrix[i, colSize - 1] = previous;
                    previous = current;
                }
                colSize--;

                // Process the last row
                if (row < rowSize)
                {
                    for (int i = colSize - 1; i >= col; i--)
                    {
                        current = matrix[rowSize - 1, i];
                        matrix[rowSize - 1, i] = previous;
                        previous = current;
                    }
                }
                rowSize--;

                // Process the first col
                if (col < colSize)
                {
                    for (int i = rowSize - 1; i >= row; i--)
                    {
                        current = matrix[i, col];
                        matrix[i, col] = previous;
                        previous = current;
                    }
                }
                col++;
            }
        }
    }
}

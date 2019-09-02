using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = {{1, 1, 0, 0, 0},
                   {0, 1, 0, 0, 1},
                   {1, 0, 0, 1, 1},
                   {0, 0, 0, 0, 0},
                   {1, 0, 1, 0, 1} };

            Console.WriteLine(FindNumberOfIslands(matrix));

            Console.ReadLine();
        }

        private static int FindNumberOfIslands(int[,] matrix)
        {
            HashSet<string> hsVisited = new HashSet<string>();
            int islandCount = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 1 && !hsVisited.Contains(r + "|" + c))
                    {
                        islandCount++;
                        VisitIsland(matrix, r, c, hsVisited);
                    }
                }
            }

            return islandCount;
        }

        private static void VisitIsland(int[,] matrix, int r, int c, HashSet<string> hsVisited)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            if (!IsValidIndex(ref matrix, r, c) || hsVisited.Contains(r + "|" + c)) return;

            hsVisited.Add(r + "|" + c);

            if (IsValidIndex(ref matrix, r, c - 1))
                VisitIsland(matrix, r, c - 1, hsVisited);

            if (IsValidIndex(ref matrix, r, c + 1))
                VisitIsland(matrix, r, c + 1, hsVisited);

            if (IsValidIndex(ref matrix, r - 1, c))
                VisitIsland(matrix, r - 1, c, hsVisited);

            if (IsValidIndex(ref matrix, r + 1, c))
                VisitIsland(matrix, r + 1, c, hsVisited);

            if (IsValidIndex(ref matrix, r - 1, c - 1))
                VisitIsland(matrix, r - 1, c - 1, hsVisited);

            if (IsValidIndex(ref matrix, r - 1, c + 1))
                VisitIsland(matrix, r - 1, c + 1, hsVisited);

            if (IsValidIndex(ref matrix, r + 1, c + 1))
                VisitIsland(matrix, r + 1, c + 1, hsVisited);

            if (IsValidIndex(ref matrix, r + 1, c - 1))
                VisitIsland(matrix, r + 1, c - 1, hsVisited);
        }

        private static bool IsValidIndex(ref int[,] matrix, int r, int c)
        {
            return r >= 0 && r < matrix.GetLength(0) && c >= 0 && c < matrix.GetLength(1) && matrix[r, c] == 1;
        }
    }
}

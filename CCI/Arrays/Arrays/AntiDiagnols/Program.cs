using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiDiagonals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> matrix = new List<List<int>>();
            matrix.Add(new List<int>() { 1, 2, 3 });
            matrix.Add(new List<int>() { 4, 5, 6 });
            matrix.Add(new List<int>() { 7, 8, 9 });
            var result = Diagonal(matrix);

            Console.ReadLine();
        }

        public static List<List<int>> Diagonal(List<List<int>> A)
        {
            if (A == null) return null;

            List<List<int>> lstResult = new List<List<int>>();
            HashSet<string> hsVisited = new HashSet<string>();

            for (int r = 0; r < A.Count; r++)
            {
                for (int c = 0; c < A[0].Count; c++)
                {
                    List<int> rowToBeAdded = new List<int>();
                    Visit(r, c, hsVisited, A, rowToBeAdded);
                    if (rowToBeAdded != null && rowToBeAdded.Count > 0)
                        lstResult.Add(rowToBeAdded);
                }
            }

            return lstResult;
        }

        public static List<int> Visit(int row, int col, HashSet<string> hsVisited, List<List<int>> A, List<int> rowToBeAdded)
        {
            string key = row + "|" + col;

            if (hsVisited.Contains(key) || !IsValidIndex(row, col, A))
            {
                return null;
            }

            rowToBeAdded.Add(A[row][col]);
            hsVisited.Add(key);
            Visit(row + 1, col - 1, hsVisited, A, rowToBeAdded);

            return rowToBeAdded;
        }

        public static bool IsValidIndex(int row, int col, List<List<int>> A)
        {
            if (A == null) return false;

            int rowCount = A.Count;
            int colCount = A[0].Count;

            return row >= 0 && row < rowCount &&
                col >= 0 && col < colCount;
        }
    }
}

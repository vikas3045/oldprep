using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPathSumInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> mat = new List<List<int>>()
            {
                new List<int>(){1, 3, 2},
                new List<int>(){4, 3, 1},
                new List<int>(){5, 6, 1 }
            };


            var result = MinPathSumInMatrix(mat);

            Console.ReadLine();
        }

        private static int MinPathSumInMatrix(List<List<int>> mat)
        {
            Dictionary<string, int> dicMemo = new Dictionary<string, int>();
            int rowCount = mat.Count;
            int colCount = mat[0].Count;
            return MinPathSumInMatrix(mat, rowCount - 1, colCount - 1, ref dicMemo);
        }

        public static int MinPathSumInMatrix(List<List<int>> mat, int curRow, int curCol, ref Dictionary<string, int> dicMemo)
        {
            if (curRow < 0 || curCol < 0)
                return int.MaxValue;

            var key = curRow + "|" + curCol;
            if (dicMemo.ContainsKey(key))
                return dicMemo[key];

            int result;
            if (curRow == 0 && curCol == 0)
                result = mat[curRow][curCol];
            else
                result = mat[curRow][curCol] +
                       Math.Min(
                           MinPathSumInMatrix(mat, curRow - 1, curCol, ref dicMemo),
                           MinPathSumInMatrix(mat, curRow, curCol - 1, ref dicMemo)
                       );

            dicMemo.Add(key, result);
            return result;
        }
    }
}

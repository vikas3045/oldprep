using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldMine
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat =
            {
                {10, 33, 13, 15},
                  {22, 21, 04, 1},
                  {5, 0, 2, 3},
                  {0, 6, 14, 2}
            };

            Console.WriteLine(GoldMine(mat));

            Console.ReadLine();
        }

        private static int GoldMine(int[,] mat)
        {
            int maxGold = int.MinValue;
            Dictionary<string, int> dicMemo = new Dictionary<string, int>();
            for (int row = 0; row < mat.GetLength(0); row++)
            {
                maxGold = Math.Max(maxGold, MaxGoldUtil(mat, row, 0, dicMemo));
            }

            return maxGold;
        }

        private static int MaxGoldUtil(int[,] mat, int curRow, int curCol, Dictionary<string, int> dicMemo)
        {
            if (!IsValidIndex(mat, curRow, curCol))
                return 0;

            var key = curRow + "|" + curCol;
            if (dicMemo.ContainsKey(key))
                return dicMemo[key];

            int curValue = mat[curRow, curCol];

            int maxFurther = int.MinValue;
            for (int i = -1; i <= 1; i++)
            {
                maxFurther = Math.Max(maxFurther, MaxGoldUtil(mat, curRow + i, curCol + 1, dicMemo));
            }

            dicMemo.Add(key, curValue + maxFurther);

            return curValue + maxFurther;
        }

        private static bool IsValidIndex(int[,] mat, int curRow, int curCol)
        {
            int rowSize = mat.GetLength(0);
            int colSize = mat.GetLength(1);

            return curRow >= 0 && curRow < rowSize
                && curCol >= 0 && curCol < colSize;
        }
    }
}

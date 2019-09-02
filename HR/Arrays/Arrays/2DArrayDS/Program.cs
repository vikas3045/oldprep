using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArrayDS
{
    class Program
    {
        // Complete the hourglassSum function below.
        static int hourglassSum(int[][] arr)
        {
            if (arr.Length < 1 || arr.Length > 6) return 0;
            else if (arr[0].Length == 0) return 0;

            int maxSum = int.MinValue;
            int rowCount = arr.Length;
            int colCount = arr[0].Length;

            for (int r = 0; r < rowCount - 2; r++)
            {
                for (int c = 1; c <= colCount - 2; c++)
                {
                    maxSum = Math.Max(maxSum, getHourGlassSum(r, c, arr));
                }
            }

            return (maxSum == int.MinValue) ? 0 : maxSum;
        }

        static int getHourGlassSum(int r, int c, int[][] arr)
        {
            int sum = arr[r + 1][c];

            for (int i = c - 1; i <= c + 1; i++)
            {
                sum += arr[r][i] + arr[r + 2][i];
            }

            return sum;
        }

        static void Main(string[] args)
        {
            int[][] arr = new int[6][];

            List<string> inp = new List<string>(){
                "-1 1 -1 0 0 0",
                "0 -1 0 0 0 0",
                "-1 -1 -1 0 0 0",
                "0 -9 2 -4 -4 0",
                "-7 0 0 -2 0 0",
                "0 0 -1 -2 -4 0" };
            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(inp[i].Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }


            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int[][] arr = new int[6][];

            //for (int i = 0; i < 6; i++)
            //{
            //    arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            //}

            int result = hourglassSum(arr);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();

            Console.ReadLine();
        }
    }
}

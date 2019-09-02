using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPalindromePartitioning
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "ababb";

            var result = MinCut(str);

            Console.WriteLine();
        }

        public static int MinCut(string A)
        {
            Result lstResult = new Result();
            lstResult.Val = int.MaxValue;
            Result currentSeq = new Result();
            Dictionary<int, int> dicMemo = new Dictionary<int, int>();
            GeneratePalindromeSequences(A, 0, currentSeq, lstResult, dicMemo);
            return lstResult.Val - 1;
        }

        public static void GeneratePalindromeSequences(string str, int curIndex, Result currentSeq, Result result, Dictionary<int, int> dicMemo)
        {
            if (dicMemo.ContainsKey(curIndex))
            {
                result.Val = dicMemo[curIndex];
            }

            if (curIndex >= str.Length)
            {
                result.Val = Math.Min(currentSeq.Val, result.Val);
                dicMemo.Add(curIndex, result.Val);                
                return;
            }

            for (int i = curIndex; i < str.Length; i++)
            {
                if (IsPalindrome(str, curIndex, i))
                {
                    Result subSeq = new Result();
                    subSeq.Val = currentSeq.Val + 1;

                    GeneratePalindromeSequences(str, i + 1, subSeq, result, dicMemo);
                }
            }
        }

        public class Result
        {
            public int Val { get; set; }
        }

        public static bool IsPalindrome(string str, int start, int end)
        {
            while (start < end)
            {
                if (str[start] != str[end])
                    return false;

                start++;
                end--;
            }

            return true;
        }
    }
}

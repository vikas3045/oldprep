using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "sunday", str2 = "saturday";

            Dictionary<string, int> dicMemo = new Dictionary<string, int>();
            Console.WriteLine(EditDistance(str1, str2, dicMemo));

            Console.ReadLine();
        }

        private static int EditDistance(string a, string b, Dictionary<string, int> dicMemo)
        {
            int aLength = a.Length;
            int bLength = b.Length;

            if (aLength == 0 && bLength == 0) return 0;
            else if (aLength == 0) return bLength;
            else if (bLength == 0) return aLength;

            string key = a + "|" + b;
            if (dicMemo.ContainsKey(key))
                return dicMemo[key];

            int editDistance = 0;

            if (a[aLength - 1] == b[bLength - 1])
                editDistance = EditDistance(a.Substring(0, aLength - 1), b.Substring(0, bLength - 1), dicMemo);
            else
                editDistance = 1 + Math.Min(EditDistance(a, b.Substring(0, bLength - 1), dicMemo),
                    Math.Min(EditDistance(a.Substring(0, aLength - 1), b.Substring(0, bLength - 1), dicMemo),
                    EditDistance(a.Substring(0, aLength - 1), b, dicMemo)));

            dicMemo.Add(key, editDistance);
            return editDistance;
        }

        public int EditDistance(string strA, string strB)
        {
            int aLength = strA.Length;
            int bLength = strB.Length;

            if (aLength == 0 && bLength == 0) return 0;
            else if (aLength == 0) return bLength;
            else if (bLength == 0) return aLength;

            if (strA[aLength - 1] == strB[bLength - 1])
                return EditDistance(strA.Substring(0, aLength - 1), strB.Substring(0, bLength - 1));
            else
            {
                int insertDist = EditDistance(strA, strB.Substring(0, bLength - 1));
                int replaceDist = EditDistance(strA.Substring(0, aLength - 1), strB.Substring(0, bLength - 1));
                int removeDist = EditDistance(strA.Substring(0, aLength - 1), strB);
                return 1 + Math.Min(insertDist, Math.Min(replaceDist, removeDist));
            }
        }
    }
}

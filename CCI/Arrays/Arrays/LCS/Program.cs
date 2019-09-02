using System;
using System.Collections.Generic;

namespace LCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string lcs = "";

            string a = "pales"; string b = "pale";

            Dictionary<string, string> dicMemo = new Dictionary<string, string>();
            Console.WriteLine(LCS_DP_HM(a, b, dicMemo));

            //if (Math.Abs(a.Length - b.Length) > 1)
            //    Console.WriteLine(false);
            //else
            //{
            //    lcs = LCS(a, b);
            //    if (Math.Abs(a.Length - lcs.Length) == 1 || Math.Abs(b.Length - lcs.Length) == 1)
            //        Console.WriteLine(true);
            //    else
            //        Console.WriteLine(false);
            //}
            //Console.WriteLine(lcs);

            //Console.WriteLine(IsOneOrZeroEditAway(a, b));

            Console.ReadLine();
        }

        private static bool IsOneOrZeroEditAway(string a, string b)
        {
            if (a == b) return true;

            int diff = Math.Abs(a.Length - b.Length);
            if (diff > 1) return false;

            return IsInsertAway(a, b) || IsRemoveOrReplaceAway(a, b);
        }

        private static bool IsRemoveOrReplaceAway(string a, string b)
        {
            int aLength = a.Length;
            int bLength = b.Length;

            if (aLength != bLength) return false;

            int charDiff = 0;
            for (int i = 0; i < aLength; i++)
            {
                if (a[i] != b[i])
                {
                    charDiff++;
                    if (charDiff > 1)
                        return false;
                }
            }

            return true;
        }

        private static bool IsInsertAway(string a, string b)
        {
            int aLength = a.Length;
            int bLength = b.Length;

            if (aLength == bLength) return false;

            char[] shortStr, longStr;
            if (aLength > bLength)
            {
                shortStr = b.ToCharArray();
                longStr = a.ToCharArray();
            }
            else
            {
                shortStr = a.ToCharArray();
                longStr = b.ToCharArray();
            }

            int insertionsRequired = 0;
            int j = 0;

            for (int i = 0; i < shortStr.Length; i++)
            {
                if (shortStr[i] != longStr[j])
                {
                    insertionsRequired++;
                    if (insertionsRequired > 1)
                        return false;
                    j++;
                }
                j++;
            }

            return true;
        }

        public static string LCS(string a, string b)
        {
            int aLength = a.Length;
            int bLength = b.Length;

            if (aLength == 0 || bLength == 0)
                return "";

            if (a[aLength - 1] == b[bLength - 1])
                return LCS(a.Substring(0, aLength - 1), b.Substring(0, bLength - 1)) + a[aLength - 1];
            else
            {
                string x = LCS(a, b.Substring(0, bLength - 1));
                string y = LCS(a.Substring(0, aLength - 1), b);
                return (x.Length > y.Length) ? x : y;
            }
        }

        public static string LCS_DP_HM(string a, string b, Dictionary<string, string> dicMemo)
        {
            if (String.IsNullOrWhiteSpace(a) || String.IsNullOrWhiteSpace(b))
                return string.Empty;

            int aLength = a.Length;
            int bLength = b.Length;
            string key = a + "|" + b;

            if (dicMemo.ContainsKey(key))
                return dicMemo[key];

            string result = string.Empty;

            if (a[aLength - 1] == b[bLength - 1])
                result = LCS_DP_HM(a.Substring(0, aLength - 1), b.Substring(0, bLength - 1), dicMemo) + a[aLength - 1];
            else
            {
                string lcsWithLastCharOfA = LCS_DP_HM(a, b.Substring(0, bLength - 1), dicMemo);
                string lcsWithoutLastCharOfA = LCS_DP_HM(a.Substring(0, aLength - 1), b, dicMemo);
                result = (lcsWithLastCharOfA.Length > lcsWithoutLastCharOfA.Length) ? lcsWithLastCharOfA : lcsWithoutLastCharOfA;
            }

            dicMemo.Add(key, result);
            return result;
        }
    }
}

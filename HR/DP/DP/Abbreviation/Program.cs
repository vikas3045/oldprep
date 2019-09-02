using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbreviation
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "EIZGAWWDCSJBBZPBYVNKRDEWVZnSSWZIw";
            string b = "EIZGAWWDCSJBBZPBYVNKRDEWVZSSWZI";
            var result = abbreviation(a, b);
        }

        // Complete the abbreviation function below.
        static string abbreviation(string a, string b)
        {
            Dictionary<string, bool> dicMemo = new Dictionary<string, bool>();
            return abbreviationHelper(a, b, dicMemo) ? "YES" : "NO";
        }

        static bool abbreviationHelper(string a, string b, Dictionary<string, bool> dicMemo)
        {
            int aLength = a.Length;
            int bLength = b.Length;

            if ((aLength == 0 && bLength == 0) || a == b)
                return true;
            else if (bLength == 0)
            {
                return !isUpperCharPresent(a);
            }
            else if (bLength > aLength)
                return false;

            var key = a + "|" + b;
            if (dicMemo.ContainsKey(key))
                return dicMemo[key];

            bool result = false;
            if (a[aLength - 1] == b[bLength - 1] || Char.ToUpper(a[aLength - 1]) == b[bLength - 1])
                result = abbreviationHelper(a.Substring(0, aLength - 1), b.Substring(0, bLength - 1), dicMemo);
            else if (Char.IsUpper(a[aLength - 1]))
                result = false;
            else
                result = abbreviationHelper(a.Substring(0, aLength - 1), b, dicMemo);

            dicMemo.Add(key, result);
            return result;
        }

        static bool isUpperCharPresent(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsUpper(a[i]))
                    return true;
            }

            return false;
        }
    }
}

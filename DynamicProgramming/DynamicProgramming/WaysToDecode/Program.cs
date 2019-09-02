using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaysToDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "12";

            var result = NumDecodings(input);

            Console.ReadLine();
        }

        public static int NumDecodings(string str)
        {
            var dic = GetEncodeMap();
            Dictionary<string, int> dicMemo = new Dictionary<string, int>();
            return NumDecodings(str, ref dic, ref dicMemo); ;
        }

        public static int NumDecodings(string str, ref Dictionary<string, char> dicEncodeMap, ref Dictionary<string, int> dicMemo)
        {
            if (str.Length == 0)
                return 1;
            
            if (dicMemo.ContainsKey(str))
                return dicMemo[str];

            // possibility from last 1 digit
            int result = 0;
            if (DecodingPossible(ref dicEncodeMap, str.Substring(str.Length - 1)))
            {
                result += NumDecodings(str.Substring(0, str.Length - 1), ref dicEncodeMap, ref dicMemo);
            }

            // possibility from last 2 digits
            if (str.Length >= 2 && DecodingPossible(ref dicEncodeMap, str.Substring(str.Length - 2)))
            {
                result += NumDecodings(str.Substring(0, str.Length - 2), ref dicEncodeMap, ref dicMemo);
            }

            dicMemo.Add(str, result);

            return result;
        }

        public static Dictionary<string, char> GetEncodeMap()
        {
            Dictionary<string, char> dicEncodeMap = new Dictionary<string, char>();
            char startIndex = 'A';
            for (int i = 1; i <= 26; i++)
            {
                dicEncodeMap.Add(i.ToString(), startIndex++);
            }

            return dicEncodeMap;
        }

        public static bool DecodingPossible(ref Dictionary<string, char> dicEncodeMap, string str)
        {
            return dicEncodeMap.ContainsKey(str);
        }
    }
}

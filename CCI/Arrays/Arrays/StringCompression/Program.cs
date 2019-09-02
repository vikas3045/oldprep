using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "aabbbccaa";
            Console.WriteLine(CompressString(str));
            Console.WriteLine(CompressStringAlt(str));
            Console.ReadLine();
        }

        private static string CompressStringAlt(string str)
        {
            if (String.IsNullOrWhiteSpace(str)) return String.Empty;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                int count = 1;

                while (i < str.Length - 1 && c == str[i + 1])
                {
                    count++;
                    i++;
                }

                sb.Append(c);
                sb.Append(count);
            }

            return (sb.Length < str.Length) ? sb.ToString() : str;
        }

        private static string CompressString(string str)
        {
            if (String.IsNullOrWhiteSpace(str)) return String.Empty;

            char[] charArr = str.ToCharArray();
            char temp = charArr[0];
            int repetitionCount = 1;
            StringBuilder result = new StringBuilder();

            for (int i = 1; i < charArr.Length; i++)
            {
                if (temp == charArr[i])
                {
                    repetitionCount++;
                }
                else
                {
                    result.Append(temp);
                    result.Append(repetitionCount);

                    temp = charArr[i];
                    repetitionCount = 1;
                }
            }

            result.Append(temp);
            result.Append(repetitionCount);
            string compressedString = result.ToString();
            if (str.Length > compressedString.Length) return compressedString;
            return str;
        }
    }
}

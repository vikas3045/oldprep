using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9_OldCellPhone
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 8733;
            List<string> lstResult = GetPossibleWords(input);

            Console.ReadLine();
        }

        private static List<string> GetPossibleWords(int input)
        {
            string str = input.ToString();
            List<string> lstResult = new List<string>();
            StringBuilder sbCurrent = new StringBuilder();
            GetPossibleWords(str, sbCurrent, 0, lstResult);

            return lstResult;
        }

        private static void GetPossibleWords(string str, StringBuilder sbCurrent, int curPos, List<string> lstResult)
        {
            if (curPos == str.Length)
            {
                if (IsValidWord(sbCurrent.ToString()))
                    lstResult.Add(sbCurrent.ToString());

                return;
            }

            List<char> lstPossibleChars = GetPossibleChars(str[curPos]);
            foreach (char c in lstPossibleChars)
            {
                StringBuilder sbSubWord = new StringBuilder(sbCurrent.ToString());
                sbSubWord.Append(c);
                GetPossibleWords(str, sbSubWord, curPos + 1, lstResult);
            }
        }

        private static bool IsValidWord(string v)
        {
            if (v == "tree" || v == "used")
                return true;
            else
                return false;
        }

        private static List<char> GetPossibleChars(char v)
        {
            Dictionary<char, List<char>> digitMap = new Dictionary<char, List<char>>() {
                { '0', new List<char>(){'0'}},
                { '1', new List<char>(){'1'}},
                { '2', new List<char>(){'a', 'b', 'c'}},
                { '3', new List<char>(){'d', 'e', 'f'}},
                { '4', new List<char>(){'g', 'h', 'i'}},
                { '5', new List<char>(){'j', 'k', 'l'}},
                { '6', new List<char>(){'m', 'n', 'o'}},
                { '7', new List<char>(){'p', 'q', 'r', 's'}},
                { '8', new List<char>(){'t', 'u', 'v'}},
                { '9', new List<char>(){'w', 'x', 'y', 'z'}},
            };

            return digitMap[v];
        }
    }
}

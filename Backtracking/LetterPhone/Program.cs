using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterPhone
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = LetterCombinations("2");

            Console.ReadLine();
        }

        public static List<string> LetterCombinations(string str)
        {
            Dictionary<string, List<string>> digitMap = new Dictionary<string, List<string>>() {
                { "0", new List<string>(){"0"}},
                { "1", new List<string>(){"1"}},
                { "2", new List<string>(){"a", "b", "c"}},
                { "3", new List<string>(){"d", "e", "f"}},
                { "4", new List<string>(){"g", "h", "i"}},
                { "5", new List<string>(){"j", "k", "l"}},
                { "6", new List<string>(){"m", "n", "o"}},
                { "7", new List<string>(){"p", "q", "r", "s"}},
                { "8", new List<string>(){"t", "u", "v"}},
                { "9", new List<string>(){"w", "x", "y", "z"}},
            };

            List<string> lstResult = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                StringBuilder currentCombination = new StringBuilder();
                GetCombination(str, digitMap, i, currentCombination, lstResult);
            }

            return lstResult;
        }

        private static void GetCombination(string str, Dictionary<string, List<string>> digitMap, int curIndex, StringBuilder currentCombination, List<string> lstResult)
        {
            if (curIndex > str.Length)
                return;
            else if (curIndex == str.Length)
            {
                if (currentCombination.Length == str.Length)
                    lstResult.Add(currentCombination.ToString());
                return;
            }

            List<string> possibleValues = digitMap[str[curIndex].ToString()];

            for (int i = 0; i < possibleValues.Count; i++)
            {
                StringBuilder subCombination = new StringBuilder(currentCombination.ToString());
                subCombination.Append(possibleValues[i]);
                GetCombination(str, digitMap, curIndex + 1, subCombination, lstResult);
            }
        }
    }
}

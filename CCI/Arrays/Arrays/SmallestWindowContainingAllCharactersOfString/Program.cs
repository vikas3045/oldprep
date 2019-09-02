using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestWindowContainingAllCharactersOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "this is a test string";
            string pattern = "tist";
            //string str = "75902135791158897";
            //string pattern = "159";
            //verified for output = 5791

            Console.WriteLine("Smallest window is : {0}", FindSubString(str, pattern));

            Console.ReadLine();
        }

        private static string FindSubString(string str, string pattern)
        {
            int strLength = str.Length;
            int patternLength = pattern.Length;

            // check if string's length is less than pattern's
            // length. If yes then no such window can exist
            if (strLength < patternLength)
            {
                Console.WriteLine("No such window exists");
                return "";
            }

            Dictionary<char, int> hashPat = new Dictionary<char, int>();
            Dictionary<char, int> hashStr = new Dictionary<char, int>();

            // store occurrence ofs characters of pattern
            for (int i = 0; i < patternLength; i++)
            {
                var key = pattern[i];
                if (hashPat.ContainsKey(key))
                    hashPat[key] += 1;
                else
                    hashPat.Add(key, 1);
            }

            int start = 0, start_index = -1, min_len = int.MaxValue;

            // start traversing the string
            // count of characters
            int count = 0;

            for (int j = 0; j < strLength; j++)
            {
                if (hashStr.ContainsKey(str[j]))
                    hashStr[str[j]] += 1;
                else
                    hashStr.Add(str[j], 1);


                // If string's char matches with pattern's char
                // then increment count
                if (hashPat.ContainsKey(str[j]) && hashStr[str[j]] <= hashPat[str[j]])
                    count++;


                // if all the characters are matched
                if (count == patternLength)
                {
                    // Try to minimize the window i.e., check if
                    // any character is occurring more no. of times
                    // than its occurrence  in pattern, if yes
                    // then remove it from starting and also remove
                    // the useless characters.
                    while (!hashPat.ContainsKey(str[start]) || hashStr[str[start]] > hashPat[str[start]])
                    {
                        if (!hashPat.ContainsKey(str[start]))
                        {
                            start++;
                        }
                        else if (hashStr[str[start]] > hashPat[str[start]])
                        {
                            hashStr[str[start]]--;
                            start++;
                        }
                    }

                    // update window size
                    int len_window = j - start + 1;
                    if (min_len > len_window)
                    {
                        min_len = len_window;
                        start_index = start;
                    }
                }
            }

            // If no window found
            if (start_index == -1)
            {
                Console.WriteLine("No such window exists");
                return "";
            }

            // Return substring starting from start_index
            // and length min_len
            return str.Substring(start_index, min_len);
        }
    }
}

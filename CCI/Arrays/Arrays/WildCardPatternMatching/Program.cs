using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildCardPatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "sheraab";
            string pattern = "?he*a*b";

            Console.WriteLine(SamePattern(text, pattern));
            //Console.WriteLine(IsMatching(text, pattern, text.Length - 1, pattern.Length - 1));
            Console.WriteLine(SamePattern(text, pattern, 0, 0));

            Console.ReadLine();
        }

        private static bool SamePattern(string text, string pattern, int curTextIndex, int curPatternIndex)
        {
            if (curTextIndex == text.Length && curPatternIndex == pattern.Length)
                return true;
            else if (curPatternIndex == pattern.Length)
                return false;
            else if (curTextIndex == text.Length)
            {
                while (curPatternIndex < pattern.Length)
                {
                    if (pattern[curPatternIndex] != '*')
                        return false;

                    return true;
                }
            }

            if (text[curTextIndex] == pattern[curPatternIndex] || pattern[curPatternIndex] == '?')
                return SamePattern(text, pattern, curTextIndex + 1, curPatternIndex + 1);
            else if (pattern[curPatternIndex] == '*')
                return SamePattern(text, pattern, curTextIndex + 1, curPatternIndex) ||
                    SamePattern(text, pattern, curTextIndex, curPatternIndex + 1);
            else
                return false;
        }

        private static bool SamePattern(string text, string pattern)
        {
            int s = 0; // cursor for traversal in str.
            int p = 0; // cursor for traversal in pattern.
            int starIdx = -1; // once we found a star, we want to record the place of the star.
            int match = 0; // once we found a star, we want to start to match the rest of pattern with str, starting from match; 
            //this is for remembering the place where we need to start.

            // we check and match every char for str.
            while (s < text.Length)
            {
                // 1. case 1: we are not currently at any *, 
                if (p < pattern.Length && (pattern[p] == text[s] || pattern[p] == '?'))
                {
                    p++;
                    s++;
                } // 2. case 2: we are currently at a '*'
                else if (p < pattern.Length && pattern[p] == '*')
                {
                    starIdx = p;
                    p++;
                    match = s;
                } // 3. case 3: they do not match, we do not currently at a *, but the last matched is a *
                else if (starIdx != -1)
                {
                    match++;
                    s = match;
                    p = starIdx + 1;
                } // 4. case 4: they do not match, do not currently at a *, and last matched is not a *, then the answer is false;
                else
                {
                    return false;
                }
            }

            // when we finish matching all characters in str, is pattern also finished? we could only allow '*' at the rest of pattern
            while (p < pattern.Length && pattern[p] == '*')
                p++;

            return p == pattern.Length;
        }
    }
}

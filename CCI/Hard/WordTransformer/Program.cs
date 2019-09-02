using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalWord = "damp";
            string targetWord = "like";
            string[] words = { "lamp", "limp", "lime", "like", "damp", "dame" };

            // Brute force approach to generate all words that are one edit away
            //var path = TransformationPath(originalWord, targetWord, words);

            // Efficient approach to generate only valid linked words
            var path1 = TransformationPathAlt(originalWord, targetWord, words);

            Console.ReadLine();
        }

        private static LinkedList<string> TransformationPathAlt(string originalWord, string targetWord, string[] words)
        {
            Dictionary<string, List<string>> dicWildcardToWordList = CreateWildcardToWordMap(words);
            HashSet<string> hsVisited = new HashSet<string>();
            return TransformationPathAlt(originalWord, targetWord, hsVisited, dicWildcardToWordList);
        }

        private static LinkedList<string> TransformationPathAlt(string originalWord, string targetWord, HashSet<string> hsVisited, Dictionary<string, List<string>> dicWildcardToWordList)
        {
            if (originalWord == targetWord)
            {
                LinkedList<string> path = new LinkedList<string>();
                path.AddFirst(originalWord);
                return path;
            }
            else if (hsVisited.Contains(originalWord))
                return null;

            hsVisited.Add(originalWord);
            List<string> lstOneEditAway = GetValidLinkedWords(originalWord, dicWildcardToWordList);

            foreach (var word in lstOneEditAway)
            {
                LinkedList<string> path = TransformationPathAlt(word, targetWord, hsVisited, dicWildcardToWordList);
                if (path != null)
                {
                    path.AddFirst(originalWord);
                    return path;
                }
            }

            return null;
        }

        private static Dictionary<string, List<string>> CreateWildcardToWordMap(string[] words)
        {
            Dictionary<string, List<string>> dicWildcardToWordList = new Dictionary<string, List<string>>();
            foreach (var word in words)
            {
                List<string> lstLinked = GetWildcardRoots(word);
                foreach (string linkedWord in lstLinked)
                {
                    if (!dicWildcardToWordList.ContainsKey(linkedWord))
                        dicWildcardToWordList.Add(linkedWord, new List<string>() { word });
                    else
                    {
                        var tempList = dicWildcardToWordList[linkedWord];
                        tempList.Add(word);
                        dicWildcardToWordList[linkedWord] = tempList;
                    }
                }
            }

            return dicWildcardToWordList;
        }

        private static List<string> GetWildcardRoots(string word)
        {
            List<string> words = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                string w = word.Substring(0, i) + "_" + word.Substring(i + 1);
                words.Add(w);
            }

            return words;
        }

        private static List<string> GetValidLinkedWords(string word, Dictionary<string, List<string>> dicWildcardToWordList)
        {
            List<string> lstWildcards = GetWildcardRoots(word);
            List<string> lstLinkedWords = new List<string>();
            foreach (var wildcard in lstWildcards)
            {
                List<string> words = dicWildcardToWordList[wildcard];
                foreach (var linkedWord in words)
                {
                    if (linkedWord != word)
                        lstLinkedWords.Add(linkedWord);
                }
            }

            return lstLinkedWords;
        }

        private static LinkedList<string> TransformationPath(string originalWord, string targetWord, string[] words)
        {
            HashSet<string> hsDictionary = SetUpDictionary(words);
            HashSet<string> hsVisited = new HashSet<string>();
            return TransformationPath(originalWord, targetWord, hsVisited, hsDictionary);
        }

        private static LinkedList<string> TransformationPath(string originalWord, string targetWord, HashSet<string> hsVisited, HashSet<string> hsDictionary)
        {
            if (originalWord == targetWord)
            {
                LinkedList<string> path = new LinkedList<string>();
                path.AddFirst(originalWord);
                return path;
            }
            else if (hsVisited.Contains(originalWord) || !hsDictionary.Contains(originalWord))
                return null;

            hsVisited.Add(originalWord);
            List<string> lstOneEditAway = GetWordsOneEditAway(originalWord, hsDictionary);

            foreach (var word in lstOneEditAway)
            {
                LinkedList<string> path = TransformationPath(word, targetWord, hsVisited, hsDictionary);
                if (path != null)
                {
                    path.AddFirst(originalWord);
                    return path;
                }
            }

            return null;
        }

        private static List<string> GetWordsOneEditAway(string word, HashSet<string> hsDictionary)
        {
            List<string> lstResult = new List<string>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    string w = word.Substring(0, i) + c + word.Substring(i + 1);
                    lstResult.Add(w);
                }
            }

            return lstResult;
        }

        private static HashSet<string> SetUpDictionary(string[] words)
        {
            HashSet<string> hsDic = new HashSet<string>();
            foreach (string word in words)
            {
                hsDic.Add(word.ToLower());
            }

            return hsDic;
        }
    }
}

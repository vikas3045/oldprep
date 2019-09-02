using System;
using System.Collections.Generic;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "vVika shrm123$";
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            Console.WriteLine("IsUnique: " + IsUnique(str));
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            watch.Restart();
            Console.WriteLine("IsUniqueHashSet: " + IsUniqueHashSet(str));
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            watch.Restart();
            Console.WriteLine("IsUniqueWithoutDS: " + IsUniqueWithoutDS(str));
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            Console.ReadLine();
        }

        private static bool IsUniqueHashSet(string str)
        {
            HashSet<char> charSet = new HashSet<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (!charSet.Contains(str[i]))
                {
                    charSet.Add(str[i]);
                }
                else
                    return false;
            }

            return true;
        }

        public static bool IsUnique(string str)
        {
            if (str.Length > 128) return false;

            bool[] charSet = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (charSet[val])
                {
                    return false;
                }

                charSet[val] = true;
            }

            return true;
        }

        public static bool IsUniqueWithoutDS(string str)
        {
            char[] charSet = str.ToCharArray();
            Array.Sort<char>(charSet);

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (charSet[i] == charSet[i + 1])
                    return false;
            }
            return true;
        }
    }
}

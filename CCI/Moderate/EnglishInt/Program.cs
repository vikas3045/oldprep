using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishInt
{
    class Program
    {
        public static string[] smalls = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight","Nine","Ten","Eleven",
            "Twelve", "Thirteen","Fourteen","Fifteen","Sixteen", "Seventeen","Eighteen","Nineteen"};
        public static string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        public static string[] bigs = { "", "Thousand", "Million", "Billion" };
        public static string hundred = "Hundred";
        public static string negative = "Negative";

        static void Main(string[] args)
        {
            int num = 19323984;

            Console.WriteLine(Convert(num));

            Console.ReadLine();
        }

        public static string Convert(int num)
        {
            if (num == 0)
                return smalls[0];
            else if (num < 0)
                return negative + " " + Convert(-1 * num);

            LinkedList<string> parts = new LinkedList<string>();
            int chunkCount = 0;

            while (num > 0)
            {
                if (num % 1000 != 0)
                {
                    string chunk = ConvertChunk(num % 1000) + bigs[chunkCount];
                    parts.AddFirst(chunk);
                }

                num /= 1000; // shift chunk
                chunkCount++;
            }

            return ListToString(parts);
        }

        private static string ConvertChunk(int number)
        {
            LinkedList<string> parts = new LinkedList<string>();

            // Convert hundreds place
            if (number >= 100)
            {
                parts.AddLast(smalls[number / 100]);
                parts.AddLast(hundred);
                number %= 100;
            }

            // Convert tens place
            if (number >= 10 && number <= 19)
            {
                parts.AddLast(smalls[number]);
            }
            else if (number >= 20)
            {
                parts.AddLast(tens[number / 10]);
                number %= 10;
            }

            // Convert ones place
            if (number >= 1 && number <= 9)
            {
                parts.AddLast(smalls[number]);
            }

            return ListToString(parts);
        }

        private static string ListToString(LinkedList<string> parts)
        {
            StringBuilder sb = new StringBuilder();
            var current = parts.First;
            while (current != null)
            {
                sb.Append(current.Value + " ");
                current = current.Next;
            }

            return sb.ToString();
        }
    }
}

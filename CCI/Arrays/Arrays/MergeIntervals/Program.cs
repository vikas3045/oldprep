using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Interval> lstIntervals = new List<Interval>()
            {
                {new Interval(1,3) },
                {new Interval(2,4) },
                {new Interval(5,7) },
                {new Interval(6,8) }
            };

            List<Interval> lstMerged = MergeIntervals(lstIntervals);

            Console.ReadLine();
        }

        private static List<Interval> MergeIntervals(List<Interval> lstIntervals)
        {
            if (lstIntervals.Count == 0) return null;

            List<Interval> lstResult = new List<Interval>();
            lstIntervals = lstIntervals.OrderBy(i => i.Start).ToList();
            Stack<Interval> stack = new Stack<Interval>();
            foreach (Interval i in lstIntervals)
            {
                if (stack.Count > 0)
                {
                    if (i.Start <= stack.Peek().End)
                    {
                        var tempInterval = stack.Pop();
                        tempInterval.End = i.End;
                        stack.Push(tempInterval);
                    }
                    else
                    {
                        stack.Push(i);
                    }
                }
                else
                {
                    stack.Push(i);
                }
            }

            while (stack.Count > 0)
                lstResult.Add(stack.Pop());

            return lstResult;
        }
    }

    internal class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}

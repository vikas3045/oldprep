using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTower
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                {new Person(){Height = 65, Weight = 100} },
                {new Person(){Height = 70, Weight = 150} },
                {new Person(){Height = 56, Weight = 90} },
                {new Person(){Height = 75, Weight = 190} },
                {new Person(){Height = 60, Weight = 95} },
                {new Person(){Height = 68, Weight = 110} }
            };

            var result = LongestPossibleTower(people);

            Console.ReadLine();
        }

        private static int LongestPossibleTower(List<Person> people)
        {
            people = people.OrderBy(p => p.Height).ToList();

            Dictionary<int, int> dicMemo = new Dictionary<int, int>();

            return LongestPossibleTowerHelper(people, -1, 0, dicMemo);
        }

        private static int LongestPossibleTowerHelper(List<Person> people, int prev, int curPos, Dictionary<int, int> dicMemo)
        {
            if (curPos >= people.Count)
                return 0;

            if (dicMemo.ContainsKey(curPos))
                return dicMemo[curPos];

            int taken = 0;
            if (prev < people[curPos].Weight)
                taken = 1 + LongestPossibleTowerHelper(people, people[curPos].Weight, curPos + 1, dicMemo);

            int notTaken = LongestPossibleTowerHelper(people, people[curPos].Weight, curPos + 1, dicMemo);

            int result = Math.Max(taken, notTaken);

            dicMemo.Add(curPos, result);

            return result;
        }

        public class Person
        {
            public int Height { get; set; }
            public int Weight { get; set; }
        }
    }
}

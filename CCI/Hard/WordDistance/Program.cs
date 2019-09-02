using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDistance
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        //PreComputation
        public Dictionary<string, List<int>> GetWordLocations(string[] words)
        {
            Dictionary<string, List<int>> locations = new Dictionary<string, List<int>>();
            for (int i = 0; i < words.Length; i++)
            {
                if (!locations.ContainsKey(words[i]))
                    locations.Add(words[i], new List<int>() { i });
                else
                {
                    var lst = locations[words[i]];
                    lst.Add(i);
                    locations[words[i]] = lst;
                }
            }

            return locations;
        }

        //Better approach if operation needs to happen multiple times
        public LocationPair FindClosest(string word1, string word2, Dictionary<string, List<int>> locations)
        {
            List<int> locations1 = locations[word1];
            List<int> locations2 = locations[word2];
            return FindMinDistancePair(locations1, locations2);
        }

        private LocationPair FindMinDistancePair(List<int> arr1, List<int> arr2)
        {
            if (arr1 == null || arr2 == null || arr1.Count == 0 || arr2.Count == 0)
                return null;

            int index1 = 0;
            int index2 = 0;
            LocationPair best = new LocationPair(arr1[0], arr2[0]);
            LocationPair current = new LocationPair(arr1[0], arr2[0]);

            while (index1 < arr1.Count && index2 < arr2.Count)
            {
                current.SetLocations(arr1[index1], arr2[index2]);
                best.UpdateWithMin(current);
                if (current.Location1 < current.Location2)
                    index1++;
                else
                    index2++;
            }

            return best;
        }

        public LocationPair FindClosest(string[] words, string word1, string word2)
        {
            LocationPair best = new LocationPair(-1, -1);
            LocationPair current = new LocationPair(-1, -1);

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (word == word1)
                {
                    current.Location1 = i;
                    best.UpdateWithMin(current);
                }
                else if (word == word2)
                {
                    current.Location2 = i;
                    best.UpdateWithMin(current);
                }
            }

            return best;
        }

        public class LocationPair
        {
            public int Location1 { get; set; }
            public int Location2 { get; set; }
            public int Distance
            {
                get
                {
                    return Math.Abs(Location1 - Location2);
                }
            }

            public LocationPair(int first, int second)
            {
                SetLocations(first, second);
            }

            public void SetLocations(int first, int second)
            {
                Location1 = first;
                Location2 = second;
            }

            public void SetLocations(LocationPair loc)
            {
                SetLocations(loc.Location1, loc.Location2);
            }

            public void UpdateWithMin(LocationPair loc)
            {
                if (!IsValid() || loc.Distance < Distance)
                {
                    SetLocations(loc);
                }
            }

            private bool IsValid()
            {
                return Location1 >= 0 && Location2 >= 0;
            }
        }
    }
}

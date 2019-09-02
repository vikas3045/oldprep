using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person{Birth = 1904, Death = 1940},
                new Person{Birth = 1905, Death = 1945},
                new Person{Birth = 1906, Death = 1946},
                new Person{Birth = 1907, Death = 1940},
                new Person{Birth = 1908, Death = 1956},
                new Person{Birth = 1909, Death = 1939},
                new Person{Birth = 1909, Death = 1910}
            };

            var result = GetYearWithMaxLivingPeople(people);

            Console.ReadLine();
        }

        private static int GetYearWithMaxLivingPeople(List<Person> people)
        {
            List<int> lstBirth = new List<int>();
            List<int> lstDeath = new List<int>();

            foreach (var person in people)
            {
                lstBirth.Add(person.Birth);
                lstDeath.Add(person.Death);
            }

            lstBirth.Sort();
            lstDeath.Sort();

            int currentAlive = 0;
            int maxAlive = 0;
            int maxAliveYear = 0;
            int bIdx = 0;
            int dIdx = 0;

            while (bIdx < lstBirth.Count && dIdx < lstDeath.Count)
            {
                if (lstBirth[bIdx] <= lstDeath[dIdx])
                {
                    currentAlive++;
                    if (maxAlive < currentAlive)
                    {
                        maxAlive = currentAlive;
                        maxAliveYear = lstBirth[bIdx];
                    }
                    bIdx++;
                }
                else
                {
                    currentAlive--;
                    dIdx++;
                }
            }

            return maxAliveYear;
        }

        class Person
        {
            public int Birth { get; set; }
            public int Death { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrityProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = {
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 1, 0 }
            };

            Person celeb = FindCelebrity(arr);
            Console.Write("(" + celeb.X + "," + celeb.Y + ")");

            Console.ReadLine();
        }

        private static Person FindCelebrity(int[,] arr)
        {
            Person celeb = new Person(-1);
            List<Person> lstPerson = new List<Person>();

            for (int r = 0; r < arr.GetLength(0); r++)
            {
                lstPerson.Add(new Person(r));
            }

        }

        public class Person
        {
            public int ID { get; set; }

            public Person(int id)
            {
                ID = id;
            }
        }
    }
}

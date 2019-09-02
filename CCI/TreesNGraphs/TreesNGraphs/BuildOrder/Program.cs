using System;
using System.Collections.Generic;

namespace BuildOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] projects = { "a", "b", "c", "d", "e", "f" };

            string[,] dependencies = new string[,]
            {
                {"a","d" },
                //{"d","a" }, // to test cyclic dependency behaviour
                {"f","b" },
                {"b","d" },
                {"f","a" },
                {"d","c" }
            };

            HashSet<string> hsBuilding = new HashSet<string>();
            HashSet<string> hsBuilt = new HashSet<string>();
            Stack<string> stackBuildOrder = new Stack<string>();

            foreach (var project in projects)
            {
                hsBuilding.Add(project);
                Build(project, dependencies, stackBuildOrder, hsBuilt, hsBuilding);
            }

            while (stackBuildOrder.Count > 0)
                Console.Write(stackBuildOrder.Pop() + " ");

            Console.ReadLine();
        }

        public static void Build(string project, string[,] dependencies, Stack<string> stackBuildOrder, HashSet<string> hsBuilt, HashSet<string> hsBuilding)
        {
            if (hsBuilt.Contains(project))
                return;

            // Build dependencies
            foreach (var child in GetDependentProjects(project, dependencies))
            {
                if (hsBuilding.Contains(child))
                    throw new Exception("Cyclic dependency");
                else
                {
                    hsBuilding.Add(child);
                    Build(child, dependencies, stackBuildOrder, hsBuilt, hsBuilding);
                }
            }

            hsBuilding.Remove(project);
            hsBuilt.Add(project);
            stackBuildOrder.Push(project);
        }

        private static List<string> GetDependentProjects(string project, string[,] dependencies)
        {
            List<string> lstDependentProjects = new List<string>();

            for (int r = 0; r < dependencies.GetLength(0); r++)
            {
                if (project == dependencies[r, 1])
                    lstDependentProjects.Add(dependencies[r, 0]);
            }

            return lstDependentProjects;
        }
    }
}

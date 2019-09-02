using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphAdjL graph = new GraphAdjL(4);

            for (int i = 0; i < 4; i++)
                graph.AddVertex(i);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);

            DFS(graph, 1);

            Console.ReadLine();
        }

        private static void DFS(GraphAdjL graph, int vertex)
        {
            HashSet<int> hsVisited = new HashSet<int>();
            Stack<int> stack = new Stack<int>();

            stack.Push(vertex);

            while (stack.Count > 0)
            {
                var temp = stack.Pop();

                if (!hsVisited.Contains(temp))
                {
                    Console.Write(temp + " ");
                    hsVisited.Add(temp);
                }

                foreach (int neighbour in graph.GetAdjacent(temp))
                {
                    if (!hsVisited.Contains(neighbour))
                        stack.Push(neighbour);
                }
            }
        }
    }
}

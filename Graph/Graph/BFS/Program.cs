using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphAdjL graph = new GraphAdjL(4);

            for (int i = 0; i < 4; i++)
                graph.AddVertex(i);

            //graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);

            BFS(graph, 1);

            Console.ReadLine();
        }

        public static void BFS(GraphAdjL graph, int vertex)
        {
            HashSet<int> hsVisited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            hsVisited.Add(vertex);
            queue.Enqueue(vertex);

            while (queue.Count > 0)
            {
                int temp = queue.Dequeue();

                Console.Write(temp + " ");                

                foreach (var neighbour in graph.GetAdjacent(temp))
                {
                    if (!hsVisited.Contains(neighbour))
                    {
                        hsVisited.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }


    }
}

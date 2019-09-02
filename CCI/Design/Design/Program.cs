using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Person> people = new Dictionary<int, Person>();

            Person ram = new Person(1, "Ram");
            Person ms = new Person(2, "MS");
            Person bob = new Person(3, "Bob");
            Person dhawan = new Person(4, "Dhawan");
            Person tony = new Person(5, "Tony");

            ram.AddFriend(ms.ID);
            ram.AddFriend(bob.ID);

            ms.AddFriend(ram.ID);
            ms.AddFriend(bob.ID);
            ms.AddFriend(dhawan.ID);
            ms.AddFriend(tony.ID);

            bob.AddFriend(ram.ID);
            bob.AddFriend(ms.ID);

            dhawan.AddFriend(ms.ID);

            tony.AddFriend(ms.ID);

            people.Add(ram.ID, ram);
            people.Add(ms.ID, ms);
            people.Add(bob.ID, bob);
            people.Add(dhawan.ID, dhawan);
            people.Add(tony.ID, tony);

            var shortestPath = FindPathBiBFS(people, ram.ID, dhawan.ID);

            var current = shortestPath.First;
            while (current != null)
            {
                if (current.Next != null)
                    Console.Write(current.Value.Info + " -> ");
                else
                    Console.Write(current.Value.Info);

                current = current.Next;
            }

            Console.ReadLine();
        }

        public static LinkedList<Person> FindPathBiBFS(Dictionary<int, Person> people, int source, int destination)
        {
            BFSData sourceData = new BFSData(people[source]);
            BFSData destData = new BFSData(people[destination]);

            while (!sourceData.IsFinished() && !destData.IsFinished())
            {
                // search out from source
                Person collision = SearchLevel(people, sourceData, destData);
                if (collision != null)
                {
                    return MergePaths(sourceData, destData, collision.ID);
                }

                // search out from destination
                collision = SearchLevel(people, destData, sourceData);
                if (collision != null)
                {
                    return MergePaths(sourceData, destData, collision.ID);
                }
            }

            return null;
        }

        private static LinkedList<Person> MergePaths(BFSData bfs1, BFSData bfs2, int connection)
        {
            PathNode end1 = bfs1.visited[connection]; // end1 --> source
            PathNode end2 = bfs2.visited[connection]; // end2 --> dest

            LinkedList<Person> pathOne = end1.Collapse(false);
            LinkedList<Person> pathTwo = end2.Collapse(true); //reverse

            pathTwo.RemoveFirst(); // remove connection

            var result = new LinkedList<Person>(pathOne.Concat(pathTwo));

            return result;
        }

        // Search one level and return collision, if any
        private static Person SearchLevel(Dictionary<int, Person> people, BFSData primary, BFSData secondary)
        {
            // We only want to search one level at a time. Count how many nodes are currently in the 
            // primary's level and only do that many nodes. We'll continue to add nodes to the end.
            int count = primary.toVisit.Count;

            for (int i = 0; i < count; i++)
            {
                // Pull out first node 
                PathNode pathNode = primary.toVisit.Dequeue();
                int personID = pathNode.GetPerson().ID;

                // Check if it's already been visited
                if (secondary.visited.ContainsKey(personID))
                    return pathNode.GetPerson();

                // Add friends to queue
                Person person = pathNode.GetPerson();
                List<int> friends = person.GetFriends();
                foreach (var friendID in friends)
                {
                    if (!primary.visited.ContainsKey(friendID))
                    {
                        Person friend = people[friendID];
                        PathNode next = new PathNode(friend, pathNode);
                        primary.visited.Add(friendID, next);
                        primary.toVisit.Enqueue(next);
                    }
                }
            }

            return null;
        }

        class BFSData
        {
            public Queue<PathNode> toVisit = new Queue<PathNode>();
            public Dictionary<int, PathNode> visited = new Dictionary<int, PathNode>();

            public BFSData(Person root)
            {
                PathNode sourcePath = new PathNode(root, null);
                toVisit.Enqueue(sourcePath);
                visited.Add(root.ID, sourcePath);
            }

            public bool IsFinished()
            {
                return toVisit.Count == 0;
            }
        }
    }
}

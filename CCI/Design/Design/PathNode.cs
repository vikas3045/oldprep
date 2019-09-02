using System.Collections.Generic;

namespace Design
{
    public class PathNode
    {
        private Person person = null;
        private PathNode previousNode = null;

        public PathNode(Person p, PathNode previous)
        {
            person = p;
            previousNode = previous;
        }

        public Person GetPerson()
        {
            return person;
        }

        public LinkedList<Person> Collapse(bool startsWithoutRoot)
        {
            LinkedList<Person> path = new LinkedList<Person>();
            PathNode node = this;

            while (node != null)
            {
                if (startsWithoutRoot)
                    path.AddLast(node.person);
                else
                    path.AddFirst(node.person);

                node = node.previousNode;
            }

            return path;
        }
    }
}
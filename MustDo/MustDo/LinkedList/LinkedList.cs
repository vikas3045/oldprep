using System;
namespace LinkedList
{
    public class ListNode
    {
        public int Data { get; set; }
        public ListNode Next { get; set; }
        public ListNode() { }
        public ListNode(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public class ListNodeDLL
    {
        public int Data { get; set; }
        public ListNodeDLL Next { get; set; }
        public ListNodeDLL Random { get; set; }
        public ListNodeDLL() { }
        public ListNodeDLL(int data)
        {
            Data = data;
            Next = null;
            Random = null;
        }
    }

    public class MultiNode
    {
        public int Data { get; set; }
        public MultiNode Right { get; set; }
        public MultiNode Down { get; set; }

        public MultiNode() { }
        public MultiNode(int data)
        {
            Data = data;
        }
    }

    public class LinkedList
    {
        private int _length;

        public int Length
        {
            get
            {
                return _length;
            }

            private set
            {
                _length = value;
            }
        }

        public ListNode Head { get; set; }

        public LinkedList()
        {
            Head = null;
            Length = 0;
        }

        public void AddFirst(ListNode node)
        {
            if (Head == null)
            {
                Head = node;
                Length++;
            }
            else
            {
                node.Next = Head;
                Head = node;
                Length++;
            }
        }

        public void AddLast(ListNode node)
        {
            if (Head == null)
            {
                Head = node;
                Length++;
            }
            else
            {
                var currentNode = Head;

                while (currentNode != null)
                {
                    if (currentNode.Next == null)
                    {
                        currentNode.Next = node;
                        Length++;

                        break;
                    }

                    currentNode = currentNode.Next;
                }
            }
        }

        public void Print()
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                Console.Write(currentNode.Data + " ");
                currentNode = currentNode.Next;
            }
            Console.WriteLine();
        }

        //public void Insert(int data, int position)
        //{
        //    //Fix position
        //    if (position < 0)
        //        position = 0;
        //    else if (position > Length - 1)
        //        position = Length - 1;

        //    if (Head == null)
        //    {
        //        Head = new ListNode() { Data = data };
        //        Length++;
        //    }
        //    else
        //    {
        //        for (int i = 1; i <= Length; i++)
        //        {
        //            if (i == position)
        //            {

        //            }
        //        }
        //    }
        //}
    }
}

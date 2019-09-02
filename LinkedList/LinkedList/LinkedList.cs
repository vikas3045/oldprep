using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class ListNode
    {
        public int Data { get; set; }
        public ListNode Next { get; set; }
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

        public void InsertAtBegining(ListNode node)
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

        public void InsertAtEnd(ListNode node)
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

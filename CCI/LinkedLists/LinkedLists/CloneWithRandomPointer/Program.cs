using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWithRandomPointer
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNodeDLL node1 = new ListNodeDLL(1);
            ListNodeDLL node2 = new ListNodeDLL(2);
            ListNodeDLL node3 = new ListNodeDLL(3);
            ListNodeDLL node4 = new ListNodeDLL(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node1.Random = node4;
            node2.Random = node1;
            node3.Random = node1;
            //node4.Random = node1;

            ListNodeDLL copy = CloneWithRandomPointer(node1);
            //ListNodeDLL copy = CloneWithConstantSpace(node1);

            //node1 = null;
            //node2 = null;
            //node3 = null;
            //node4 = null;

            Console.ReadLine();
        }

        private static ListNodeDLL CloneWithRandomPointer(ListNodeDLL head)
        {
            if (head == null) return null;

            ListNodeDLL origCurrent = head;
            ListNodeDLL cloneCurrent = null;
            Dictionary<ListNodeDLL, ListNodeDLL> dictionary = new Dictionary<ListNodeDLL, ListNodeDLL>();

            while (origCurrent != null)
            {
                dictionary.Add(origCurrent, new ListNodeDLL(origCurrent.Data));
                origCurrent = origCurrent.Next; ;
            }

            origCurrent = head;

            while (origCurrent != null)
            {
                ListNodeDLL next = origCurrent.Next;

                cloneCurrent = dictionary[origCurrent];
                cloneCurrent.Next = origCurrent.Next != null ? dictionary[origCurrent.Next] : null;
                cloneCurrent.Random = origCurrent.Random != null ? dictionary[origCurrent.Random] : null;

                origCurrent = next;
            }

            //change start
            //// Below code also works fine
            //foreach (var pair in dictionary)
            //{
            //    var orig = pair.Key;
            //    var copy = pair.Value;
            //    copy.Next = orig.Next != null ? dictionary[orig.Next] : null;
            //    copy.Random = orig.Random != null ? dictionary[orig.Random] : null;
            //}
            //change end

            return dictionary[head];
        }

        public static ListNodeDLL CloneWithConstantSpace(ListNodeDLL head)
        {
            if (head == null) return null;

            ListNodeDLL origCurrent = head;
            while (origCurrent != null)
            {
                ListNodeDLL next = origCurrent.Next;

                ListNodeDLL copiedNode = new ListNodeDLL(origCurrent.Data);
                origCurrent.Next = copiedNode;
                copiedNode.Next = next;

                origCurrent = next;
            }

            origCurrent = head;

            ListNodeDLL copyHead = origCurrent.Next;

            while (origCurrent != null)
            {
                ListNodeDLL next = origCurrent.Next.Next;

                if (origCurrent.Random != null)
                    origCurrent.Next.Random = origCurrent.Random.Next;
                else
                    origCurrent.Next.Random = null;

                if (origCurrent.Next.Next != null)
                    origCurrent.Next.Next = next.Next;
                origCurrent.Next = next;

                origCurrent = next;
            }

            return copyHead;
        }
    }
}

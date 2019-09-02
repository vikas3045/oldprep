using System;
using System.Collections.Generic;

namespace NextGreaterElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = { 11, 13, 3, 21 };
            List<int> lstInput = new List<int>() { 11, 13, 3, 21 };

            //PrintNextGreaterElement(inputArr);
            Console.WriteLine();
            NextGreaterElement(inputArr);

            Console.WriteLine();
            NGE(inputArr);
            Console.WriteLine();
            var lst = nextGreater(lstInput);
            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public static List<int> nextGreater(List<int> A)
        {
            Dictionary<int, int> dicResult = new Dictionary<int, int>();

            Stack<int> stack = new Stack<int>();
            stack.Push(-1);

            for (int i = A.Count - 1; i >= 0; i--)
            {
                if (A[i] < stack.Peek())
                {
                    dicResult.Add(A[i], stack.Peek());
                    stack.Push(A[i]);
                }
                else
                {
                    while (stack.Count > 1 && A[i] >= stack.Peek())
                    {
                        stack.Pop();
                    }

                    dicResult.Add(A[i], stack.Peek());
                    stack.Push(A[i]);
                }
            }

            List<int> lstResult = new List<int>();

            for (int i = 0; i < A.Count; i++)
                lstResult.Add(dicResult[A[i]]);
            return lstResult;
        }

        private static void NGE(int[] arr)
        {
            int n = arr.Length;
            if (n == 0) return;

            Stack<int> stack = new Stack<int>();
            Console.WriteLine(arr[n - 1] + " --> " + -1);
            stack.Push(arr[n - 1]);

            for (int i = n - 2; i >= 0; i--)
            {
                if (arr[i] < stack.Peek())
                {
                    Console.WriteLine(arr[i] + " --> " + stack.Peek());
                }
                else
                {
                    while (stack.Count > 0 && arr[i] > stack.Peek())
                    {
                        stack.Pop();
                    }

                    if (stack.Count > 0)
                        Console.WriteLine(arr[i] + " --> " + stack.Pop());
                    else
                        Console.WriteLine(arr[i] + " --> " + -1);
                }

                stack.Push(arr[i]);
            }
        }

        private static void NextGreaterElement(int[] arr)
        {
            int n = arr.Length;
            if (n == 0)
                return;

            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> dicResult = new Dictionary<int, int>();

            stack.Push(arr[0]);

            for (int i = 1; i <= n - 1; i++)
            {
                int next = arr[i];
                while (stack.Count > 0 && stack.Peek() < next)
                {
                    dicResult.Add(stack.Pop(), next);
                }
                stack.Push(next);
            }

            while (stack.Count > 0)
                dicResult.Add(stack.Pop(), -1);

            for (int i = 0; i <= n - 1; i++)
            {
                int key = arr[i];
                int value = dicResult[key];
                Console.WriteLine(key + " --> " + value);
            }
        }

        private static void PrintNextGreaterElement(int[] inputArr)
        {
            int i = 0;
            int n = inputArr.Length;
            Stack<int> s = new Stack<int>();
            int element, next;

            /* Push the first element to Stack<int> */
            s.Push(inputArr[0]);

            // iterate for rest of the elements
            for (i = 1; i < n; i++)
            {
                next = inputArr[i];

                if (s.Count > 0)
                {

                    // if Stack<int> is not empty, then 
                    // pop an element from Stack<int>
                    element = s.Pop();

                    /* If the popped element is smaller than 
                       next, then a) print the pair b) keep 
                       popping while elements are smaller and 
                       Stack<int> is not empty */
                    while (element < next)
                    {
                        Console.WriteLine(element + " --> " + next);
                        if (s.Count == 0)
                            break;
                        element = s.Pop();
                    }

                    /* If element is greater than next, then 
                       Push the element back */
                    if (element > next)
                        s.Push(element);
                }

                /* Push next to Stack<int> so that we can find next
                   greater for it */
                s.Push(next);
            }

            /* After iterating over the loop, the remaining 
               elements in Stack<int> do not have the next greater 
               element, so print -1 for them */
            while (s.Count > 0)
            {
                element = s.Pop();
                next = -1;
                Console.WriteLine(element + " --> " + next);
            }
        }
    }
}

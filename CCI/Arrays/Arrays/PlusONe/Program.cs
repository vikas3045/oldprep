using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusONe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstInput = new List<int>() { 9, 9, 9, 9, 9 };

            var result = PlusOne(lstInput);

            Console.ReadLine();
        }
        public static List<int> PlusOne(List<int> A)
        {
            if (A == null)
                return null;

            Carry carry = new Carry();
            PlusOneHelper(A, A.Count - 1, carry);

            List<int> lstResult = new List<int>();
            if (carry.val > 0)
            {
                List<int> withCarry = new List<int>();
                withCarry.Add(carry.val);
                withCarry.AddRange(A);
                lstResult = RemoveZeros(withCarry);
            }
            else
                lstResult = RemoveZeros(A);

            return lstResult;
        }

        public static void PlusOneHelper(List<int> A, int curIndex, Carry carry)
        {
            if (curIndex < 0)
            {
                return;
            }

            int addedValue;
            if (curIndex == A.Count - 1)
                addedValue = A[curIndex] + carry.val + 1;
            else
                addedValue = A[curIndex] + carry.val;

            carry.val = (addedValue > 9) ? 1 : 0;
            A[curIndex] = addedValue % 10;

            PlusOneHelper(A, curIndex - 1, carry);
        }

        public static List<int> RemoveZeros(List<int> lst)
        {
            if (lst.Count == 0) return null;
            List<int> lstResult = new List<int>();
            int count = 0;
            while (count < lst.Count && lst[count] == 0)
            {
                count++;
            }
            if (count > 0)
            {
                for (int i = count; i < lst.Count; i++)
                    lstResult.Add(lst[i]);
                return lstResult;
            }
            else
                return lst;
        }

        public class Carry
        {
            public int val;
        }
    }
}

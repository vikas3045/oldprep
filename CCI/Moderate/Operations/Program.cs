using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var sResult = Subtract(0, 10);
            var mResult = Multiply(7, -6);
            var dResult = Divide(1, 5);

            Console.ReadLine();
        }

        public static int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            else if (a == 0)
                return 0;

            int absA = Abs(a);
            int absB = Abs(b);

            int result = 0;
            int product = 0;

            while (product + absB <= absA)
            {
                product += absB;
                result++;
            }

            if ((a > 0 && b > 0) || (a < 0 && b < 0))
                return result;
            else
                return Negate(result);
        }

        public static int Multiply(int a, int b)
        {
            int absA = Abs(a);
            int absB = Abs(b);

            if (absA > absB)
                return Multiply(b, a);

            int result = 0;
            while (absA != 0)
            {
                result += b;
                absA = Subtract(absA, 1);
            }

            if (a < 0)
                result = Negate(result);

            return result;
        }

        private static int Abs(int num)
        {
            if (num < 0)
                return Negate(num);

            return num;
        }

        public static int Subtract(int a, int b)
        {
            return a + Negate(b);
        }

        private static int Negate(int num)
        {
            int newSign = (num > 0) ? -1 : 1;
            int result = 0;

            while (num != 0)
            {
                result += newSign;
                num += newSign;
            }

            return result;
        }
    }
}

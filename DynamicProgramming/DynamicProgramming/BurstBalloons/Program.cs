using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstBalloons
{
    class Program
    {
        /// <summary>
        /// Given n balloons, indexed from 0 to n-1. Each balloon is painted with a number on it represented by array nums. You are 
        /// asked to burst all the balloons. If the you burst balloon i you will get nums[left] * nums[i] * nums[right] coins. Here left 
        /// and right are adjacent indices of i. After the burst, the left and right then becomes adjacent.
        /// Find the maximum coins you can collect by bursting the balloons wisely.
        /// Note:
        /// You may imagine nums[-1] = nums[n] = 1.They are not real therefore you can not burst them.
        /// 0 ≤ n ≤ 500, 0 ≤ nums[i] ≤ 100
        /// Example:
        ///
        /// Input: [3,1,5,8]
        /// Output: 167 
        /// Explanation: nums = [3, 1, 5, 8]-- > [3, 5, 8]-- >   [3, 8]-- >  [8]-- > []
        ///
        ///             coins = 3 * 1 * 5 + 3 * 5 * 8 + 1 * 3 * 8 + 1 * 8 * 1 = 167
        /// </summary>
        static void Main(string[] args)
        {
            int[] arr = { 3, 1, 5, 8 };

            var result = MaxCoins(arr);

            Console.ReadLine();
        }

        public static int MaxCoins(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            int[] num = new int[n + 2];
            num[0] = 1;
            for (int i = 0; i < n; i++)
                num[i + 1] = nums[i];
            num[n + 1] = 1;

            return MaxCoins(num, 1, n);
        }

        private static int MaxCoins(int[] num, int L, int R)
        {
            int coins = 0;
            for (int i = L; i <= R; i++)
            {
                // value of coins from left side
                int l = MaxCoins(num, L, i - 1);

                // value of coins from right side
                int r = MaxCoins(num, i + 1, R);

                //total value for ith position if we burst it at last
                int val = l + num[L - 1] * num[i] * num[R + 1] + r;
                coins = Math.Max(coins, val);
            }

            return coins;
        }
    }
}

using System;
using System.Collections.Generic;

namespace RottenOranges
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = {
                {2, 1, 0, 2, 1},
                {0, 0, 1, 2, 1},
                {1, 0, 0, 2, 1}
            };

            Console.WriteLine(RotOranges(arr));
            Console.ReadLine();
        }

        private static int RotOranges(int[,] arr)
        {
            Queue<Orange> queue = new Queue<Orange>();
            HashSet<Orange> hsRotten = new HashSet<Orange>();
            int timeElapsed = 0;
            bool anyOrangeRottenInUnitTime = false;

            foreach (Orange orange in GetRottenOranges(arr))
                queue.Enqueue(orange);

            queue.Enqueue(null); //Delimiter for current batch

            while (queue.Count > 0)
            {
                Orange current = queue.Dequeue();

                if (current != null)
                {
                    if (RotAdjacentOranges(current, arr, queue))
                    {
                        if (anyOrangeRottenInUnitTime != true)
                            anyOrangeRottenInUnitTime = true;
                    }
                }
                else
                {
                    if (queue.Count > 0)
                        queue.Enqueue(null);

                    if (anyOrangeRottenInUnitTime)
                    {
                        timeElapsed++;
                        anyOrangeRottenInUnitTime = false;
                    }
                }
            }

            return IsEveryOrangeRotten(arr) ? timeElapsed : -1;
        }

        private static bool RotAdjacentOranges(Orange rotten, int[,] arr, Queue<Orange> queue)
        {
            bool hasAnyOrangeRotten = false;

            int topX = rotten.X - 1; int topY = rotten.Y;
            int bottomX = rotten.X + 1; int bottomY = rotten.Y;
            int leftX = rotten.X; int leftY = rotten.Y - 1;
            int rightX = rotten.X; int rightY = rotten.Y + 1;

            if (IsFreshOrange(topX, topY, arr))
            {
                arr[topX, topY] = 2;
                queue.Enqueue(new Orange(topX, topY, 2));
                if (hasAnyOrangeRotten != true)
                    hasAnyOrangeRotten = true;
            }

            if (IsFreshOrange(bottomX, bottomY, arr))
            {
                arr[bottomX, bottomY] = 2;
                queue.Enqueue(new Orange(bottomX, bottomY, 2));
                if (hasAnyOrangeRotten != true)
                    hasAnyOrangeRotten = true;
            }

            if (IsFreshOrange(leftX, leftY, arr))
            {
                arr[leftX, leftY] = 2;
                queue.Enqueue(new Orange(leftX, leftY, 2));
                if (hasAnyOrangeRotten != true)
                    hasAnyOrangeRotten = true;
            }

            if (IsFreshOrange(rightX, rightY, arr))
            {
                arr[rightX, rightY] = 2;
                queue.Enqueue(new Orange(rightX, rightY, 2));
                if (hasAnyOrangeRotten != true)
                    hasAnyOrangeRotten = true;
            }

            return hasAnyOrangeRotten;
        }

        private static bool IsFreshOrange(int x, int y, int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            return x >= 0 && x < rows
                && y >= 0 && y < cols
                && arr[x, y] == 1;
        }

        private static List<Orange> GetRottenOranges(int[,] arr)
        {
            List<Orange> lstRotten = new List<Orange>();
            for (int r = 0; r <= arr.GetLength(0) - 1; r++)
            {
                for (int c = 0; c <= arr.GetLength(1) - 1; c++)
                {
                    if (arr[r, c] == 2)
                    {
                        Orange orange = new Orange(r, c, 2);
                        lstRotten.Add(orange);
                    }
                }
            }

            return lstRotten;
        }

        private static bool IsEveryOrangeRotten(int[,] arr)
        {
            for (int r = 0; r <= arr.GetLength(0) - 1; r++)
            {
                for (int c = 0; c <= arr.GetLength(1) - 1; c++)
                {
                    if (arr[r, c] == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal class Orange
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int State { get; set; }

            public Orange(int x, int y, int state)
            {
                State = state;
                X = x;
                Y = y;
            }
        }
    }
}

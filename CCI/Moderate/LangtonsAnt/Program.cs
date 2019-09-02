using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangtonsAnt
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 6;
            Grid grid = new Grid(k);
            int x = new Random().Next(k / 2);
            int y = new Random().Next(k / 2);

            Console.WriteLine();
            LangtonsAnt(grid, x, y, k);

            grid.Print();

            Console.ReadLine();
        }

        private static void LangtonsAnt(Grid grid, int startRow, int startCol, int k)
        {
            int count = 0;
            int curRow = startRow;
            int curCol = startCol;

            Location curLoc = new Location();
            curLoc.RowIndex = startRow;
            curLoc.ColIndex = startCol;
            curLoc.CurrDirection = Location.Direction.Right;

            while (count < k)
            {
                curLoc = Move(grid, curLoc);
                count++;
            }
        }

        private static Location Move(Grid grid, Location curLoc)
        {
            Location dest = new Location();

            grid.FlipColour(curLoc.RowIndex, curLoc.ColIndex);

            if (grid.IsWhite(curLoc.RowIndex, curLoc.ColIndex))
                dest.CurrDirection = Turn(curLoc.CurrDirection, "Right");
            else
                dest.CurrDirection = Turn(curLoc.CurrDirection, "Left");

            if (dest.CurrDirection == Location.Direction.Up)
            {
                dest.RowIndex = curLoc.RowIndex - 1;
                dest.ColIndex = curLoc.ColIndex;
            }
            else if (dest.CurrDirection == Location.Direction.Right)
            {
                dest.RowIndex = curLoc.RowIndex;
                dest.ColIndex = curLoc.ColIndex + 1;
            }
            else if (dest.CurrDirection == Location.Direction.Down)
            {
                dest.RowIndex = curLoc.RowIndex + 1;
                dest.ColIndex = curLoc.ColIndex;
            }
            else if (dest.CurrDirection == Location.Direction.Left)
            {
                dest.RowIndex = curLoc.RowIndex;
                dest.ColIndex = curLoc.ColIndex - 1;
            }

            return dest;
        }

        private static Location.Direction Turn(Location.Direction currDirection, string turn)
        {
            if (turn.ToLower() == "right")
            {
                if (currDirection == Location.Direction.Down)
                    return Location.Direction.Left;
                else if (currDirection == Location.Direction.Left)
                    return Location.Direction.Up;
                else if (currDirection == Location.Direction.Up)
                    return Location.Direction.Right;
                else if (currDirection == Location.Direction.Right)
                    return Location.Direction.Down;
            }
            else
            {
                if (currDirection == Location.Direction.Down)
                    return Location.Direction.Right;
                else if (currDirection == Location.Direction.Right)
                    return Location.Direction.Up;
                else if (currDirection == Location.Direction.Up)
                    return Location.Direction.Left;
                else if (currDirection == Location.Direction.Left)
                    return Location.Direction.Down;
            }

            return Location.Direction.Right;
        }

        public class Grid
        {
            int rowCount;
            int colCount;
            public int[,] grid;

            public Grid(int k)
            {
                rowCount = k;
                colCount = k;
                grid = new int[rowCount, colCount];
                PopulateCells();
                Print();
            }

            private void PopulateCells()
            {
                bool isZero = false;
                for (int r = 0; r < rowCount; r++)
                {
                    for (int c = 0; c < colCount; c++)
                    {
                        grid[r, c] = isZero ? 0 : 1;
                        isZero = !isZero;
                    }

                    isZero = grid[r, 0] == 1;
                }
            }

            public void Print()
            {
                for (int r = 0; r < rowCount; r++)
                {
                    for (int c = 0; c < colCount; c++)
                    {
                        Console.Write(grid[r, c] + " ");
                    }

                    Console.WriteLine();
                }
            }

            public bool IsWhite(int row, int col)
            {
                return grid[row, col] == 0;
            }

            public bool IsBlack(int row, int col)
            {
                return grid[row, col] == 1;
            }

            public void FlipColour(int row, int col)
            {
                if (grid[row, col] == 1)
                    grid[row, col] = 0;
                else
                    grid[row, col] = 1;
            }
        }

        public class Location
        {
            public int RowIndex { get; set; }
            public int ColIndex { get; set; }
            public Direction CurrDirection { get; set; }

            public enum Direction
            {
                Right = 1,
                Down = 2,
                Left = 3,
                Up = 4
            }
        }
    }
}

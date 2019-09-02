using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PondSizes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] plot = new int[,]
            {
                {0, 2, 1, 0},
                {0, 1, 0, 1},
                {1, 1, 0, 1},
                {0, 1, 0, 1}
            };

            List<int> lstPondSizes = GetPondSizes(plot);
            Console.ReadLine();
        }

        private static List<int> GetPondSizes(int[,] plot)
        {
            List<int> lstPondSizes = new List<int>();
            HashSet<string> hsVisited = new HashSet<string>();
            int pondSize = 0;

            for (int r = 0; r < plot.GetLength(0); r++)
            {
                for (int c = 0; c < plot.GetLength(1); c++)
                {
                    if (plot[r, c] == 0 && !hsVisited.Contains(r + "|" + c))
                    {
                        pondSize = ExploreConnectedArea(plot, new Location(r, c), hsVisited);
                        lstPondSizes.Add(pondSize);
                    }
                }
            }

            return lstPondSizes;
        }

        private static int ExploreConnectedArea(int[,] plot, Location location, HashSet<string> hsVisited)
        {
            var key = location.X + "|" + location.Y;
            if (!IsValidWaterLocation(location, plot) || hsVisited.Contains(key))
                return 0;

            int subSize = 1;
            hsVisited.Add(key);

            foreach (Location connectedLocation in location.GetConnectedLocations())
            {
                subSize += ExploreConnectedArea(plot, connectedLocation, hsVisited);
            }

            return subSize;
        }

        private static bool IsValidWaterLocation(Location location, int[,] plot)
        {
            int rowCount = plot.GetLength(0);
            int colCount = plot.GetLength(1);

            return location.X >= 0 && location.X < rowCount &&
                   location.Y >= 0 && location.Y < colCount &&
                   plot[location.X, location.Y] == 0;
        }

        public class Location
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Location() { }
            public Location(int x, int y)
            {
                X = x;
                Y = y;
            }

            public List<Location> GetConnectedLocations()
            {
                List<Location> lstConnected = new List<Location>()
                {
                    {new Location(){X = X - 1, Y = Y} },
                    {new Location(){X = X + 1, Y = Y} },
                    {new Location(){X = X, Y = Y - 1} },
                    {new Location(){X = X, Y = Y + 1} },
                    {new Location(){X = X - 1, Y = Y + 1} },
                    {new Location(){X = X - 1, Y = Y - 1} },
                    {new Location(){X = X + 1, Y = Y + 1} },
                    {new Location(){X = X + 1, Y = Y - 1} }
                };

                return lstConnected;
            }
        }
    }
}

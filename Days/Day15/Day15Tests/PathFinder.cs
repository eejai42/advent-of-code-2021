using System;
using System.Collections.Generic;
using System.Drawing;

namespace Day6Tests
{
    internal class PathFinder
    {
        public List<string> RawValues { get; set; }

        public Random Random { get; }
        public Point MaxPoint { get; }
        public Dictionary<Point, int> CachedValues { get; }

        public PathFinder(List<string> rawValues)
        {
            this.RawValues = rawValues;
            this.Random = new Random();
            this.MaxPoint = new Point(rawValues[0].Length - 1, rawValues.Count - 1);
            this.CachedValues = new Dictionary<Point, int>();
        }

        internal int FindShortestPath()
        {
            var shortestPath = new Path(this) { Length = 1050 };
            int shortestIndex = 0;
            long counter = 0;
            int counter100K = 0;
            while (true)
            {
                if ((counter++ % 1000000) == 0)
                {
                    if (counter100K++ == 1000) break;
                    System.Diagnostics.Debug.WriteLine($"1M = {counter100K}");
                }
                var path = this.CreateRandomPath();
                if (path.Length < shortestPath.Length)
                {
                    shortestPath.WritePath($"../../../data_{shortestIndex++}_{path.Length}_{counter100K}m_{counter}.txt");
                    shortestPath = path;
                }
            }
            
            return shortestPath.Length;
        }

        private Path CreateRandomPath()
        {
            var path = new Path(this);
            path.GenerateRandom();
            return path;
        }

        internal int GetValue(Point point)
        {
            if (!this.CachedValues.ContainsKey(point))
            {
                var row = this.RawValues[point.Y];
                var col = row[point.X];
                var value = Int32.Parse(col.ToString());
                this.CachedValues[point] = value;
            }
            return this.CachedValues[point];
        }
    }
}
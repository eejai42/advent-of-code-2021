using System;
using System.Collections.Generic;
using System.Drawing;

namespace Day6Tests
{
    internal class PathFinder
    {
        private List<string> rawValues;

        public Random Random { get; }
        public Point MaxPoint { get; }

        public PathFinder(List<string> rawValues)
        {
            this.rawValues = rawValues;
            this.Random = new Random();
            this.MaxPoint = new Point(rawValues[0].Length - 1, rawValues.Count - 1);
        }

        internal int FindShortestPath()
        {
            var shortestPath = new Path(this) { Length = Int32.MaxValue };
            int shortestIndex = 0;
            for (int i = 0; i < 10000; i++)
            {
                var path = this.CreateRandomPath();
                if (path.Length < shortestPath.Length)
                {
                    shortestPath.WritePath($"../../../data_{shortestIndex++}_{path.Length}.txt");
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
    }
}
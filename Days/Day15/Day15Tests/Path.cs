using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Day6Tests
{
    internal class Path
    {
        public const int C_UP = 0;
        public const int C_LEFT = 1;
        public const int C_DOWN = 2;
        public const int C_RIGHT = 3;
        public Path(PathFinder pathFinder)
        {
            this.PathFinder = pathFinder;
            this.Attempts = 0;
            this.Points = new List<Point>();
        }

        public int Length { get; set; }
        public PathFinder PathFinder { get; }
        public int Attempts { get; set; }
        public List<Point> Points { get; private set; }

        internal void GenerateRandom()
        {
            var points = new List<Point>();
            var pointsHash = new HashSet<Point>();
            var currentPoint = Point.Empty;
            points.Add(currentPoint);
            pointsHash.Add(currentPoint);
            var maxX = this.PathFinder.MaxPoint.X;
            var maxY = this.PathFinder.MaxPoint.Y;
            while (true)
            {
                var nextPoint = this.NextRandomPoint(currentPoint, points, pointsHash, maxX, maxY);

                if (nextPoint == new Point(-1, -1)) break;
                else
                {
                    currentPoint = nextPoint;
                    points.Add(nextPoint);
                    pointsHash.Add(nextPoint);
                    if (Point.Equals(nextPoint, this.PathFinder.MaxPoint)) break;
                }
            }

            if (currentPoint != this.PathFinder.MaxPoint)
            {
                this.Length = Int32.MaxValue;
            }
            else
            {
                this.Points = points;
                this.CalculateLength();
            }
        }

        private void CalculateLength()
        {
            var length = 0;
            this.Points.ForEach(point =>
            {
                length += this.PathFinder.GetValue(point);
            });
            this.Length = length;
        }

        public void WritePath(string fileName)
        {
            this.WritePath(fileName, this.Points);
        }

        public void WritePath(string fileName, List<Point> points)
        {
            var sb = new StringBuilder();
            int next = 0;
            char[,] map = new char[this.PathFinder.MaxPoint.X + 1, this.PathFinder.MaxPoint.Y + 1];
            for (var row = 0; row < this.PathFinder.MaxPoint.Y + 1; row++)
            {
                for (var col = 0; col < this.PathFinder.MaxPoint.X + 1; col++)
                {
                    map[col, row] = '-';
                }
            }
            points.ForEach(point =>
            {
                map[point.X, point.Y] = next.ToString()[0];
                next = (next + 1) % 10;
            });

            for (var row = 0; row < this.PathFinder.MaxPoint.Y + 1; row++)
            {
                for (var col = 0; col < this.PathFinder.MaxPoint.X + 1; col++)
                {
                    sb.Append(map[col, row]);
                }
                sb.AppendLine();
            }
            File.WriteAllText(fileName, sb.ToString());
        }

        private Point NextRandomPoint(Point currentPoint, List<Point> points, HashSet<Point> pointHash, int maxX, int maxY)
        {
            for (int i = 0; i < 10; i++)
            {
                var direction = PathFinder.Random.Next(4);
                //System.Diagnostics.Debug.WriteLine($"DIRECTION: {direction}");
                var candidateX = currentPoint.X;
                var candidateY = currentPoint.Y;
                switch (direction)
                {
                    //case C_UP:
                    //    candidateY--;
                    //    break;

                    case C_RIGHT:
//                        System.Diagnostics.Debug.WriteLine("Going RIGHT");
                        candidateX++;
                        break;

                    case C_DOWN:
                        //                        System.Diagnostics.Debug.WriteLine("Going DOWN");
                        candidateY++;
                        break;

                    case C_LEFT:
                        // System.Diagnostics.Debug.WriteLine("Going LEFT");
                        candidateX--;
                        break;
                }
                var candidatePoint = new Point(candidateX, candidateY);
                if (!pointHash.Contains(candidatePoint))
                {
                    if ((candidateX >= 0) &&
                        (candidateX <= maxX) &&
                        (candidateY >= 0) &&
                        (candidateY <= maxY))
                    {

                        return candidatePoint;
                    }
                }
            }
            return new Point(-1, -1);
        }
    }
}
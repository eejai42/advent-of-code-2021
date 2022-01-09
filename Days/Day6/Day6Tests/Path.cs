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
        public const int C_RIGHT = 1;
        public const int C_DOWN = 2;
        public const int C_LEFT = 3;
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
            var currentPoint = Point.Empty;
            var points = new List<Point>();
            points.Add(currentPoint);
            while (true)
            {
                var nextPoint = this.NextRandomPoint(currentPoint, points);

                if (nextPoint == new Point(-1, -1))
                {
                    break;
                }
                else
                {
                    currentPoint = nextPoint;
                    points.Add(nextPoint);
                    if (nextPoint.Y >= 98)
                    {
                        object o = 1;
                    }
                    if (Point.Equals(nextPoint, this.PathFinder.MaxPoint)) break;
                }
            }


            if (currentPoint != this.PathFinder.MaxPoint)
            {
                if (this.Attempts++ < 5) this.GenerateRandom();
                else this.Length = Int32.MaxValue;
            }
            else
            {
                this.Points = points;
                this.Length = this.Points.Count;
            }
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

        private Point NextRandomPoint(Point currentPoint, List<Point> points)
        {
            var direction = PathFinder.Random.Next(4);
            for (int i = 0; i < 4; i++)
            {
                var candidateX = currentPoint.X;
                var candidateY = currentPoint.Y;
                switch (direction)
                {
                    //case C_UP:
                    //    candidateY--;
                    //    break;

                    case C_RIGHT:
                        candidateX++;
                        break;

                    case C_DOWN:
                        candidateY++;
                        break;

                    case C_LEFT:
                        candidateX--;
                        break;
                }
                var candidatePoint = new Point(candidateX, candidateY);
                if (points.IndexOf(candidatePoint) == -1)
                {
                    if ((candidatePoint.X >= 0) &&
                        (candidatePoint.X <= this.PathFinder.MaxPoint.X) &&
                        (candidatePoint.Y >= 0) &&
                        (candidatePoint.Y <= this.PathFinder.MaxPoint.Y))
                    {

                        return candidatePoint;
                    }
                }
                direction = (direction + 1) % 4;
            }
            return new Point(-1, -1);
        }
    }
}
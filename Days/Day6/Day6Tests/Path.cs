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
            var points = new List<Point>();
            var currentPoint = Point.Empty;
            while (true)
            {
                points.Add(currentPoint);
                var nextPoint = this.NextRandomPoint(currentPoint, points);
                
                if (nextPoint == new Point(-1, -1)) break;
                else
                {
                    points.Add(nextPoint);
                    if (Point.Equals(nextPoint, this.PathFinder.MaxPoint)) break;
                    else currentPoint = nextPoint;
                }
            }


            this.WritePath("../../../data.txt", points);
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

        private void WritePath(string fileName, List<Point> points)
        {
            var sb = new StringBuilder();
            for (var row = 0; row < this.PathFinder.MaxPoint.Y; row++)
            {
                for (var col = 0; col < this.PathFinder.MaxPoint.X; col++)
                {
                    var point = new Point(col, row);
                    sb.Append($"{(points.Contains(point) ? "x" : "-")}");
                }
                sb.AppendLine();
            }
            File.WriteAllText(fileName, sb.ToString());
        }

        private Point NextRandomPoint(Point currentPoint, List<Point> points)
        {
            var direction = PathFinder.Random.Next(3);
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
                        (candidatePoint.X < this.PathFinder.MaxPoint.X) &&
                        (candidatePoint.Y >= 0) &&
                        (candidatePoint.Y < this.PathFinder.MaxPoint.Y)) { 

                        points.Add(candidatePoint);
                        return candidatePoint;
                    }
                }
                direction = (direction + 1) % 4;
            }
            return new Point(-1, -1);
        }
    }
}
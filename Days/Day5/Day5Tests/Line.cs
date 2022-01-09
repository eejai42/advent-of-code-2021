using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day5Tests
{
    internal class Line
    {
        private string Input;

        public List<Point> Points { get; }
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public Line(string input)
        {
            this.Input = input;
            this.Points = new List<Point>();
            this.ParseInput();
        }

        private void ParseInput()
        {
            var parts = this.Input
                            .Split(" -> ")
                            .Select(pointString => this.GetPoint(pointString))
                            .ToList();
            bool isHorizontal = parts[0].Y == parts[1].Y;
            bool isVertical = parts[0].X == parts[1].X;
            bool isValid = isHorizontal || isVertical;
            if (isValid)
            {
                if (isHorizontal)
                {
                    this.Start = parts[0].X < parts[1].X ? parts[0] : parts[1];
                    this.End = parts[0].X < parts[1].X ? parts[1] : parts[0];
                }
                else if (isVertical)
                {
                    this.Start = parts[0].Y < parts[1].Y ? parts[0] : parts[1];
                    this.End = parts[0].Y < parts[1].Y ? parts[1] : parts[0];
                }


                var currentIndex = isHorizontal ? this.Start.X : this.Start.Y;
                var targetIndex = isHorizontal ? this.End.X : this.End.Y;
                for (var i = currentIndex; i <= targetIndex; i++)
                {
                    var newPoint = new Point((isHorizontal ? i : Start.X), (isHorizontal ? Start.Y : i));
                    this.Points.Add(newPoint);
                }
            }
        }

        private Point GetPoint(string pointString)
        {
            var parts = pointString.Split(",");
            return new Point(Int32.Parse(parts[0]), Int32.Parse(parts[1]));
        }
    }
}
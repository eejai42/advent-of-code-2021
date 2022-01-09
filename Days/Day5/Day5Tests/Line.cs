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
        public bool IncludeDiagonal { get; }
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public Line(string input, bool includeDiagonal)
        {
            this.Input = input;
            this.Points = new List<Point>();
            this.IncludeDiagonal = includeDiagonal;
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
            if (isHorizontal)
            {
                this.Start = parts[0].X < parts[1].X ? parts[0] : parts[1];
                this.End = parts[0].X < parts[1].X ? parts[1] : parts[0];
                for (var i = this.Start.X; i <= this.End.X; i++)
                {
                    var newPoint = new Point(i, Start.Y);
                    this.Points.Add(newPoint);
                }
            }
            else if (isVertical)
            {
                this.Start = parts[0].Y < parts[1].Y ? parts[0] : parts[1];
                this.End = parts[0].Y < parts[1].Y ? parts[1] : parts[0];
                for (var i = Start.Y; i <= End.Y; i++)
                {
                    var newPoint = new Point(Start.X, i);
                    this.Points.Add(newPoint);
                }
            }
            else if (this.IncludeDiagonal)
            {
                this.Start = parts[0].X < parts[1].X ? parts[0] : parts[1];
                this.End = parts[0].X < parts[1].X ? parts[1] : parts[0];
                for (var i = 0; i <= Math.Abs(this.Start.X - End.X); i++)
                {
                    var newPoint = new Point(this.Start.X + i, Start.Y + (End.Y > Start.Y ? i : -i));
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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Day5Tests
{
    internal class SeaFloor
    {

        private Dictionary<Point, int> MappedValues = new Dictionary<Point, int>();

        public int DangerousSpotCount { get { return this.MappedValues.Count(count => count.Value > 1); } }

        public SeaFloor(List<string> rawValues)
        {
            var lines = rawValues.Select(rawValue => new Line(rawValue)).ToList();
            lines.ForEach(line => this.DrawLine(line));
        }

        private void DrawLine(Line line)
        {
            line.Points.ForEach(point => this.UpdatePoint(point));
        }

        private void UpdatePoint(Point point)
        {
            if (this.MappedValues.ContainsKey(point)) this.MappedValues[point]++;
            else this.MappedValues[point] = 1;
        }

        internal string Map()
        {
            var maxX = this.MappedValues.Keys.Max(max => max.X);
            var maxY = this.MappedValues.Keys.Max(max => max.Y);
            var sb = new StringBuilder();
            for (int x = 1; x <= maxX; x++)
            {
                for (int y = 1; y <= maxY; y++)
                {
                    var mappedPoint = new Point(x, y);
                    var mappedValue = this.MappedValues.ContainsKey(mappedPoint) ? this.MappedValues[mappedPoint].ToString() : ".";
                    sb.Append(mappedValue);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
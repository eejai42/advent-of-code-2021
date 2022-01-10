using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Day13Tests
{
    internal class TransparencyFoler
    {
        public List<Point> Marks { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool[,] Map { get; private set; }
        public List<string> Instructions { get; }

        public TransparencyFoler(string coordinateText, string instructions)
        {
            var lineCoordinates = coordinateText.Split(Environment.NewLine)
                                            .Select(lines => lines.Split(","))
                                            .ToList();

            this.Marks = lineCoordinates.Select(cord => new Point(Int32.Parse(cord[0]), Int32.Parse(cord[1]))).ToList();
            this.GenerateTransparency();
            this.Instructions = instructions.Split(Environment.NewLine)
                                            .Select(instruction => instruction.Substring("fold along ".Length))
                                            .ToList();
        }

        private void GenerateTransparency()
        {
            this.Marks = this.Marks.Distinct().ToList();
            this.Width = this.Marks.Max(mark => mark.X + 1);
            this.Height = this.Marks.Max(mark => mark.Y + 1);
            this.Map = new bool[this.Width, this.Height];
            this.Marks.ForEach(mark => this.Map[mark.X, mark.Y] = true);
            this.SaveTransparency();
        }

        private void SaveTransparency()
        {
            var sb = new StringBuilder();
            for (var y = 0; y < this.Height; y++)
            {
                for (var x = 0; x < this.Width; x++)
                {
                    sb.Append(this.Map[x, y] ? "#" : " ");
                }
                sb.AppendLine();
            }
            File.WriteAllText("../../../transparency.txt", sb.ToString());
        }

        internal void Fold()
        {
            this.Instructions.ForEach(instruction => this.FoldInstruction(instruction));   
        }

        private void FoldInstruction(string instruction)
        {
            var direction = instruction[0];
            var foldIndex = Int32.Parse(instruction.Substring(2));

            for (var i = 0; i < this.Marks.Count; i++)
            {
                var transposedMark = this.Transpose(this.Marks[i], direction, foldIndex);
                this.Marks[i] = transposedMark;
            }
            this.GenerateTransparency();
        }

        private Point Transpose(Point point, char direction, int foldIndex)
        {
            if (direction == 'x') return new Point(CalculateFoldedValue(foldIndex, point.X), point.Y);
            else return new Point(point.X, this.CalculateFoldedValue(foldIndex, point.Y));
        }

        private int CalculateFoldedValue(int foldIndex, int index)
        {
            if (index > foldIndex) return index - ((index - foldIndex) * 2);
            else return index;
        }

        internal int CalculateScore()
        {
            throw new NotImplementedException();
        }
    }
}
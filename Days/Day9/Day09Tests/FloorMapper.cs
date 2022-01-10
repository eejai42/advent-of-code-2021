﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day09Tests
{
    internal class FloorMapper
    {
        public FloorMapper(System.Collections.Generic.List<string> lines)
        {
            this.LowPoints = new List<int>();
            this.Lines = lines;
            this.Height = this.Lines.Count;
            this.Width = this.Lines[0].Length;
            this.Map = new int[this.Width, this.Height];
            for (var row = 0; row < this.Height; row++)
            {
                for (var col = 0; col < this.Width; col++)
                {
                    this.Map[col, row] = Int32.Parse($"{this.Lines[row][col]}");
                }
            }

            this.FinalMap = this.Map;
        }

        public List<string> Lines { get; }
        public int Height { get; }
        public int Width { get; }
        public int[,] Map { get; }
        public List<int> LowPoints { get; }
        public int[,] FinalMap { get; }

        internal void FindLowPoints()
        {
            for (var row = 0; row < this.Height; row++)
            {
                for (var col = 0; col < this.Width; col++)
                {
                    if (this.IsLowPoint(col, row))
                    {
                        var lowPoint = this.Map[col, row];
                        this.FinalMap[col, row] = -1;
                        this.LowPoints.Add(lowPoint);
                    }
                }
            }

            this.WriteMap(this.FinalMap);
        }

        private void WriteMap(int[,] map)
        {
            var sb = new StringBuilder();
            for (var row = 0; row < this.Height; row++)
            {
                for (var col = 0; col < this.Width; col++)
                {
                    sb.Append(map[col, row] == -1 ? 'X' : map[col, row].ToString()[0]);
                }
                sb.AppendLine();
            }
            File.WriteAllText("../../../final.txt", sb.ToString());
        }

        private bool IsLowPoint(int col, int row)
        {
            var value = this.Map[col, row];
            if (this.IsLower(value, col, row - 1) &&
                this.IsLower(value, col + 1, row) &&
                this.IsLower(value, col, row + 1) &&
                this.IsLower(value, col - 1, row)) return true;
            else return false;
        }

        private bool IsLower(int value, int col, int row)
        {
            if ((col >= 0) && (col < this.Width) && (row >= 0) && (row < this.Height))
            {
                var compareTo = this.Map[col, row];
                return value < compareTo;
            }
            else return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day4Tests
{
    internal class Board
    {
        public List<int> Values { get; }

        public Board(List<string> readings)
        {
            this.Values = new List<Int32>();
            while (readings.Any())
            {
                var row = readings.First();
                this.Values.AddRange(row.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(number => Int32.Parse(number)).ToList());
                readings.RemoveAt(0);
                if (String.IsNullOrEmpty(row)) break;
            }
        }

        public void MarkNumber(int calledNumber)
        {
            var indexOfCalledNumber = this.Values.IndexOf(calledNumber);
            if (indexOfCalledNumber >= 0) this.Values[indexOfCalledNumber] = -1;
        }

        internal bool HasBingo()
        {
            var winLanes = new List<Int32>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    var value = this.Values[row + (col * 5)];
                    winLanes[row] += value;
                    winLanes[5 + col] += value;
                    if (row == col) winLanes[10] += value;
                    if (Math.Abs(row - 5) == col) winLanes[11] += value;
                }
            }
            var isWin = winLanes.Any(anyWinLane => anyWinLane == -5);
            return isWin;
        }

        internal int SumOfUnmarkedNumbers()
        {
            return this.Values.Where(value => value >= 0).Sum();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            int col = 0;
            this.Values.ForEach(value =>
            {
                if (value >= 0) sb.Append(" ");
                sb.Append($"{String.Format("{0:00}", value)} ");
                if (col++ == 4)
                {
                    col = 0;
                    sb.AppendLine();
                }
            });
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

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

        internal bool WinsWith(int calledNumber)
        {
            var winLanes = new List<Int32>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            var indexOfCalledNumber = this.Values.IndexOf(calledNumber);
            if (indexOfCalledNumber >= 0) this.Values[indexOfCalledNumber] = -1;
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
            if (isWin)
            {
                object o = 1;
            }
            return isWin;
        }

        internal int SumOfUnmarkedNumbers()
        {
            return this.Values.Where(value => value >= 0).Sum();
        }
    }
}
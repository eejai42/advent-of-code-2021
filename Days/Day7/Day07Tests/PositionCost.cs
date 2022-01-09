using System;

namespace Day07Tests
{
    internal class PositionCost
    {
        public int Position { get; set; }
        public Int64 Fuel { get; set; }

        public PositionCost(int position, Int64 cost = Int32.MaxValue)
        {
            this.Position = position;
            this.Fuel = cost;
        }
    }
}
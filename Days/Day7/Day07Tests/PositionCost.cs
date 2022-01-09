using System;

namespace Day07Tests
{
    internal class PositionCost
    {
        public int Position { get; set; }
        public int Fuel { get; set; }

        public PositionCost(int position, Int32 cost = Int32.MaxValue)
        {
            this.Position = position;
            this.Fuel = cost;
        }
    }
}
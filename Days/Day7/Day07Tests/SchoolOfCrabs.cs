using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07Tests
{
    internal class SchoolOfCrabs
    {

        public SchoolOfCrabs(String values)
        {
            this.Positions = values.Split(",").Select(value => Int32.Parse(value)).ToList();
            this.RightmostCrab = this.Positions.Max();
        }

        public List<int> Positions { get; }
        public int RightmostCrab { get; private set; }

        internal int FindOptimalAlignment()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Position,Cost");
            var bestPosition = new PositionCost(-1);
            for (int position = 1; position < this.RightmostCrab; position++)
            {
                var fuel = this.CalculateCostAtPosition(position);
                sb.AppendLine($"{position},{fuel}");
                if (fuel < bestPosition.Fuel)
                {
                    bestPosition = new PositionCost(position, fuel);
                }
            }
            System.IO.File.WriteAllText("../../../values.csv", sb.ToString());
            return bestPosition.Fuel;
        }

        private int CalculateCostAtPosition(int targetPosition)
        {
            var cost = this.Positions
                        .Select(position => Math.Abs(position - targetPosition)).Sum();
            return cost;
        }
    }
}
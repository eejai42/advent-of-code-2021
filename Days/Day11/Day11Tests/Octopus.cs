using System;
using System.Collections.Generic;

namespace Day11Tests
{
    internal class Octopus
    {
        private Cave cave;
        private int row;
        private int col;
        public int Energy;

        public List<Octopus> Neighbors { get; private set; }

        public Octopus(Cave cave, int row, int col, int energy)
        {
            this.cave = cave;
            this.row = row;
            this.col = col;
            this.Energy = energy;
        }

        internal void IncreaseEnergy(bool alwaysIncrease = false)
        {
            if (alwaysIncrease || this.Energy > 0) this.Energy++;
        }

        public void FlashIfAppropriate()
        {
            if (this.Energy > 9)
            {
                this.cave.Flashes++;
                this.Energy = 0;
                this.IncreaseEnergyOfNeighbors();
                this.cave.SaveCave();
            }
        }

        private void IncreaseEnergyOfNeighbors()
        {
            this.Neighbors.ForEach(neighbor => neighbor.IncreaseEnergy());
        }

        internal void FindNeighbors()
        {
            this.Neighbors = new List<Octopus>();
            this.AddNeighbor(col - 1, row - 1);
            this.AddNeighbor(col, row - 1);
            this.AddNeighbor(col + 1, row - 1);
            this.AddNeighbor(col - 1, row);
            this.AddNeighbor(col + 1, row);
            this.AddNeighbor(col - 1, row + 1);
            this.AddNeighbor(col, row + 1);
            this.AddNeighbor(col + 1, row + 1);

        }

        private void AddNeighbor(int col, int row)
        {
            if ((row >= 0) && (row < this.cave.Height) && (col >= 0) && (col < this.cave.Width))
            {
                this.Neighbors.Add(this.cave.Map[col, row]);
            }
        }

        public override string ToString()
        {
            return String.Format("{0:00}x{1:00} - {2}", this.col, this.row, this.Energy);
        }
    }
}
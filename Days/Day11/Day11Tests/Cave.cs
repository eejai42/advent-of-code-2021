using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day11Tests
{
    internal class Cave
    {

        public Cave(string input)
        {
            this.Octopuses = new List<Octopus>();
            var lines = input.Split(Environment.NewLine);
            this.Width = lines[0].Length;
            this.Height = lines.Length;
            this.Map = new Octopus[this.Width, this.Height];
            for (var col = 0; col < this.Width; col++)
            {
                for (var row = 0; row < this.Height; row++)
                {
                    var line = lines[row];
                    var newOctopus = this.Map[col, row] = new Octopus(this, row, col, int.Parse(line[col].ToString()));
                    this.Octopuses.Add(newOctopus);
                }
            }
            this.Octopuses.ForEach(octopus => octopus.FindNeighbors());
        }

        internal int ChartPathUntilSynchronized()
        {
            var step = 0;
            while (this.Octopuses.Any(octopus => octopus.Energy != 0))
            {
                step++;
                this.Flashes = 0;
                this.IncrementStep();
            }
            return step;
        }

        public int Width { get; }
        public int Height { get; }
        public Octopus[,] Map { get; }
        public List<Octopus> Octopuses { get; }
        public int Flashes { get; set; }

        internal int ChartPath(int stepsToTake)
        {
            this.Flashes = 0;
            for (int i = 0; i < stepsToTake; i++)
            {
                this.SaveCave();
                this.IncrementStep();
            }
            return this.Flashes;
        }

        private void IncrementStep()
        {
            this.Octopuses.ForEach(octopus => octopus.IncreaseEnergy(true));
            var readyToFlash = this.GetReadyToFlash();
            while (readyToFlash.Any())
            {
                readyToFlash.ForEach(octopus => octopus.FlashIfAppropriate());
                readyToFlash = this.GetReadyToFlash();
            }
            this.SaveCave();
        }

        private List<Octopus> GetReadyToFlash()
        {
            return this.Octopuses.Where(octopus => octopus.Energy > 9).ToList();
        }

        public void SaveCave()
        {
            var sb = new StringBuilder();

            for (var row = 0; row < this.Height; row++)
            {
                for (var col = 0; col < this.Width; col++)
                {
                    sb.Append($"{this.Map[col, row].Energy}".PadLeft(1));
                }
                sb.AppendLine();
            }
            File.WriteAllText("../../../cave.txt", sb.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day2Tests
{
    internal class Submarine
    {
        public enum Commands
        {
            Forward,
            Up,
            Down
        }
        public Submarine()
        {
        }

        public Vector3 Position { get; set; }

        internal void CalculatePosition(List<String> input)
        {
            input.ForEach(command => this.ProcessCommand(command));
        }

        private void ProcessCommand(string command)
        {
            var parts = $"{command}".Split(" ");
            var distance = Int32.Parse(parts[1]);
            switch (parts[0])
            {
                case "forward":
                    this.Position = new Vector3(this.Position.X + distance, this.Position.Y, this.Position.Z);
                    break;

                case "up":
                    this.Position = new Vector3(this.Position.X, this.Position.Y - distance, this.Position.Z);
                    break;

                case "down":
                    this.Position = new Vector3(this.Position.X, this.Position.Y + distance, this.Position.Z);
                    break;
            }
        }
    }
}
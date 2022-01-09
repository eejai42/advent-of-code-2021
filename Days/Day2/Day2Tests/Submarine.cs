using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day2Tests
{
    internal class Submarine
    {
        public Vector3 Position { get; private set; }
        public int HorizontalPosition { get; private set; }
        public int Aim { get; private set; }
        public int Depth { get; private set; }

        public Submarine()
        {
        }

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

        internal void CalculatePositionWithAim(List<string> commands)
        {
            commands.ForEach(command => this.ProcessCommandWithAim(command));
        }

        private void ProcessCommandWithAim(string command)
        {
            var parts = $"{command}".Split(" ");
            var distance = Int32.Parse(parts[1]);
            switch (parts[0])
            {
                case "forward":
                    this.HorizontalPosition += distance;
                    this.Depth += (distance * this.Aim);
                    break;

                case "up":
                    this.Aim -= distance;
                    break;

                case "down":
                    this.Aim += distance;
                    break;
            }
        }
    }
}
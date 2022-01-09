using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Day2Tests
{
    public class Tests
    {
        internal Submarine Submarine { get; private set; }
        public List<String>Input { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Submarine = new Submarine();
            this.SetupInput();
        }

        private void SetupInput()
        {
            this.Input = File.ReadAllText("../../../Input.txt")
                               .Split(Environment.NewLine)
                               .ToList();
        }

        [Test]
        public void Test1()
        {
            this.Submarine.CalculatePosition(this.Input);
            var answer = this.Submarine.Position.X * this.Submarine.Position.Y;
            Assert.IsTrue(answer == 1648020);
        }

        [Test]
        public void Part2()
        {
            this.Submarine.CalculatePositionWithAim(this.Input);
            var answer = this.Submarine.HorizontalPosition * this.Submarine.Depth;
            Assert.IsTrue(answer == 1759818555);
        }
    }
}
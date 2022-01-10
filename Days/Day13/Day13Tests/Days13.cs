using NUnit.Framework;
using System;
using System.IO;

namespace Day13Tests
{
    public class Tests
    {
        public string Coordinates { get; private set; }
        public string Instructions { get; private set; }

        [SetUp]
        public void Setup()
        {
            var data = File.ReadAllText("../../../Input.txt");
            var parts = data.Split($"{Environment.NewLine}{Environment.NewLine}");
            this.Coordinates = parts[0];
            this.Instructions = parts[1];
        }

        [Test]
        public void Part1()
        {
            var transparencyFolder = new TransparencyFoler(this.Coordinates, this.Instructions);
            transparencyFolder.Fold();
            var score = transparencyFolder.CalculateScore();
            Assert.IsTrue(score == -1);
        }
    }
}
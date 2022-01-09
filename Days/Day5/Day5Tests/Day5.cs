using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5Tests
{
    public class Tests
    {
        public List<string> RawValues { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.SetupInput();
        }

        private void SetupInput()
        {
            var readings = File.ReadAllText("../../../Input.txt")
                               .Split(Environment.NewLine)
                               .ToList();
            this.RawValues = readings;
        }

        [Test]
        public void Part1()
        {
            var seaFloor = new SeaFloor(this.RawValues);
            var output = seaFloor.Map();
            File.WriteAllText("../../../output.txt", output);
            int dangerousSpotCount = seaFloor.DangerousSpotCount;
            Assert.IsTrue(dangerousSpotCount == 6267);
        }

        [Test]
        public void Part2()
        {
            var seaFloor = new SeaFloor(this.RawValues, true);
            var output = seaFloor.Map();
            File.WriteAllText("../../../output.txt", output);
            int dangerousSpotCount = seaFloor.DangerousSpotCount;
            Assert.IsTrue(dangerousSpotCount == 20196); // 20210 too big
        }
    }
}
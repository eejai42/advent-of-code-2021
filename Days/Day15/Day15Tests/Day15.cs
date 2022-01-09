using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6Tests
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
        public void Test1()
        {
            var pathFinder = new PathFinder(this.RawValues);
            var shortestPath = pathFinder.FindShortestPath();
            Assert.IsTrue(shortestPath == 23);
        }
    }
}
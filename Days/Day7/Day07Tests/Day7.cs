using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07Tests
{
    public class Tests
    {
        public string RawValues { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.RawValues = File.ReadAllText("../../../Input.txt");
        }

        [Test]
        public void Part1()
        {
            var schoolOfCrabs = new SchoolOfCrabs(this.RawValues);
            var bestAlignment = schoolOfCrabs.FindOptimalAlignment();
            Assert.IsTrue(bestAlignment == 352331);
        }
    }
}
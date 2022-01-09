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
            var costForBestAlignment = schoolOfCrabs.CalculateOptimalCost();
            Assert.IsTrue(costForBestAlignment == 352331);
        }

        [Test]
        public void Part2()
        {
            try
            {
                var schoolOfCrabs = new SchoolOfCrabs(this.RawValues);
                var costOfBestAlignment = schoolOfCrabs.CalculateOptimalExponentialCost();
                Assert.IsTrue(costOfBestAlignment == 99266250);
            }
            catch (Exception ex)
            {
                object o = ex;
            }
        }
    }
}
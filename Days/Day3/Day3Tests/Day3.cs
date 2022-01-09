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
        public DiagnosticReport Report { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.SetupInput();
        }

        private void SetupInput()
        {
            var readings = File.ReadAllText("../../../Input.txt")
                               .Split(Environment.NewLine)
                               .Select(reading => new Reading(reading))
                               .ToList();
            this.Report = new DiagnosticReport(readings);
        }

        [Test]
        public void Part1()
        {
            int gamma = this.Report.CalculateGamma();
            int epsilon = this.Report.CalculateEpsilon();
            var answer = gamma * epsilon;
            Assert.IsTrue(answer == 4103154);
        }

        [Test]
        public void Part2()
        {
            int o2Rating = this.Report.CalculateOxygenGeneratorRating();
            int co2Rating = this.Report.CalculateC02ScrubberRating();
            var answer = o2Rating * co2Rating;
            Assert.IsTrue(answer == 4245351);
        }

    }
}
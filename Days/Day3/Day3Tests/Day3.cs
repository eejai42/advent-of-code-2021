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
        public DiagnosticReport DiagnosticReport { get; private set; }

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
            this.DiagnosticReport = new DiagnosticReport(readings);
        }

        [Test]
        public void Part1()
        {
            int gamma = this.DiagnosticReport.CalculateGamma();
            int epsilon = this.DiagnosticReport.CalculateEpsilon();
            var answer = gamma * epsilon;
            Assert.IsTrue(answer == 4103154);
        }

        [Test]
        public void Part2()
        {
            int o2Rating = this.DiagnosticReport.CalculateOxygenGeneratorRating();
            int co2Rating = this.DiagnosticReport.CalculateC02ScrubberRating();
            var answer = o2Rating * co2Rating;
            Assert.IsTrue(answer == 4245351);
        }

    }
}
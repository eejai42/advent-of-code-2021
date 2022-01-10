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
        public void Part1()
        {
            var school = new School(this.RawValues);
            school.DaysPass(80);
            var schoolSize = school.GetCurrentCount();
            Assert.IsTrue(schoolSize == 346063);
        }

        [Test]
        public void Part2()
        {
            var school = new School(this.RawValues);
            school.DaysPass(256);
            var schoolSize = school.GetCurrentCount();
            Assert.IsTrue(schoolSize == 1572358335990);
        }
    }
}
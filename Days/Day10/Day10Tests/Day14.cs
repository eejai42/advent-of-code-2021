using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14Tests
{
    public class Tests
    {
        public List<String> RawValues { get; private set; }
        public object InitialCode { get; private set; }

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
            var parser = new Parser();
            var invalidMessages = this.RawValues.Where(message => parser.IsInvalid(message)).ToList();
            var errorScore = invalidMessages.Sum(message => (int)parser.GetErrorScore(message));
            Assert.IsTrue(errorScore == -1);
        }
    }
}
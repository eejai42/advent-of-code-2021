using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day09Tests
{
    public class Tests
    {
        public List<string> Lines { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Lines = File.ReadAllText("../../../Input.txt")
                            .Split(Environment.NewLine)
                            .ToList();
        }

        [Test]
        public void Test1()
        {
            var floorMapper = new FloorMapper(this.Lines);
            floorMapper.FindLowPoings();
            Assert.Pass();
        }
    }
}
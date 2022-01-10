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
        public void Part1()
        {
            var floorMapper = new FloorMapper(this.Lines);
            floorMapper.FindLowPoints();
            var risk = floorMapper.LowPoints.Sum(riskLevel => riskLevel + 1);
            Assert.IsTrue(risk == 526);
        }

        [Test]
        public void Part2()
        {
            var floorMapper = new FloorMapper(this.Lines);
            floorMapper.FindLowPoints();
            floorMapper.CalculatBasins();
            var bigBasins = floorMapper.BasinSizes
                                    .OrderByDescending(size => size)
                                    .ToList();



            var risk = bigBasins[0] * bigBasins[1] * bigBasins[2];
            Assert.IsTrue(risk == 1123524);
        }
    }
}
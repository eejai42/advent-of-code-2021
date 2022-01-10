using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14Tests
{
    public class Tests
    {
        public string StartingPolymer { get; private set; }
        internal List<String> MapValues { get; private set; }

        [SetUp]
        public void Setup()
        {
            var values = File.ReadAllText("../../../Input.txt").Split(Environment.NewLine);
            this.StartingPolymer = values.First();
            this.MapValues = values.Skip(2).ToList();
        }

        [Test]
        public void Part1()
        {
            var polyMgr = new PolymerMgr(this.StartingPolymer, this.MapValues);
            polyMgr.InsertPairsXTimes(10);
            var score = polyMgr.CalculateScore();
            Assert.IsTrue(score == 3143);
        }

        [Test]
        public void Part2()
        {
            var polyMgr = new PolymerMgr(this.StartingPolymer, this.MapValues);
            polyMgr.InsertPairsXTimes(40);
            var score = polyMgr.CalculateScore();
            Assert.IsTrue(score == 4110215602456);
        }

    }
}
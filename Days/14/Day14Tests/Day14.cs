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
        internal List<Map> Keys { get; private set; }

        [SetUp]
        public void Setup()
        {
            var values = File.ReadAllText("../../../Input.txt").Split(Environment.NewLine);
            this.StartingPolymer = values.First();
            this.Keys = values.Skip(2).Select(value => new Map(value)).ToList();
        }

        [Test]
        public void Test1()
        {
            var polyMgr = new PolymerMgr(this.StartingPolymer, this.Keys);
            polyMgr.InsertPairsXTimes(10);
            var score = polyMgr.CalculateScore();
            Assert.IsTrue(score = 3143);
        }
    }
}
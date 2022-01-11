using NUnit.Framework;
using System.IO;

namespace Day11Tests
{
    public class Tests
    {
        public string Input { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Input = File.ReadAllText("../../../Input.txt");
        }

        [Test]
        public void Part1()
        {
            var cave = new Cave(this.Input);
            var output = cave.ChartPath(100);
             Assert.IsTrue(output == -1);
        }


        [Test]
        public void Part2()
        {
            var cave = new Cave(this.Input);
            var output = cave.ChartPathUntilSynchronized();
            Assert.IsTrue(output == -1);
        }
    }
}
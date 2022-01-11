using NUnit.Framework;
using System.IO;

namespace Day08Tests
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
            var decoder = new EnigmaDecoder(this.Input);
            decoder.AnalyzeInput();
            var score = decoder.GetScore();
            Assert.IsTrue(score == 476);
        }

        [Test]
        public void Part2()
        {
            var decoder = new EnigmaDecoder(this.Input);
            decoder.AnalyzeInput();
            var score = decoder.SumAnswers();
            Assert.IsTrue(score == 1011823);
        }
    }
}
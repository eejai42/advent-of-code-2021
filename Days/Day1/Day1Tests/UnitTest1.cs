using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day1Tests
{
    public class Tests
    {
        public List<string> Input { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Input = File.ReadAllText("../../../Input.txt")
                                .Split(Environment.NewLine)
                                .ToList();
        }

        [Test]
        public void Test1()
        {
            var input = this.Input;
            var sb = new StringBuilder();
            int last = -1;
            var increases = 0;
            for (int i = 0; i < input.Count; i++)
            {
                var value = Int32.Parse(this.Input[i]);
                var isIncrease = (value - last) > 0;
                var isFirst = last == -1;
                if (!isFirst && isIncrease) increases++;
                sb.AppendLine($"{value} ({(last == -1 ? "N/A - no previous measurement" : (isIncrease ? "increased" : "decreased"))})");
                last = value;
            }
            sb.AppendLine($"There were {increases} increases");
            var output = sb.ToString();

            Assert.IsTrue(increases == 1676);
        }


        [Test]
        public void Test2()
        {
            var sb = new StringBuilder();
            List<Int32> windows = this.ComputeWindows();
            int last = -1;
            var increases = 0;
            for (int i = 0; i < this.Input.Count; i++)
            {
                var value = Int32.Parse(this.Input[i]);
                var isIncrease = (value - last) > 0;
                var isFirst = last == -1;
                if (!isFirst && isIncrease) increases++;
                sb.AppendLine($"{value} ({(last == -1 ? "N/A - no previous measurement" : (isIncrease ? "increased" : "decreased"))})");
                last = value;
            }
            sb.AppendLine($"There were {increases} increases");
            var output = sb.ToString();

            Assert.Pass();
        }

        private List<int> ComputeWindows()
        {
            throw new NotImplementedException();
        }
    }
}
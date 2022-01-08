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
        public List<Int32> Input { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Input = File.ReadAllText("../../../Input.txt")
                                .Split(Environment.NewLine)
                                .Select(strValue => Int32.Parse(strValue))
                                .ToList();
        }

        [Test]
        public void Day1()
        {
            var input = this.Input;
            int increases = CalculateIncreases(input);

            Assert.IsTrue(increases == 1676);
        }

        private static int CalculateIncreases(List<Int32> input)
        {
            var sb = new StringBuilder();
            int last = -1;
            var increases = 0;
            for (int i = 0; i < input.Count; i++)
            {
                var value = input[i];
                var isIncrease = (value - last) > 0;
                var isFirst = last == -1;
                if (!isFirst && isIncrease) increases++;
                sb.AppendLine($"{value} ({(last == -1 ? "N/A - no previous measurement" : (isIncrease ? "increased" : "decreased"))})");
                last = value;
            }
            sb.AppendLine($"There were {increases} increases");
            var output = sb.ToString();
            return increases;
        }

        [Test]
        public void Day2()
        {
            var sb = new StringBuilder();
            List<Int32> windows = this.ComputeWindows();
            int increases = CalculateIncreases(windows);

            Assert.IsTrue( increases == 1706);
        }

        private List<int> ComputeWindows()
        {
            var last = 0;
            var last2 = 0;
            var windows = new List<Int32>();
            this.Input.ForEach(value=> {

                if (last > 0 && last2 > 0)
                {
                    windows.Add((last + last2 + value));
                }
                last2 = last;
                last = value;
            });
            return windows;
        }
    }
}
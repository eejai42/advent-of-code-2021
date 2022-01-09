using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Day2Tests
{
    public class Tests
    {
        public List<Reading> Readings { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.SetupInput();
        }

        private void SetupInput()
        {
            this.Readings = File.ReadAllText("../../../Input.txt")
                               .Split(Environment.NewLine)
                               .Select(reading => new Reading(reading))
                               .ToList();
        }

        [Test]
        public void Test1()
        {
            int gamma = this.CalculateGamma();   
            int epsilon = this.CalculateEpsilon();
            var answer = gamma * epsilon;
            Assert.IsTrue(answer == 4103154);
        }

        private int CalculateEpsilon()
        {
            var half = this.Readings.Count / 2;
            var gammaString = String.Empty;
            for (int position = 1; position <= 12; position++)
            {
                gammaString += this.CountOnesAtPosition(position) > half ? "0" : "1";
            }
            return this.BinaryStringToDecimal(gammaString);
        }

        private int CalculateGamma()
        {
            var half = this.Readings.Count / 2;
            var gammaString = String.Empty;
            for (int position = 1; position <= 12; position++) { 
                gammaString += this.CountOnesAtPosition(position) > half ? "1" : "0";
            }
            return this.BinaryStringToDecimal(gammaString);
        }

        private int BinaryStringToDecimal(string binaryString)
        {
            var binaryNumber = Int64.Parse(binaryString);
            long decimalValue = 0;
            // initializing base1 value to 1, i.e 2^0 
            int base1 = 1;

            while (binaryNumber > 0)
            {
                var reminder = binaryNumber % 10;
                binaryNumber = binaryNumber / 10;
                decimalValue += reminder * base1;
                base1 = base1 * 2;
            }
            return (int)decimalValue;
        }

        private int CountOnesAtPosition(int position)
        {
            return this.Readings.Count(reading => reading.BinaryString[position - 1] == '1');
        }
    }
}
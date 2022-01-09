using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2Tests
{
    public class DiagnosticReport
    {
        private List<Reading> Readings;

        public DiagnosticReport(List<Reading> readings)
        {
            this.Readings = readings;
        }

        public int CalculateEpsilon()
        {
            var half = this.Readings.Count / 2;
            var gammaString = String.Empty;
            for (int position = 1; position <= 12; position++)
            {
                gammaString += this.CountOnesAtPosition(position) > half ? "0" : "1";
            }
            return this.BinaryStringToDecimal(gammaString);
        }

        public int CalculateGamma()
        {
            var half = this.Readings.Count / 2;
            var gammaString = String.Empty;
            for (int position = 1; position <= 12; position++)
            {
                gammaString += this.CountOnesAtPosition(position) > half ? "1" : "0";
            }
            return this.BinaryStringToDecimal(gammaString);
        }

        internal int CalculateOxygenGeneratorRating()
        {
            var readings = this.Readings.ToList();
            var currentPosition = 1;
            while (readings.Count > 1)
            {
                var countOfOnes = this.CountOnesAtPosition(readings, currentPosition);
                if (countOfOnes == readings.Count / 2.0)
                {
                    object o = 1;
                }
                var valueToKeep = countOfOnes >= (readings.Count / 2.0) ? '1' : '0';
                readings = readings.Where(reading => reading.BinaryString[currentPosition - 1] == valueToKeep).ToList();
                currentPosition++;
            }
            return readings[0].Value;
        }

        public int CalculateC02ScrubberRating()
        {
            var readings = this.Readings.ToList();
            var currentPosition = 1;
            while (readings.Count > 1)
            {
                var countOfOnes = this.CountOnesAtPosition(readings, currentPosition);
                if (countOfOnes == readings.Count / 2)
                {
                    object o = 1;
                }
                var valueToKeep = countOfOnes < (readings.Count / 2.0) ? '1' : '0';
                readings = readings.Where(reading => reading.BinaryString[currentPosition - 1] == valueToKeep).ToList();
                currentPosition++;
            }
            return readings[0].Value;
        }

        private int CountOnesAtPosition(int position)
        {
            return this.CountOnesAtPosition(this.Readings, position);
        }
        private int CountOnesAtPosition(List<Reading> readings, int position)
        {
            return readings.Count(reading => reading.BinaryString[position - 1] == '1');
        }

        private int CountZerosAtPosition(List<Reading> readings, int position)
        {
            return readings.Count - this.CountOnesAtPosition(readings, position);
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

    }
}
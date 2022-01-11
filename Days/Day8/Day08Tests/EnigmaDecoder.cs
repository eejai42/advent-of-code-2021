using System;
using System.Collections.Generic;
using System.Linq;

namespace Day08Tests
{
    internal class EnigmaDecoder
    {
        public List<TrainingData> TrainingDatas { get; }
        public Digit[] Digits { get; private set; }

        public EnigmaDecoder(string input)
        {
            this.TrainingDatas = input.Split(Environment.NewLine)
                                        .ToList()
                                        .Select(line => new TrainingData(this, line))
                                        .ToList();
            this.CreateDigits();
        }

        private void CreateDigits()
        {
            this.Digits = new Digit[10];
            this.Digits[0] = new Digit(0, "abcefg");
            this.Digits[1] = new Digit(1, "cf");
            this.Digits[2] = new Digit(2, "acdeg");
            this.Digits[3] = new Digit(3, "acdfg");
            this.Digits[4] = new Digit(4, "bcdf");
            this.Digits[5] = new Digit(5, "abdfg");
            this.Digits[6] = new Digit(6, "abdefg");
            this.Digits[7] = new Digit(7, "acf");
            this.Digits[8] = new Digit(8, "abcdefg");
            this.Digits[9] = new Digit(9, "abcdfg");
        }

        internal int SumAnswers()
        {
            var sum = this.TrainingDatas.Sum(td => td.AnswerValue);
            var lowValues = this.TrainingDatas.Where(td => td.AnswerValue < 1000);
            return sum;
        }

        internal void AnalyzeInput()
        {
            this.TrainingDatas.ForEach(td => td.Train());
        }

        internal int GetScore()
        {
            var matchedCandidates = this.TrainingDatas.SelectMany(trainingData => trainingData.Answers.Where(where => where.HasMatch));
            return matchedCandidates.Count();
        }
    }
}
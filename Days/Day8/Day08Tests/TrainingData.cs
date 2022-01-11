using System;
using System.Collections.Generic;
using System.Linq;

namespace Day08Tests
{
    internal class TrainingData
    {
        public EnigmaDecoder Decoder { get; }
        public List<CandidateKey> Candidates { get; }
        public List<CandidateKey> Answers { get; }
        public int AnswerValue
        {
            get
            {
                var str = String.Join("", this.Answers.Where(answer => !(answer.Digit is null)).Select(answer => answer.Digit.Number));
                if (String.IsNullOrEmpty(str)) str = "0";
                return Int32.Parse(str);
            }
        }

        private string line;

        public TrainingData(EnigmaDecoder enigmaDecoder, string line)
        {
            this.Decoder = enigmaDecoder;
            this.line = line;
            var parts = line.Split(" | ");
            var part = parts[0];
            this.Candidates = this.CreateCandidateKeys(parts[0]);
            this.Answers = this.CreateCandidateKeys(parts[1]);
        }

        private List<CandidateKey> CreateCandidateKeys(string part)
        {
            var candidates = part.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(candidateKey => new CandidateKey(this, candidateKey)).ToList(); ;
            return candidates;
        }

        public override string ToString()
        {
            return $"{this.line} = {this.AnswerValue}";
        }

        internal void Train()
        {
            this.Candidates.ForEach(candidate =>
            {
                this.TrainCandidate(candidate);
            });

            this.FillInGaps();
            this.CompleteAnswer();
        }

        private void CompleteAnswer()
        {
            this.Answers.ForEach(answer => this.CompleteAnswer(answer));
        }

        private void CompleteAnswer(CandidateKey answer)
        {
            var candidate = this.Candidates.FirstOrDefault(fod => String.Join("", answer.InputKey.OrderBy(chr => chr)) == String.Join("", fod.InputKey.OrderBy(chr => chr)));
            if (!(candidate is null)) answer.Digit = candidate.Digit;
        }

        private void FillInGaps()
        {
            this.FindFive();
            this.FindZeroSizeAndNine();
            this.FindTwoAndThree();
        }

        
        private void FindTwoAndThree()
        {
            var candidates = this.Candidates.Where(candidate => (candidate.InputKey.Length == 5));

            var one = this.GetCandidate(1);
            var three = candidates.Where(cand => one.InputKey.All(chr => cand.InputKey.Contains(chr))).Single();
            three.Digit = this.Decoder.Digits[3];

            var two = candidates.Where(cand => cand.Digit is null).Single();
            two.Digit = this.Decoder.Digits[2];
        }

        private void FindFive()
        {
            var one = this.GetCandidate(1);
            var four = this.GetCandidate(4);
            var unusedSignals = String.Join("", four.InputKey.Where(where => !one.InputKey.Any(any => any == where)));
            var fiveCandidates = this.Candidates.Where(candidate => candidate.InputKey.Length == 5);
            var five = fiveCandidates.Where(where => where.InputKey.Contains(unusedSignals[0]) && where.InputKey.Contains(unusedSignals[1])).First();
            five.Digit = this.Decoder.Digits[5];
        }

        
        private void FindZeroSizeAndNine()
        {
            var sixDigitCandidates = this.Candidates.Where(candidate => (candidate.InputKey.Length == 6));

            var four = this.GetCandidate(4);
            var nine = sixDigitCandidates.Where(cand => four.InputKey.All(chr => cand.InputKey.Contains(chr))).Single();
            nine.Digit = this.Decoder.Digits[9];

            var one = this.GetCandidate(1);
            var zero = sixDigitCandidates.Where(cand => (cand.Digit is null) && one.InputKey.All(chr => cand.InputKey.Contains(chr))).Single();
            zero.Digit = this.Decoder.Digits[0];


            var six = sixDigitCandidates.Where(candidate => candidate.Digit is null).Single();
            six.Digit = this.Decoder.Digits[6];


        }

        private CandidateKey GetCandidate(int number)
        {
            var digit = this.Decoder.Digits[number];
            return this.Candidates.First(candidate => candidate.Digit == digit);
        }

        private void TrainCandidate(CandidateKey candidate)
        {
            var matchingDigits = this.Decoder.Digits.Where(digit => digit.Segments.Length == candidate.InputKey.Length);
            if (matchingDigits.Count() == 1)
            {
                candidate.Digit = matchingDigits.First();
            }
        }
    }
}
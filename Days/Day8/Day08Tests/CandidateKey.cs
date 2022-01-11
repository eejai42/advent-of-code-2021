using System.Linq;

namespace Day08Tests
{
    internal class CandidateKey
    {
        public string InputKey;

        public CandidateKey(TrainingData trainingData, string candidateKey)
        {
            this.InputKey = candidateKey;
        }

        public Digit Digit { get; internal set; }
        public bool HasMatch { get { return !(this.Digit is null) && new int[] { 1, 4, 7, 8 }.Contains(this.Digit.Number); } }

        public override string ToString()
        {
            var digitKey = string.Empty;
            if (!(this.Digit is null))
            {
                digitKey = $" ({this.Digit.Number} - {this.Digit.Segments})";
            }
            return $"{this.InputKey}{digitKey}";
        }
    }
}
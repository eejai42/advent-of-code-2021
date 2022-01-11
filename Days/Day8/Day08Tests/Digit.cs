namespace Day08Tests
{
    internal class Digit
    {
        public int Number;
        public string Segments;

        public Digit(int number, string segments)
        {
            this.Number = number;
            this.Segments = segments;
        }

        public override string ToString()
        {
            return $"{this.Number} - {this.Segments}";
        }
    }
}
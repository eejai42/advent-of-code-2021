namespace Day14Tests
{
    internal class Map
    {
        public Map(string value)
        {
            this.Pair = value.Substring(0, 2);
            this.Insert = value.Substring(value.Length - 1);
        }

        public string Pair { get; }
        public string Insert { get; }
    }
}
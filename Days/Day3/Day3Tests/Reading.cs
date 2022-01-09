using System;

namespace Day2Tests
{
    public class Reading
    {
        public Reading(string reading)
        {

            this.BinaryString = reading;
        }

        public string BinaryString { get; }
        public int Value
        {
            get { return BinaryStringToDecimal(this.BinaryString); }
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

        public override string ToString()
        {
            return $"{this.BinaryString}";
        }
    }
}
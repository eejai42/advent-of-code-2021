using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6Tests
{
    internal class School
    {

        public List<Fish> Fish { get; }

        public School(List<string> rawValues)
        {
            this.Day = 0;
            var timers = rawValues[0].Split(",").Select(value => Int32.Parse(value));
            this.Fish = timers.Select(timer => new Fish(this, timer)).ToList();
        }

        public int Day;

        internal void DaysPass(int days)
        {
            for (int day = 0; day < days; day++)
            {
                this.Day = day;
                this.Fish
                    .ToList()
                    .ForEach(fish => fish.DayPasses());
            }
        }

        public override string ToString()
        {
            return String.Join(",", this.Fish.Select(fish => fish.Timer));
        }
    }
}
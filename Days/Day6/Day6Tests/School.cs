using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6Tests
{
    internal class School
    {

        public List<Fish> Fish { get; }
        public long[] PopulationCounts { get; private set; }

        public School(List<string> rawValues)
        {
            this.Day = 0;
            var timers = rawValues[0].Split(",").Select(value => Int32.Parse(value));
            this.Fish = timers.Select(timer => new Fish(this, timer)).ToList();
        }

        public int Day;

        internal void DaysPass(int days)
        {
            this.PopulationCounts = new long[9];
            this.Fish.ForEach(fish => this.PopulationCounts[fish.Timer]++);
            for (int day = 1; day <= days; day++)
            {
                this.PassOneDay();
            }
        }

        private void PassOneDay()
        {
            var breaders = this.PopulationCounts[0];
            for (int i = 0; i < 8; i++)
            {
                this.PopulationCounts[i] = this.PopulationCounts[i + 1];
            }
            this.PopulationCounts[8] = breaders;
            this.PopulationCounts[6] += breaders;
        }

        internal long GetCurrentCount()
        {
            return this.PopulationCounts.Sum();
        }

        public override string ToString()
        {
            return String.Join(",", this.Fish.Select(fish => fish.Timer));
        }
    }
}
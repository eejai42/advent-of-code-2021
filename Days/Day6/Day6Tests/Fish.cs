using System;

namespace Day6Tests
{
    internal class Fish
    {
        public School School;

        public int Timer;

        public Fish(School school, int timer)
        {
            this.School = school;
            this.Timer = timer;
        }

        internal void DayPasses()
        {
            this.Timer--;
            if (this.Timer == -1) this.SpawNewFish();
        }

        private void SpawNewFish()
        {
            this.Timer = 6;
            var child = new Fish(this.School, 8);
            this.School.Fish.Add(child);
        }
    }
}
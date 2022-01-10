using System;
using System.Linq;
using System.Collections.Generic;

namespace Day14Tests
{
    internal class PolymerMgr
    {
        public List<Map> Keys;
        private string StartingPolymer;

        public char LastLetter { get; }

        public PolymerMgr(string startingPolymer, List<string> mapValues)
        {
            this.Keys = mapValues.Select(value => new Map(this, value)).ToList();
            this.Keys.ForEach(key => key.FindSplitKeys());
            this.StartingPolymer = startingPolymer;
            this.LastLetter = this.StartingPolymer.Last();
            this.ParsePolymer();
        }

        private void ParsePolymer()
        {
            var pairs = this.ConvertPolymerToPairs();
            pairs.ForEach(pair =>
            {
                var key = this.Keys.First(key => key.Pair == pair);
                key.InstanceCount += 1;
            });
        }

        internal long CalculateScore()
        {
            var pairCounts = this.Keys.Select(key => new { Letter = key.Pair[0], InstanceCount = (long)key.InstanceCount });
            var groupedByletter = pairCounts.GroupBy(counts => counts.Letter);
            var sumOfLetterGroups = groupedByletter.Select(letterCounts => 
                                        new { Letter = letterCounts.Key, 
                                            InstanceCount = (long)letterCounts.Sum(letterCount => letterCount.InstanceCount) + 
                                                                            (letterCounts.Key == this.LastLetter ? 1 : 0) 
                                        }).OrderByDescending(letterCount => letterCount.InstanceCount)
                                          .ToList();
            var letterCounts = sumOfLetterGroups;

            var mostCommon = letterCounts.First().InstanceCount;
            var leastCommon = letterCounts.Last().InstanceCount;
            return mostCommon - leastCommon;
        }

        internal void InsertPairsXTimes(int numberOfTimes)
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                this.SplitPairs();
            }
        }

        private void SplitPairs()
        {
            this.Keys.ForEach(key => key.Split());
            this.Keys.ForEach(key => key.Combine());
        }

        private List<string> ConvertPolymerToPairs()
        {
            var lastChar = '\0';
            var pairs = new List<String>();
            this.StartingPolymer.ToList().ForEach(chr =>
            {
                if (lastChar != '\0')
                {
                    pairs.Add($"{lastChar}{chr}");
                }
                lastChar = chr;
            });
            return pairs;
        }
    }
}
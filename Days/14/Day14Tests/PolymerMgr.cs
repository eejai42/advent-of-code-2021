using System;
using System.Linq;
using System.Collections.Generic;

namespace Day14Tests
{
    internal class PolymerMgr
    {
        private string StartingPolymer;
        private List<Map> Keys;

        public PolymerMgr(string startingPolymer, List<Map> keys)
        {
            this.StartingPolymer = startingPolymer;
            this.Keys = keys;
        }

        internal int CalculateScore()
        {
            var grps = this.StartingPolymer.GroupBy(chr => chr);
            var sortedGrps = grps.OrderByDescending(grp => grp.Count())
                                 .Select(grp => grp.Count())
                                 .ToList();
            var score = sortedGrps.First() - sortedGrps.Last();
            return score;
        }

        internal void InsertPairsXTimes(int numberOfTimes)
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                this.InsertPairsOnce();
            }
        }

        private void InsertPairsOnce()
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
            var insertedPairs = pairs.Select(pair => this.Insert(pair)).ToList();
            this.StartingPolymer = String.Join(String.Empty, insertedPairs) + pairs.Last()[1];
            
        }

        private string Insert(string pair)
        {
            var key = this.Keys.First(first => first.Pair == pair);
            return $"{pair[0]}{key.Insert}";
        }
    }
}
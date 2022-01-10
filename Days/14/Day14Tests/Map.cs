using System;
using System.Linq;

namespace Day14Tests
{
    internal class Map
    {
        public Map(PolymerMgr mgr, string value)
        {
            this.Mgr = mgr;
            this.Pair = value.Substring(0, 2); // AB
            this.CharacterToInsert = value.Substring(value.Length - 1); // C
            this.SplitKey1 = default(Map);
            this.SplitKey2 = default(Map);
            this.DeferredInstanceCount = 0;
        }

        public PolymerMgr Mgr { get; }

        internal void FindSplitKeys()
        {
            this.SplitKey1 = this.Mgr.Keys.First(key => key.Pair == $"{this.Pair[0]}{this.CharacterToInsert}"); // -> AC
            this.SplitKey2 = this.Mgr.Keys.First(key => key.Pair == $"{this.CharacterToInsert}{this.Pair[1]}"); // -> CB
        }

        public string Pair { get; }
        public string CharacterToInsert { get; }
        public Map SplitKey1 { get; set; }
        public Map SplitKey2 { get; set;  }
        public long InstanceCount { get; internal set; }
        public long DeferredInstanceCount { get; internal set; }

        internal void Split()
        {
            this.SplitKey1.DeferredInstanceCount += this.InstanceCount;
            this.SplitKey2.DeferredInstanceCount += this.InstanceCount;
        }

        internal void Combine()
        {
            this.InstanceCount = this.DeferredInstanceCount;
            this.DeferredInstanceCount = 0;
        }

        public override string ToString()
        {
            return $"{this.InstanceCount}: {this.Pair} -> {this.CharacterToInsert}{(this.DeferredInstanceCount > 0 ? $" ({this.DeferredInstanceCount})" : "")}";
        }
    }
}
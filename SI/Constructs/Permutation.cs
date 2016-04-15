using System;
using System.Collections.Generic;

namespace SI.Constructs
{
    public class Permutation : List<double>, IComparable<Permutation>
    {
        public double Cost { get; set; }

        public int CompareTo(Permutation other)
        {

            if (Math.Abs(this.Cost - other.Cost) < 0.01) return 0;

            return (int)(this.Cost > other.Cost ? 1 : -1);
        }
    }
}
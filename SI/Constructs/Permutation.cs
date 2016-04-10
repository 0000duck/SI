using System;
using System.Collections.Generic;

namespace SI.Constructs
{
    public class Permutation : List<double>, IComparable<Permutation>
    {
        public double Cost { get; set; }

        public int CompareTo(Permutation other)
        {
            var roznica = this.Cost - other.Cost;

            if (roznica == 0) return (int) roznica;

            return (int) (roznica >= 0 ? 1 : -1);
        }
    }
}
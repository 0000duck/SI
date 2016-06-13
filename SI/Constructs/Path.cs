using System;
using System.Collections.Generic;

namespace SI.Constructs
{
    public class Path : List<double>, IComparable<Path>
    {
        public double Cost { get; set; }

        public int CompareTo(Path other)
        {

            if (Math.Abs(this.Cost - other.Cost) < 0.01) return 0;

            return (int)(this.Cost > other.Cost ? 1 : -1);
        }
    }
}
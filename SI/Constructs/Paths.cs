using System.Collections.Generic;
using System.IO;

namespace SI.Constructs
{
    public class Paths : List<Path>
    {
        private readonly int _permutationsLength;

        public Paths(int permutationsLength)
        {
            _permutationsLength = permutationsLength;
        }

        public new void Add(Path item)
        {
            if (item.Count == _permutationsLength)
                base.Add(item);
            else
            {
                throw new InvalidDataException("Paths have wrong length");
            }
        }

        public void Trim()
        {
            this.Sort();
            var tmpCost = this[0].Cost;
            var loop = true;

            while (loop)
            {
                if (this[this.Count-1].Cost > tmpCost)
                {
                    this.RemoveAt(this.Count-1);
                }
                else
                {
                    loop = false;
                }
            }
        }
    }
}
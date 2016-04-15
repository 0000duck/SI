using System.Collections.Generic;
using System.IO;

namespace SI.Constructs
{
    public class Permutations : List<Permutation>
    {
        private readonly int _permutationsLength;

        public Permutations(int permutationsLength)
        {
            _permutationsLength = permutationsLength;
        }

        public new void Add(Permutation item)
        {
            if (item.Count == _permutationsLength)
                base.Add(item);
            else
            {
                throw new InvalidDataException("Permutations have wrong length");
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
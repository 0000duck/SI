using System.Collections.Generic;
using System.IO;

namespace SI.Constructs
{
    public class Permutations : List<Permutation>
    {
        private int _permutationsLength;

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
    }
}
using System;
using SztucznaInteligencja.Containers;

namespace SztucznaInteligencja
{
    public class TspEventArgs :EventArgs
    {
        private readonly Lines _lines;
        public Lines Lines { get; set; }

        public TspEventArgs(Lines lines)
        {
            _lines = lines;
        }
    }
}
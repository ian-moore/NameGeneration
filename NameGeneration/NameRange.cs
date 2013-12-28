using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGeneration
{
    internal class NameRange
    {
        public string Name { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public NameRange(string name, int min, int max)
        {
            Name = name;
            Min = min;
            Max = max;
        }
    }
}

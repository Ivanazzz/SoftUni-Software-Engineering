using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    internal class Cargo
    {
        public Cargo(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type { get; set; }
        public int Weight { get; set; }
    }
}

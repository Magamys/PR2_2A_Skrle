using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanV1
{
    public class TargetSpot
    {
        public int X { get; set; }
        public int Y { get; set; }

        public TargetSpot(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

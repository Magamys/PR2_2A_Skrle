using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_obchodnici
{
    internal class Cursor
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public void FixCursorPosition(List<Salesman> position)
        {
            if (position.Count == 0)
            {
                Y = 2;
            }
            else if (position.Count < Y)
            {
                Y = position.Count + 2;
            }
        }
    }
}

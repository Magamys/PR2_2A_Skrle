using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_OOP_Dedicnost
{
    internal class Clovek
    {
        public string Jmeno { get; private set; }
        public pohlavi Pohlavi { get; private set; }

        public Clovek(string jmeno, pohlavi pohlavi)
        {
            Jmeno = jmeno;
            Pohlavi = pohlavi;
        }

        public override string ToString()
        {
            return $"Jmenuji se {Jmeno} a jsem {Pohlavi}";
        }
    }
}

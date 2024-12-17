using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_OOP_Dedicnost
{
    internal abstract class Zamestnanec : Clovek
    {
        protected Zamestnanec(string jmeno, pohlavi pohlavi, int Mzda, string Povolani) : base(jmeno, pohlavi)
        {
        }

        public int Mzda { get; private set; }
        public string Povolani { get; private set; }

        public abstract string Pracuj();
    }
}

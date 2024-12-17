using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_OOP_Dedicnost
{
    internal class Ucetni :Zamestnanec
    {
        public Ucetni(string jmeno, pohlavi pohlavi, int Mzda, string povolani) : base(jmeno, pohlavi, Mzda, "Účetní")
        {
        }

        public override string Pracuj()
        {
            return "Kontroluji faktury";
        }
    }
}

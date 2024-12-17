using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_OOP_Dedicnost
{
    internal class Kuchar : Zamestnanec
    {
        public Kuchar(string jmeno, pohlavi pohlavi, int Mzda, string Povolani, string hotel) : base(jmeno, pohlavi, Mzda, "Kuchař")
        {
        }

        private string hotel;

        public override string Pracuj()
        {
            return $"Klepu řízky v hotelu {hotel}";
        }
    }
}

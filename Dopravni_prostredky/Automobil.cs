using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravni_prostredky
{
    internal abstract class Automobil : DopravniProstredek
    {
        protected Automobil(string nazev, TypPohonu pohon, double maxRychlost, int pocetMist) : base(nazev, pohon, maxRychlost, pocetMist)
        {
        }
    }
}

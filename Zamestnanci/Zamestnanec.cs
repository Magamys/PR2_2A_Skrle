using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zamestnanci
{
    internal abstract class Zamestnanec
    {
        public string Jmeno { get; private init; }
        public string Prijmeni { get; private init; }

        //init lze pouze deklarovat a nejde nadále měnit
    
        protected Zamestnanec(string jmeno, string prijmeni)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
        }

        public abstract int Mzda();
    }
}

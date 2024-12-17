using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zamestnanci
{
    internal class StalyZmestnanec : Zamestnanec
    {
        private int _mzda;

        public StalyZmestnanec(string jmeno, string prijmeni, int mzda) : base(jmeno, prijmeni)
        {
            _mzda = mzda;
        }

        public override int Mzda()
        {
            return _mzda;
        }
    }
}

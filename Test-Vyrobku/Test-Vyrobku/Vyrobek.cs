using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_vyrobku
{
    internal class Vyrobek
    {
        private double rozmer;

        public Vyrobek(double rozmer)
        {
            Rozmer = rozmer;
        }

        public double Rozmer
        {
            get { return rozmer; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException();

                rozmer = value;
            }

        }
    }
}

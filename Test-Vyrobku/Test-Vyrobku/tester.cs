using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_vyrobku
{
    internal class tester
    {
        public tester(Vyrobek vzor, double tolerance)
        {
            SetTolerance(tolerance);
            SetVzor(vzor);
        }

        public Vyrobek Vzor { get; private set; }
        public double Tolerance { get; private set; }

        public void SetTolerance(double tolerance)
        {
            if (tolerance >= 0 && tolerance <= 100)
                Tolerance = tolerance;
            else
                throw new ArgumentOutOfRangeException();
        }

        public void SetVzor(Vyrobek vzor)
        {
            if (vzor != null)
                Vzor = vzor;
            else
                throw new ArgumentOutOfRangeException();
        }

        //test

        public bool IsGood(Vyrobek vyrobek, double tolerance)
        {
            if (vyrobek.Rozmer <= (Vzor.Rozmer / 100) * (100 + tolerance) && (vyrobek.Rozmer >= (Vzor.Rozmer / 100) * (100 - tolerance)))
                return true;
            else
                return false;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zamestnanci
{
    internal class Firma
    {
        private List<Zamestnanec> _personal = new List<Zamestnanec>();

        public void Zamestnej(Zamestnanec z)
        {
            if (!_personal.Contains(z))
            {
                _personal.Add(z);
            }
        }

        public void Propust(Zamestnanec z)
        {
            _personal.Remove(z);
        }

        public void Vyplata()
        {
            int total = 0;
            int mzda;

            foreach (Zamestnanec z in _personal)
            {
                mzda = z.Mzda();
                total += mzda;
                Console.WriteLine($"{z.Prijmeni} {z.Jmeno} : {mzda}Kč");
            }

            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"{total} celkem");
        }
    }
}

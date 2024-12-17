using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_OOP_Dedicnost
{
    internal class Skupina
    {
        private List<Zamestnanec> _zamestnanci = new List<Zamestnanec>();

        public Skupina(List<Zamestnanec> zamestnanci)
        {
            _zamestnanci = zamestnanci;
        }

        public static void DoPrace()
        {
            Console.WriteLine($"Pracuje {_zamestnanci.Count} lidí.");

            foreach (Zamestnanec z in _zamestnanci)
            {
                Zamestnanec.Pracuj();
            }
        }

    }
}

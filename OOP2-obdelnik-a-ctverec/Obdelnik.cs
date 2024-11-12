using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_obdelnik_a_ctverec
{
    internal class Obdelnik
    {
        public double StranaA { get; private set; }
        public double StranaB { get; private set; }

        

        public Obdelnik(double stranaA, double stranaB)
        {
            StranaA = stranaA;
            StranaB = stranaB;
        }

        public double Obvod(int obvod)
        {
            return 2 * (StranaA + StranaB);
            
        }
        public double Obsah()
        {
            return StranaA * StranaB;
            
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal interface IVisitList
{
    int Count { get; }
    void Add(Coords place);
    Coords NextPlace();
}

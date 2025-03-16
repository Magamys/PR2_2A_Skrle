using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class RandomVisitList : IVisitList
{
    List<Coords> _list = [];

    public int Count => _list.Count;

    public void Add(Coords place)
    {
        _list.Add(place);
    }

    public Coords NextPlace()
    {
        int index = _random.
    }
}


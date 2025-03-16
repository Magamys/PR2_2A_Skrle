using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class StackVisitList : IVisitList
{
    Stack<Coords> _Stack = [];

    public int Count => _Stack.Count;

    public void Add(Coords place)
    {
        _Stack.Push(place);
    }

    public Coords NextPlace()
    {
        return _Stack.Pop();
    }
}


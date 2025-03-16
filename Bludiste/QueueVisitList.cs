using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class QueueVisitList : IVisitList
{
    Queue<Coords> _queue = [];

    public int Count => _queue.Count;

    public void Add(Coords place)
    {
        _queue.Enqueue(place);
    }

    public Coords NextPlace()
    {
        return _queue.Dequeue();
    }
}


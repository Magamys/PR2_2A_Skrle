using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_obchodnici
{
    internal class Tree
    {
        public Salesman Root { get; set; }
        public Salesman Node { get; set; }
        public Stack<Salesman> Stack { get; set; }
        public List<Salesman> List { get; set; }
        public string Path { get; set; }

        public Tree()
        {
            string jsonString = File.ReadAllText("largetree.json");
            Root = Salesman.DeserializeTree(jsonString);
            Node = Salesman.DeserializeTree(jsonString);

            Stack = new Stack<Salesman>();
            List = new List<Salesman>();

            Path = "";
        }
    }
}

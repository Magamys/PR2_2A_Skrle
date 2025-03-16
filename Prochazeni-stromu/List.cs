using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_obchodnici
{
    internal class List
    {
        public bool ListWarning(List<Salesman> list, Tree tree)
        {
            Console.Clear();
            Console.WriteLine($"Chceš uložit svůj seznam? Y/N");
            string input = Console.ReadLine();

            if (input.ToUpper() == "Y")
            {
                SaveList(list, tree);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddSalesman(Salesman salesman, List<Salesman> list)
        {
            list.Add(salesman);
            return true;
        }

        public bool RemoveSalesman(Salesman salesman, List<Salesman> list)
        {
            if (list.Contains(salesman))
            {
                list.Remove(salesman);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveList(List<Salesman> list, Tree tree)
        {
            string path = tree.Path;

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Salesman s = list[i];

                    writer.WriteLine($"{s.ID}");
                }
            }

            return true;
        }


        public Tuple<List<Salesman>, string> LoadList(Salesman root, Tree tree)
        {
            Console.Write("Zadej název souboru: ");
            string path = Console.ReadLine();

            tree.Path = path + ".txt";

            if (!File.Exists(tree.Path))
            {
                return Tuple.Create(new List<Salesman>(), "");
            }

            List<Salesman> list = new List<Salesman>();

            string[] tmp = File.ReadAllLines(tree.Path);

            for (int i = 0; i < tmp.Length; i++)
            {
                int num = int.Parse(tmp[i]);

                Salesman salesman = FindSalesmanById(root, num);

                if (salesman != null)
                {
                    list.Add(salesman);
                }
            }

            return Tuple.Create(list, path);
        }

        public bool CreateList(Tree tree)
        {
            Console.Write($"Zadej název souboru: ");
            string input = Console.ReadLine();

            try
            {
                File.Create($"{input}.txt");
                tree.Path = input + ".txt";

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Salesman FindSalesmanById(Salesman root, int id)
        {
            if (root == null)
            {
                return null;
            }

            Queue<Salesman> toBeVisited = new Queue<Salesman>();
            toBeVisited.Enqueue(root);

            while (toBeVisited.Count > 0)
            {
                Salesman node = toBeVisited.Dequeue();

                if (node.ID == id)
                {
                    return node;
                }

                foreach (Salesman salesman in node.Subordinates)
                {
                    toBeVisited.Enqueue(salesman);
                }
            }

            return null;
        }
    }
}

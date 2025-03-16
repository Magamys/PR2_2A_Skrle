using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_obchodnici
{
    internal class Render
    {
        public void RenderIF(Salesman node, Salesman root, Stack<Salesman> stack, List<Salesman> list, Cursor position)
        {
            Console.SetCursorPosition(0, 0);

            if (position.X == 0 && position.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"Přejít nahoru");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Přejít nahoru");
                Console.ResetColor();
            }

            Console.Write($"    |   ");

            if (position.X == 1 && position.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Přejít na seznam");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Přejít na seznam");
                Console.ResetColor();
            }

            Console.WriteLine("-------------------------------------");
            Console.Write($"Obchodník: {node.Name} {node.Surname}");

            if (position.Y == 1)
            {
                if (position.X == 0)
                {
                    position.X = 1;
                }

                if (list.Contains(node))
                {
                    Console.SetCursorPosition(30, 2);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Odebrat");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(31, 2);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Přidat");
                    Console.ResetColor();
                }
            }
            else
            {
                if (list.Contains(node))
                {
                    Console.SetCursorPosition(30, 2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Odebrat");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(31, 2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Přidat");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Přímé prodeje: {node.Sales}$");
            Console.WriteLine($"Celkové prodeje sítě: {GetTotalSales(node)}$");

            if (stack.Count > 0)
            {
                if (position.Y == 2)
                {
                    Console.WriteLine("-------------------------------------");
                    Console.Write($"Nadřízený: ");
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{stack.Peek().Name} {stack.Peek().Surname}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"Nadřízený: {stack.Peek().Name} {stack.Peek().Surname}");
                }
            }

            Console.WriteLine("-------------------------------------");

            if (node.Subordinates.Count > 0)
            {
                Console.Write($"Podřízení: ");

                for (int i = 0; i < node.Subordinates.Count; i++)
                {
                    if (position.Y == i + 3)
                    {
                        if (i == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine($"{node.Subordinates[i].Name} {node.Subordinates[i].Surname}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"           ");
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine($"{node.Subordinates[i].Name} {node.Subordinates[i].Surname}");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Console.WriteLine($"{node.Subordinates[i].Name} {node.Subordinates[i].Surname}");
                        }
                        else
                        {
                            Console.WriteLine($"           {node.Subordinates[i].Name} {node.Subordinates[i].Surname}");
                        }
                    }
                }

                Console.WriteLine("-------------------------------------");
            }
        }

        public void RenderList(List<Salesman> list, Cursor position, Tree tree)
        {
            Console.Clear();

            if (position.X == 0 && position.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Založit");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Založit");
                Console.ResetColor();
            }

            Console.Write("    |    ");

            if (position.X == 1 && position.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Načíst");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Načíst");
                Console.ResetColor();
            }

            Console.Write("    |    ");

            if (position.X == 2 && position.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Uložit");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Uložit");
                Console.ResetColor();
            }

            Console.Write("    |    ");

            if (position.X == 3 && position.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Přejít na prohlížeč");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Přejít na prohlížeč");
                Console.ResetColor();
            }

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Seznam: {tree.Path}");
            Console.WriteLine("-----------------------------------------------------------------");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{list[i].Name} {list[i].Surname}");
            }

            if (list.Count > 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

        static int GetTotalSales(Salesman node)
        {
            if (node == null)
                return 0;

            int totalSales = node.Sales;

            foreach (Salesman subordinate in node.Subordinates)
            {
                totalSales += GetTotalSales(subordinate);
            }

            return totalSales;
        }

    }
}

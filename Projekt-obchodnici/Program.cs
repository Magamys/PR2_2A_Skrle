using System.Collections.Generic;
using System.Reflection;

namespace Projekt_obchodnici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cursor mainCursor = new Cursor(); 
            Cursor listCursor = new Cursor(); 
            Tree tree = new Tree();
            Render render = new Render();
            List list = new List();

            render.RenderIF(tree.Node, tree.Root, tree.Stack, tree.List, mainCursor);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (mainCursor.Y > 0)
                    {
                        if (tree.Stack.Count == 0 && mainCursor.Y == 3)
                            mainCursor.Y -= 2;
                        else
                            mainCursor.Y--;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (tree.Stack.Count == 0 && mainCursor.Y == 1)
                        mainCursor.Y += 2;
                    else
                        mainCursor.Y++;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (mainCursor.X == 0)
                        mainCursor.X++;

                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (mainCursor.X == 1)
                        mainCursor.X--;
                }

                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    list.ListWarning(tree.List, tree);
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Spacebar)
                {

                    if (mainCursor.Y == 0 && mainCursor.X == 0) 
                    {
                        tree.Node = tree.Root;
                        tree.Stack.Clear();
                    }

                    else if (mainCursor.Y == 0 && mainCursor.X == 1) 
                    {
                        ListNav(listCursor, render, tree, list);
                    }

                    else if (mainCursor.Y == 1 && mainCursor.X == 1) 
                    {
                        if (!tree.List.Contains(tree.Node))
                            list.AddSalesman(tree.Node, tree.List);
                        else
                            list.RemoveSalesman(tree.Node, tree.List);
                    }

                    else if (mainCursor.Y == 2) 
                    {
                        try
                        {
                            tree.Node = tree.Stack.Pop();
                            render.RenderIF(tree.Node, tree.Root, tree.Stack, tree.List, mainCursor);
                        }
                        catch
                        {
                            render.RenderIF(tree.Node, tree.Root, tree.Stack, tree.List, mainCursor);
                        }
                    }
                    else
                    {
                        tree.Stack.Push(tree.Node);
                        tree.Node = tree.Node.Subordinates[mainCursor.Y - 3];
                        mainCursor.FixCursorPosition(tree.Node.Subordinates);
                    }

                    Console.Clear();

                }

                render.RenderIF(tree.Node, tree.Root, tree.Stack, tree.List, mainCursor);
            }
        }

        static void DisplaySalesmenTree(Salesman node, string indent = "")
        {
            Console.WriteLine($"{indent}{node.Name} {node.Surname} - Sales: {node.Sales}");

            foreach (var subordinate in node.Subordinates)
            {
                DisplaySalesmenTree(subordinate, indent + "    ");
            }
        }

        

        static void ListNav(Cursor cursor, Render render, Tree tree, List list)
        {
            render.RenderList(tree.List, cursor, tree);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (cursor.X < 3)
                    {
                        cursor.X++;
                    }


                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (cursor.X > 0)
                    {
                        cursor.X--;

                    }
                }
                else if (keyInfo.Key == ConsoleKey.Spacebar)
                {

                    if (cursor.Y == 0 && cursor.X == 3)
                    {
                        Console.Clear();
                        break;
                    }
                    else if (cursor.Y == 0 && cursor.X == 2)
                    {
                        list.SaveList(tree.List, tree);
                    }
                    else if (cursor.Y == 0 && cursor.X == 1)
                    {
                        var data = list.LoadList(tree.Root, tree);
                        tree.List = data.Item1;
                        tree.Path = data.Item2 + ".txt";
                    }
                    else if (cursor.Y == 0 && cursor.X == 0)
                    {
                        list.CreateList(tree);

                    }
                }
                render.RenderList(tree.List, cursor, tree);

            }

        }

    }
}

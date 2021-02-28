// Автор - Кузьминых Юрий

using System;
using System.Collections.Generic;
using MyLibrary;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuText = @"
1. Реализовать хеш-функцию.
2. Переписать программу, реализующую двоичное дерево поиска.";
            
            Dictionary<string, Action> methods = new Dictionary<string, Action>();
            methods.Add("1", Task1);
            methods.Add("2", Task2);
            
            MyMethods.Menu(methods, menuText);
        }

        private static void Task1()
        {
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();
            Console.WriteLine($"Хеш данной строки: {Hash(str)}");
            Console.WriteLine();
            
            int Hash(object obj)
            {
                string str = obj.ToString();
                int hash = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    hash += (int) Math.Pow(str[i] % 10, i % 5 + 1);
                    if (i != 0)
                        hash += (int) Math.Pow(str[i - 1], 2);
                    hash %= 1000000;
                }

                return hash;
            }
        }

        private static void Task2()
        {
            Random random = new Random();
            BinaryTree<Player> players = new BinaryTree<Player>();
            for (int i = 0; i < 1000; i++)
            {
                players.Add(new Player {Id = i, Name = $"xxXНагибатор{random.Next(1000, 10000)}Xxx"});
            }
            
            Console.WriteLine("Введите Id игрока для получения информации о нём");
            int Id = Int32.Parse(Console.ReadLine());

            Player player = players.Find(x => x.Id == Id, null);
            if (player == null)
            {
                Console.WriteLine("Игрок не найден");
            }
            else
            {
                Console.WriteLine($"Id : {player.Id}");
                Console.WriteLine($"Имя: {player.Name}");
            }
            
            Console.WriteLine();
        }
        
        private class BinaryTree<T> where T : IComparable<T>, IEquatable<T>
        {
            private class BinaryTreeNode
            {
                public T Value;
                public BinaryTreeNode Parent;
                public BinaryTreeNode Left;
                public BinaryTreeNode Right;

                public void Add(T item)
                {
                    int comparisonResult = item.CompareTo(Value);
                    if (comparisonResult > 0)
                    {
                        if (Right == null)
                        {
                            Right = new BinaryTreeNode {Value = item, Parent = this};
                        }
                        else
                        {
                            Right.Add(item);
                        }
                    }
                    else
                    {
                        if (Left == null)
                        {
                            Left = new BinaryTreeNode {Value = item, Parent = this};
                        }
                        else
                        {
                            Left.Add(item);
                        }
                    }
                }
                
                public T Find(Predicate<T> predicate, T returnIfNotFound) // Прямой обход (NLR)
                {
                    if (predicate(Value))
                    {
                        return Value;
                    }

                    if (Left != null)
                    {
                        T leftResult = Left.Find(predicate, returnIfNotFound);
                        if (leftResult != null && !leftResult.Equals(returnIfNotFound))
                        {
                            return leftResult;
                        }
                    }

                    if (Right != null)
                    {
                        T rightResult = Right.Find(predicate, returnIfNotFound);
                        if (rightResult != null && !rightResult.Equals(returnIfNotFound))
                        {
                            return rightResult;
                        }
                    }

                    return returnIfNotFound;
                }
                
                public T FindAlternative(Predicate<T> predicate, T returnIfNotFound) // Центрированный обход (LNR)
                {
                    if (Left != null)
                    {
                        T leftResult = Left.Find(predicate, returnIfNotFound);
                        if (leftResult != null && !leftResult.Equals(returnIfNotFound))
                        {
                            return leftResult;
                        }
                    }

                    if (predicate(Value))
                    {
                        return Value;
                    }
                    
                    if (Right != null)
                    {
                        T rightResult = Right.Find(predicate, returnIfNotFound);
                        if (rightResult != null && !rightResult.Equals(returnIfNotFound))
                        {
                            return rightResult;
                        }
                    }

                    return returnIfNotFound;
                }
            }
            
            private BinaryTreeNode _root;

            public void Add(T item)
            {
                if (_root == null)
                {
                    _root = new BinaryTreeNode {Value = item};
                }
                else
                {
                    _root.Add(item);
                }
            }

            public T Find(Predicate<T> predicate, T returnIfNotFound)
            {
                if (_root == null)
                {
                    return returnIfNotFound;
                }
                else
                {
                    return _root.Find(predicate, returnIfNotFound);
                }
            }
        }
        
        private class Player : IComparable<Player>, IEquatable<Player>
        {
            public int Id;
            public string Name;

            public int CompareTo(Player other) => Id.CompareTo(other.Id);

            public bool Equals(Player other) => other != null && Id.Equals(other.Id);
        }
    }
}
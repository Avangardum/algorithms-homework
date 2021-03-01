using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace Lesson_5
{
    class Program
    {
        private static void Main(string[] args)
        {
            string menuText =
                "3 - Создать функцию, копирующую односвязный список (то есть создающую в памяти копию односвязного списка без удаления первого списка\n" +
                "4 - Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.";
            
            Dictionary<string, Action> methods = new Dictionary<string, Action>();
            methods.Add("3", Task3);
            methods.Add("4", Task4);
            
            MyMethods.Menu(methods, menuText);
        }

        private static void Task3()
        {
            SinglyLinkedListNode<int> firstListHead = new SinglyLinkedListNode<int>
                {Value = 1, Next = new SinglyLinkedListNode<int> {Value = 7, Next = new SinglyLinkedListNode<int> {Value = 9}}};

            Console.WriteLine($"Первый список: {firstListHead.Value} {firstListHead.Next.Value} {firstListHead.Next.Next.Value}");

            SinglyLinkedListNode<int> secondListHead = firstListHead.Copy();
            
            Console.WriteLine($"Второй список: {secondListHead.Value} {secondListHead.Next.Value} {secondListHead.Next.Next.Value}");
        }

        private static void Task4()
        {
            Console.WriteLine("Введите инфиксное выражение, разделяя все элементы пробелами (например, 23 + ( 2 * 3 ) )");
            string infix = Console.ReadLine();
            StringBuilder postfix = new StringBuilder();
            string[] infixElements = infix.Split(' ');
            Program.Stack<string> stack = new Stack<string>();
            
            for (int i = 0; i < infixElements.Length; i++)
            {
                if (IsNumber(infixElements[i]))
                {
                    postfix.Append(infixElements[i]);
                    postfix.Append(" ");
                }
                else if (infixElements[i] == "+" || infixElements[i] == "-" || infixElements[i] == "*" || infixElements[i] == "/")
                {
                    if (stack.IsEmpty() || stack.Peek() == "(")
                    {
                        stack.Push(infixElements[i]);
                    }
                    else if (HasMorePriority(infixElements[i], stack.Peek()))    
                    {
                        stack.Push(infixElements[i]);
                    }
                    else
                    {
                        while (!stack.IsEmpty() && stack.Peek() != "(" && !HasMorePriority(infixElements[i], stack.Peek()))
                        {
                            postfix.Append(stack.Pop());
                            postfix.Append(" ");
                        }
                        stack.Push(infixElements[i]);
                    }
                }
                else if (infixElements[i] == "(")
                {
                    stack.Push(infixElements[i]);
                }
                else if (infixElements[i] == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        postfix.Append(stack.Pop());
                        postfix.Append(" ");
                    }

                    stack.Pop();
                }
            }
            while (!stack.IsEmpty())
            {
                postfix.Append(stack.Pop());
                postfix.Append(" ");
            }

            Console.WriteLine("Постфиксная запись: " + postfix);
            Console.WriteLine();
            
            
            
            bool IsNumber(string str)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return false;
                }
                
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                    {
                        return false;
                    }
                }

                return true;
            }
            
            bool HasMorePriority(string operator1, string operator2)
            {
                return (operator1 == "*" || operator1 == "/") && (operator2 == "+" || operator2 == "-");
            }
        }
        
        private class SinglyLinkedListNode<T>
        {
            public T Value;
            public SinglyLinkedListNode<T> Next;

            public SinglyLinkedListNode<T> Copy()
            {
                SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>();
                node.Value = Value;
                if (Next != null)
                {
                    node.Next = Next.Copy();
                }
                return node;
            }
        }
        
        private class DoublyLinkedListNode<T>
        {
            public T Value;
            public DoublyLinkedListNode<T> Previous;
            public DoublyLinkedListNode<T> Next;
        }

        private class Stack<T>
        {
            private DoublyLinkedListNode<T> _last;

            public void Push(T item)
            {
                if (_last == null)
                {
                    _last = new DoublyLinkedListNode<T>{Value = item};
                }
                else
                {
                    var newNode = new DoublyLinkedListNode<T> {Value = item, Previous = _last};
                    _last.Next = newNode;
                    _last = newNode;
                }
            }

            public T Peek() => _last.Value;

            public bool IsEmpty() => _last == null;

            public T Pop()
            {
                T result = _last.Value;
                _last = _last.Previous;
                if (_last != null)
                {
                    _last.Next = null;
                }
                return result;
            }
        }
    }
}
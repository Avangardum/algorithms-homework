using System;
using System.Collections.Generic;
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
            ListNode<int> firstListHead = new ListNode<int>
                {value = 1, next = new ListNode<int> {value = 7, next = new ListNode<int> {value = 9}}};

            Console.WriteLine($"Первый список: {firstListHead.value} {firstListHead.next.value} {firstListHead.next.next.value}");

            ListNode<int> secondListHead = firstListHead.Copy();
            
            Console.WriteLine($"Второй список: {secondListHead.value} {secondListHead.next.value} {secondListHead.next.next.value}");
        }

        private static void Task4()
        {
            Console.WriteLine("Введите первый операнд");
            string operand1 = Console.ReadLine();
            Console.WriteLine("Введите оператор");
            string _operator = Console.ReadLine();
            Console.WriteLine("Введите второй операнд");
            string operand2 = Console.ReadLine();

            Console.WriteLine($"Инфиксная запись: {operand1} {_operator} {operand2}");
            Console.WriteLine($"Постфиксная запись: {operand1} {operand2} {_operator}");
        }
        
        private class ListNode<T>
        {
            public T value;
            public ListNode<T> next;

            public ListNode<T> Copy()
            {
                ListNode<T> node = new ListNode<T>();
                node.value = value;
                if (next != null)
                {
                    node.next = next.Copy();
                }
                return node;
            }
        }
    }
}
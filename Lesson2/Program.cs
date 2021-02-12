using System;
using System.Collections.Generic;
using MyLibrary;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuText =
                "1 - Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.\n" +
                "2a - Реализовать функцию возведения числа a в степень b без рекурсии.\n" +
                "2b - Реализовать функцию возведения числа a в степень b рекурсивно.\n" +
                "2с - Реализовать функцию возведения числа a в степень b рекурсивно, используя свойство четности степени.";
            Dictionary<string, Action> methods = new Dictionary<string, Action>();
            methods.Add("1", Task1);
            methods.Add("2a", Task2A);
            methods.Add("2b", Task2B);
            methods.Add("2c", Task2C);
            
            MyMethods.Menu(methods, menuText);
        }

        private static void Task1()
        {
            Console.WriteLine("Введите натуральное число");
            int number = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Двоичное представление: {IntegerToBinary(number)}");

            string IntegerToBinary(int num)
            {
                if (num < 0)
                {
                    throw new ArgumentException();
                }

                if (num == 0)
                {
                    return "0";
                }

                if (num == 1)
                {
                    return "1";
                }

                return IntegerToBinary(num / 2) + num % 2;
            }
        }

        private static void Task2A()
        {
            Console.WriteLine("Введите основание степени (натуральное число)");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите показатель степени (натуральное число)");
            int b = Int32.Parse(Console.ReadLine());
            
            int result = 1;
            for (int i = 0; i < b; i++)
            {
                result *= a;
            }
            
            Console.WriteLine($"{a} ^ {b} = {result}");
        }

        private static void Task2B()
        {
            Console.WriteLine("Введите основание степени (натуральное число)");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите показатель степени (натуральное число)");
            int b = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"{a} ^ {b} = {Pow(a, b)}");

            int Pow(int a, int b)
            {
                if (b == 1)
                {
                    return a;
                }

                return Pow(a, b - 1) * a;
            }
        }

        private static void Task2C()
        {
            Console.WriteLine("Введите основание степени (натуральное число)");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите показатель степени (натуральное число)");
            int b = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"{a} ^ {b} = {Pow(a, b)}");

            int Pow(int a, int b)
            {
                if (b == 1)
                {
                    return a;
                }

                if (b == 2)
                {
                    return a * a;
                }

                if (b % 2 == 0)
                {
                    return Pow(Pow(a, b / 2), 2);
                }

                return Pow(a, b - 1) * a;
            }
        }
    }
}
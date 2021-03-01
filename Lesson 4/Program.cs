using System;
using System.Collections.Generic;
using MyLibrary;

namespace Lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuText = "1 - Количество маршрутов с препятствиями. Реализовать чтение массива с препятствием и нахождение количества маршрутов.";
            
            Dictionary<string, Action> methods = new Dictionary<string, Action>();
            methods.Add("1", Task1);
            
            MyMethods.Menu(methods, menuText);
        }

        private static void Task1()
        {
            Console.WriteLine("Введите длину поля (количество строк)");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ширину поля (количество столбцов)");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите карту препятствий. Обозначьте свободные клетки нулями и препятствия единицами без пробелов. Вводите построчно. Пример строки: 00101");
            bool[,] obstacles = new bool[length, width];
            for (int i = 0; i < width; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < length; j++)
                {
                    if (input[j] == '0')
                    {
                        obstacles[i, j] = false;
                    }
                    else if (input[j] == '1')
                    {
                        obstacles[i, j] = true;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введены некорректные данные");
                        return;
                    }
                }
            }

            if (obstacles[0, 0])
            {
                Console.WriteLine("Ошибка: препятствие на стартовом поле");
                return;
            }
            
            int[,] ways = new int[length, width];
            ways[0, 0] = 1;
            for (int i = 1; i < length; i++)
            {
                ways[i, 0] = obstacles[i, 0] ? 0 : ways[i - 1, 0];
            }
            for (int j = 1; j < width; j++)
            {
                ways[0, j] = obstacles[0, j] ? 0 : ways[0, j - 1];
            }
            for (int i = 1; i < length; i++)
            {
                for (int j = 1; j < width; j++)
                {
                    ways[i, j] = obstacles[i, j] ? 0 : ways[i - 1, j] + ways[i, j - 1];
                }
            }
            
            Console.WriteLine($"От старта до финиша есть {ways[length - 1, width - 1]} различных путей");
        }
        
        private static void Task2()
        {
            // Console.WriteLine("Введите первую строку");
            // string string1 = Console.ReadLine();
            // Console.WriteLine("Введите вторую строку");
            // string string2 = Console.ReadLine();
            //
            // int[,] matrix = new int[string1.Length, string2.Length];
            //
            // matrix[0, 0] = string1[0] == string2[0] ? 1 : 0;
            
            throw new NotImplementedException();
            
            // Не имею ни малейшего понятия, как решать эту задачу. Слишком сложно. Нет четкого, однозначного, детерминированного алгоритма.
        }
        
        private static void Task3()
        {
            // Console.WriteLine("Введите длину поля (количество строк)");
            // int length = int.Parse(Console.ReadLine());
            // Console.WriteLine("Введите ширину поля (количество столбцов) (не более 26)");
            // int width = int.Parse(Console.ReadLine());
            // Console.WriteLine("Введите начальное положение коня (Пример: с3) (нумерация начинается с 1 и a)");
            // string input = Console.ReadLine().ToLower();
            // int initialRow = input[1] - 1;
            // int initialColumn = input[0] - 'a';
            
            throw new NotImplementedException();
            
            // Не могу решить. Не знаю, как это возможно автоматизировать.
        }
    }
}
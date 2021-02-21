using System;
using System.Collections.Generic;
using MyLibrary;

namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuText = "1. Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения оптимизированной\n" +
                              "и не оптимизированной программы. Написать функции сортировки, которые возвращают количество операций.\n" +
                              "3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив.\n" +
                              "Функция возвращает индекс найденного элемента или -1, если элемент не найден.";

            Dictionary<string, Action> methods = new Dictionary<string, Action>();
            methods.Add("1", Task1);
            methods.Add("3", Task3);
            
            MyMethods.Menu(methods, menuText);
        }

        private static void Task1()
        {
            int arrayLength = 10;
            int[] array1 = new int[arrayLength];
            int[] array2 = new int[arrayLength];
            Random random = new Random();
            for (int i = 0; i < arrayLength; i++)
            {
                int value = (int)(random.NextDouble() * 100);
                array1[i] = value;
                array2[i] = value;
            }

            Console.WriteLine();
            Console.WriteLine("Неоптимизированная сортировка пузырьком");
            Console.WriteLine("Массив до сортировки:");
            MyMethods.WriteArray(array1);
            int operations = BubbleSortUnoptimized(ref array1);
            Console.WriteLine("Массив после сортировки");
            MyMethods.WriteArray(array1);
            Console.WriteLine($"{operations} операций");
            Console.WriteLine();
            
            Console.WriteLine("Оптимизированная сортировка пузырьком (шейкерная сортировка)");
            Console.WriteLine("Массив до сортировки:");
            MyMethods.WriteArray(array2);
            operations = ShakerSort(ref array2);
            Console.WriteLine("Массив после сортировки");
            MyMethods.WriteArray(array2);
            Console.WriteLine($"{operations} операций");
            Console.WriteLine();
            
            int BubbleSortUnoptimized<T>(ref T[] array) where T : IComparable<T>
            {
                int operations = 0;
                int swaps;
                do
                {
                    swaps = 0;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        operations++;
                        if (array[i].CompareTo(array[i+1]) > 0)
                        {
                            MyMethods.Swap(ref array[i], ref array[i+1]);
                            swaps++;
                            operations++;
                        }
                    }
                } while (swaps != 0);

                return operations;
            }

            int ShakerSort<T>(ref T[] array) where T : IComparable<T>
            {
                int operations = 0;
                int swaps;
                int start = 0;
                int end = array.Length - 1;
                bool reverse = false;
                do
                {
                    swaps = 0;
                    for (int i = reverse ? end - 1 : start; reverse ? i >= start : i < end; i += reverse ? -1 : 1)
                    {
                        operations++;
                        if (array[i].CompareTo(array[i+1]) > 0)
                        {
                            MyMethods.Swap(ref array[i], ref array[i+1]);
                            swaps++;
                            operations++;
                        }
                    }

                    if (reverse)
                    {
                        start++;
                    }
                    else
                    {
                        end--;
                    }
                    reverse = !reverse;
                } while (swaps != 0);

                return operations;
            }
        }

        private static void Task3()
        {
            int[] array = new int[10];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * i;
            }
            Console.WriteLine();
            Console.WriteLine("Сгенерирован массив");
            MyMethods.WriteArray(array);
            Console.WriteLine("Введите элемент, индекс которого хотите найти");
            int value = int.Parse(Console.ReadLine());
            int index = BinarySearch(array, value);
            Console.WriteLine(index == -1 ? "Элемент не найден" : $"Индекс искомого элемента - {index}");
            Console.WriteLine();

            int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
            {
                int start = 0;
                int end = arr.Length - 1;
                int mid;
                do
                {
                    mid = (start + end) / 2;
                    int comparisonResult = arr[mid].CompareTo(value);
                    if (comparisonResult == 0)
                    {
                        return mid;
                    }

                    if (comparisonResult < 0)
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                } while (!((start == mid && mid == end) || end < start));

                return -1;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MyLibrary
{
    public static class MyMethods
    {
        public static double ReadDouble()
        {
            return double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        public static bool TryReadDouble(out double result)
        {
            return double.TryParse(Console.ReadLine().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        public static string DobuleToString(double d)
        {
            return d.ToString(CultureInfo.InvariantCulture);
        }

        public static void Menu(Dictionary<string, Action> methods, string menuText, string exit = "q", string author = "Кузьминых Юрий")
        {
            string input;
            do
            {
                Console.WriteLine($"Автор программы - {author}");
                Console.WriteLine("Выберите подпрограмму:");
                Console.WriteLine(menuText);
                Console.WriteLine($"{exit} - выход");
                input = Console.ReadLine();
                if (methods.ContainsKey(input))
                {
                    methods[input].Invoke();
                }
            } while (input != exit);
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        public static void WriteArray<T>(T[] array)
        {
            foreach (T variable in array)
            {
               Console.Write($"{variable} "); 
            }
            Console.WriteLine();
        }
    }
}
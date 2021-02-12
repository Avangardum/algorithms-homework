using System;
using System.Globalization;

namespace lesson_1
{
    static class Program
    {
        private static void Main(string[] args)
        {
            
            string input;
            do
            {
                Console.WriteLine("Выберите подпрограмму:\n" +
                                  "1 - Найти максимальное из четырех чисел. Массивы не использовать.\n" +
                                  "2 - С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать среднее арифметическое всех положительных четных чисел, оканчивающихся на 8.\n" +
                                  "3 - Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h); где m-масса тела в килограммах, h - рост в метрах.\n" +
                                  "q - выход");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Task3();
                        break;
                }
            } while (input != "q");
        }

        private static void Task1()
        {
            Console.WriteLine("Введите первое число");
            double a = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
            Console.WriteLine("Введите второе число", CultureInfo.InvariantCulture);
            double b = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
            Console.WriteLine("Введите третье число");
            double c = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
            Console.WriteLine("Введите четвёртое число");
            double d = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);

            double max = a;
            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }
            if (d > max)
            {
                max = d;
            }
            Console.WriteLine("Максимальное число: " + max.ToString(CultureInfo.InvariantCulture));
        }
        
        private static void Task2()
        {
            Console.WriteLine("Введите любое количество целых чисел. Когда закончите, введите 0");
            int number = 0;
            int sum = 0;
            int amount = 0;
            do
            {
                number = int.Parse(Console.ReadLine());
                int lastDigit = number % 10;
                if (number > 0 && lastDigit == 8)
                {
                    sum += number;
                    amount++;
                }
            } while (number != 0);

            double avg = amount > 0 ? (double)sum / amount : Double.NaN;
            Console.WriteLine("Среднее арифметическое: " + avg);
        }
        
        private static void Task3()
        {
            Console.WriteLine("Введите массу");
            double m = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
            Console.WriteLine("Введите высоту");
            double h = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
            double I = m / (h * h);
            Console.WriteLine("Индекс массы тела: " + I.ToString(CultureInfo.InvariantCulture));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

/*
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * На основе полученных чисел получить новое по формуле: 5 + a[0] - a[1] + a[2] - a[3] + ...
 * Это необходимо сделать двумя способами:
 * 1) с помощью встроенного LINQ метода Aggregate
 * 2) с помощью своего метода MyAggregate, сигнатура которого дана в классе MyClass
 * Вывести полученные результаты на экран (естесственно, они должны быть одинаковыми)
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 8
 * 8
 * 
 * Пояснение:
 * 5 + 1 - 2 + 3 - 4 + 5 = 8
 * 
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 */

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk04();
            Console.Read();
        }

        public static void RunTesk04()
        {
            int[] arr;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s))
                    .ToArray();
            }
            catch (OverflowException e)
            {
                Console.WriteLine("OverflowException");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
                return;
            }

            try
            {
                // использовать синтаксис методов! SQL-подобные запросы не писать!
                bool isPlus = false;
                int arrAggregate = arr.Aggregate(5, (a, b) =>
                {
                    checked
                    {
                        isPlus = !isPlus;
                        if (isPlus)
                        {
                            return a + b;
                        }
                        else
                        {
                            return a - b;
                        }
                    }
                });

                int arrMyAggregate = MyClass.MyAggregate(arr);

                Console.WriteLine(arrAggregate);
                Console.WriteLine(arrMyAggregate);
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
        }
    }

    static class MyClass
    {
        public static int MyAggregate(this IEnumerable<int> seq)
        {
            int initialValue = 5;
            int result = initialValue;
            bool isPlus = true;
            checked
            {
                foreach (var item in seq)
                {
                    if (isPlus)
                    {
                        result += item;
                    }
                    else
                    {
                        result -= item;
                    }
                    isPlus = !isPlus;
                }
            }

            return result;
        }
    }
}

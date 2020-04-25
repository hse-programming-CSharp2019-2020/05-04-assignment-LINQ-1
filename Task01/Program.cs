﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * На вход подается строка, состоящая из целых чисел, разделенных одним или несколькими пробелами.
 * Необходимо отфильтровать полученные коллекцию, оставив только отрицательные или четные числа.
 * Вывести коллекцию, разделив элементы специальным символом.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 2:4
 * 2*4
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте ArgumentException!
 * 
 */

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk01();
            Console.Read();
        }

        public static void RunTesk01()
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
            // использовать синтаксис запросов!
            IEnumerable<int> arrQuery = from n in arr
                                        where n % 2 == 0 || n < 0
                                        select n;

            // использовать синтаксис методов!
            IEnumerable<int> arrMethod = arr.Where(x => x % 2 == 0 || x < 0);

            try
            {
                PrintEnumerableCollection<int>(arrQuery, ":");
                PrintEnumerableCollection<int>(arrMethod, "*");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Попробуйте осуществить вывод элементов коллекции с учетом разделителя, записав это ОДНИМ ВЫРАЖЕНИЕМ.
        // P.S. Есть два способа, оставьте тот, в котором применяется LINQ...
        public static void PrintEnumerableCollection<T>(IEnumerable<T> collection, string separator)
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException("ArgumentException");
            }
            Console.WriteLine(collection
                .Select(el => el.ToString())
                .Aggregate((a, b) => a.ToString() + separator + b.ToString()));
        }
    }
}

using System;
using System.Linq;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести коллекцию, разделив элементы пробелом.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,5
 * 2,5
 * 1 2
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
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
            Console.Read();
        }

        public static void RunTesk02()
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
            
            var filteredCollection = arr.TakeWhile(x => x != 0);
           
            try
            {
                Func<int, int> transformFunc = x =>
                {
                    int result = 0;
                    checked
                    {
                        result = x * x;
                    }
                    return result;
                };
                // использовать статическую форму вызова метода подсчета среднего
                double averageUsingStaticForm = Enumerable.Average(filteredCollection, transformFunc);
                // использовать объектную форму вызова метода подсчета среднего
                double averageUsingInstanceForm = filteredCollection.Average(transformFunc);

                Console.WriteLine($"{averageUsingStaticForm:F3}");
                Console.WriteLine($"{averageUsingInstanceForm:F3}");

                // вывести элементы коллекции в одну строку
                filteredCollection.ToList().ForEach(x => Console.Write(x + " "));
            }
            catch (OverflowException e)
            {
                Console.WriteLine("OverflowException");
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab12;

namespace LAB_14
{
    public static class TreeExtensions
    {
        // Методы расширения для выборки данных по условию
        public static IEnumerable<T> FilterByCondition<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        // Методы расширения для агрегирования данных
        public static double Average<T>(this IEnumerable<T> source, Func<T, double> selector)
        {
            double sum = 0;
            int count = 0;
            foreach (T item in source)
            {
                sum += selector(item);
                count++;
            }
            return count == 0 ? 0 : sum / count;
        }

        public static T MaxBy<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            if (!source.Any()) return default;
            return source.OrderByDescending(selector).First();
        }

        public static T MinBy<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            if (!source.Any()) return default;
            return source.OrderBy(selector).First();
        }

        public static double Sum<T>(this IEnumerable<T> source, Func<T, double> selector)
        {
            double sum = 0;
            foreach (T item in source)
            {
                sum += selector(item);
            }
            return sum;
        }

        // Методы расширения для сортировки коллекции
        public static IEnumerable<T> OrderByAscending<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            return source.OrderBy(selector);
        }

        public static IEnumerable<T> OrderByDescending<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            return source.OrderByDescending(selector);
        }
    }
}

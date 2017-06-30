using System;
using System.Collections.Generic;

namespace LazyTypes
{
    public static class Range
    {
        public static Lazy<List<int>> FromTo(Lazy<int> begin, Lazy<int> end)
        {
            if (begin.Value >= end.Value)
            {
                return new Lazy<List<int>>(() => new List<int>());
            }

            var nextValue = new Lazy<int>(() => begin.Value + 1);
            var list = new List<int>(begin, FromTo(nextValue, end));
            return new Lazy<List<int>>(() => list);
        }

        public static Lazy<List<int>> From(Lazy<int> begin)
        {
            var nextValue = new Lazy<int>(() => begin.Value + 1);
            var list = new List<int>(begin, From(nextValue));
            return new Lazy<List<int>>(() => list);
        }

        public static Lazy<List<T>> FromIEnumerable<T>(this IEnumerable<T> values)
        {
            return FromIEnumerator(values.GetEnumerator());
        }

        private static Lazy<List<T>> FromIEnumerator<T>(IEnumerator<T> enumerator)
        {
            var isLast = !enumerator.MoveNext();
            if (isLast)
            {
                return new Lazy<List<T>>(() => new List<T>());
            }

            Console.WriteLine(enumerator.Current + " " + isLast);

            var headValue = new Lazy<T>(() => enumerator.Current);
            var list = new List<T>(headValue, FromIEnumerator(enumerator));
            return new Lazy<List<T>>(() => list);
        }
    }
}

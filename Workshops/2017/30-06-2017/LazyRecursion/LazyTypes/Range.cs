using System;
using System.Collections.Generic;

namespace LazyTypes
{
    public static class Range
    {
        public static Lazy<List<int>> FromTo(Lazy<int> begin, Lazy<int> end)
        {
			return begin.Value >= end.Value
				? List.Empty<int>()
				: List.Cons(begin, FromTo(begin.Add(1.ToLazy()), end));
        }

        public static Lazy<List<int>> From(Lazy<int> begin)
        {
			return List.Cons(begin, From(begin.Add(1.ToLazy())));
        }

        public static Lazy<List<T>> FromIEnumerable<T>(this IEnumerable<T> values)
        {
            return FromIEnumerator(values.GetEnumerator());
        }

        private static Lazy<List<T>> FromIEnumerator<T>(IEnumerator<T> enumerator)
        {
			return !enumerator.MoveNext()
				? List.Empty<T>()
				: List.Cons(enumerator.Current.ToLazy(), FromIEnumerator(enumerator));
        }
    }
}

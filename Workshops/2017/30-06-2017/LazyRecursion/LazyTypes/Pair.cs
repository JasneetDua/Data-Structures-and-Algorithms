using System;

namespace LazyTypes
{
    public class Pair<T1, T2>
    {
        private readonly Lazy<T1> first;
        private readonly Lazy<T2> second;

        public Pair(Lazy<T1> f, Lazy<T2> s)
        {
            first = f;
            second = s;
        }

        public Lazy<R> WithPair<R>(Func<Lazy<T1>, Lazy<T2>, Lazy<R>> f)
        {
            return f(first, second);
        }
    }

    public static class Pair
    {
        public static Lazy<Pair<T1, T2>> Make<T1, T2>(Lazy<T1> f, Lazy<T2> s)
        {
            return new Lazy<Pair<T1, T2>>(() => new Pair<T1, T2>(f, s));
        }

		public static Lazy<R> WithPair<T1, T2, R>(this Lazy<Pair<T1, T2>> pair, Func<Lazy<T1>, Lazy<T2>, Lazy<R>> f)
		{
			return new Lazy<R>(() => pair.Value.WithPair(f).Value);
		}
    }
}

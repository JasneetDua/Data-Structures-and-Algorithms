using System;

namespace LazyTypes
{
    public class Pair<T1, T2>
    {
        private Lazy<T1> first;
        private Lazy<T2> second;

        public Pair(Lazy<T1> f, Lazy<T2> s)
        {
            first = f;
            second = s;
        }

        public Lazy<RT> WithPair<RT>(Func<Lazy<T1>, Lazy<T2>, Lazy<RT>> f)
        {
            return f(first, second);
        }
    }

    public static class Pair
    {
        public static Pair<T1, T2> Make<T1, T2>(Lazy<T1> f, Lazy<T2> s)
        {
            return new Pair<T1, T2>(f, s);
        }
    }
}

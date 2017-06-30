using System;

namespace LazyTypes
{
    public static class HelperMethods
    {
		public static Lazy<T> ToLazy<T>(this T x)
		{
			return new Lazy<T>(() => x);
		}

        public static Lazy<int> Add(this Lazy<int> x, Lazy<int> y)
        {
            return new Lazy<int>(() => x.Value + y.Value);
        }

		public static Lazy<int> Subtract(this Lazy<int> x, Lazy<int> y)
		{
			return new Lazy<int>(() => x.Value - y.Value);
		}

        public static Lazy<bool> Not(this Lazy<bool> x)
        {
            return new Lazy<bool>(() => !x.Value);
        }
    }
}

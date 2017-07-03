using System;

namespace LazyTypes
{
    public class List<T>
    {
        private readonly Optional<Pair<T, List<T>>> head;

        public List()
        {
            head = new Optional<Pair<T, List<T>>>();
        }

        public List(Lazy<T> headValue, Lazy<List<T>> tailList)
        {
            head = new Optional<Pair<T, List<T>>>(
                new Lazy<Pair<T, List<T>>>(() =>
                    new Pair<T, List<T>>(headValue, tailList)));
        }

        public Lazy<R> WithList<R>(Lazy<R> whenEmpty, Func<Lazy<T>, Lazy<List<T>>, Lazy<R>> f)
        {
            return head.WithOptional(whenEmpty, pair => pair.WithPair(f));
        }
    }

	public static class List
	{
		public static Lazy<List<T>> Empty<T>()
		{
			return new Lazy<List<T>>(() => new List<T>());
		}

		public static Lazy<List<T>> Cons<T>(Lazy<T> head, Lazy<List<T>> tail)
		{
			return new Lazy<List<T>>(() => new List<T>(head, tail));
		}

		public static Lazy<R> WithList<T, R>(this Lazy<List<T>> list, Lazy<R> whenEmpty, Func<Lazy<T>, Lazy<List<T>>, Lazy<R>> f)
		{
			return new Lazy<R>(() => list.Value.WithList(whenEmpty, f).Value);
		}
	}
}

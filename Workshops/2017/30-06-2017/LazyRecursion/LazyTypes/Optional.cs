using System;

namespace LazyTypes
{
    public class Optional<T>
    {
        private readonly Lazy<T> value;

        public Optional()
        {
            value = null;
        }

        public Optional(Lazy<T> v)
        {
            value = v;
        }

        public Lazy<R> WithOptional<R>(Lazy<R> whenEmpty, Func<Lazy<T>, Lazy<R>> whenFull)
        {
			return value == null ? whenEmpty : whenFull(value);
        }
    }

	public static class Optional
	{
		public static Lazy<Optional<T>> None<T>()
		{
			return new Lazy<Optional<T>>(() => new Optional<T>());
		}

		public static Lazy<Optional<T>> Value<T>(Lazy<T> value)
		{
			return new Lazy<Optional<T>>(() => new Optional<T>(value));
		}

        public static Lazy<R> WithOptional<T, R>(this Lazy<Optional<T>> opt, Lazy<R> whenEmpty, Func<Lazy<T>, Lazy<R>> whenFull)
        {
			return new Lazy<R>(() => opt.Value.WithOptional(whenEmpty, whenFull).Value);
        }

        public static Lazy<Optional<R>> Bind<T, R>(this Lazy<Optional<T>> opt, Func<Lazy<T>, Lazy<Optional<R>>> f)
        {
			return opt.WithOptional(None<R>(), f);
        }
	}
}

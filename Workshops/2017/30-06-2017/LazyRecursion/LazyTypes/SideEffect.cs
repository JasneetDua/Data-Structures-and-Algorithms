using System;

namespace LazyTypes
{
    public class SideEffect<T>
    {
        private Func<Lazy<T>> func;

        public SideEffect(Func<Lazy<T>> f)
        {
            func = f;
        }

		public void Execute()
		{
			func();
		}

		public Lazy<SideEffect<R>> Bind<R>(Func<Lazy<T>, Lazy<SideEffect<R>>> f)
		{
			return new Lazy<SideEffect<R>>(() => f(func()).Value);
		}
    }

    public static class SideEffect
    {
		public static Lazy<SideEffect<T>> Wrap<T>(Func<Lazy<T>> func)
		{
			return new Lazy<SideEffect<T>>(() => new SideEffect<T>(func));
		}

        public static Lazy<SideEffect<LazyVoid>> DoNothing()
        {
			return Wrap(() => LazyVoid.Instance);
        }

		public static Lazy<SideEffect<R>> Bind<T, R>(this Lazy<SideEffect<T>> x, Func<Lazy<T>, Lazy<SideEffect<R>>> f)
		{
			return new Lazy<SideEffect<R>>(() => x.Value.Bind(f).Value);
		}

		public static void Execute<T>(this Lazy<SideEffect<T>> effect)
		{
			effect.Value.Execute();
		}

        public static Lazy<SideEffect<int>> ReadNumber()
        {
			return Wrap(() =>
			{
                 var line = Console.ReadLine();
                 return new Lazy<int>(() => int.Parse(line));
			});
        }

        public static Lazy<SideEffect<LazyVoid>> PrintNumber(Lazy<int> number)
        {
			return Wrap(() =>
            {
                Console.WriteLine(number.Value);
                return LazyVoid.Instance;
            });
        }

        public static Lazy<SideEffect<LazyVoid>> PrintString(string str)
        {
            return Wrap(() =>
            {
                Console.WriteLine(str);
                return LazyVoid.Instance;
            });
        }

		public static Lazy<SideEffect<LazyVoid>> PrintNumbers(Lazy<List<int>> list)
		{
			return list.FoldLeft(DoNothing(), (x, y) => x.Bind(_ => PrintNumber(y)));
		}
    }
}

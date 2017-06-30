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

        public SideEffect<RT> Bind<RT>(Func<Lazy<T>, SideEffect<RT>> secondEffect)
        {
            return new SideEffect<RT>(() => secondEffect(func()).func());
        }

        public void Execute()
        {
            func();
        }
    }

    public static class SideEffect
    {
        public static SideEffect<int> ReadNumber()
        {
            return new SideEffect<int>(() =>
            {
                var line = Console.ReadLine();
                return new Lazy<int>(() => int.Parse(line));
            });
        }

        public static SideEffect<LazyVoid> PrintNumber(Lazy<int> number)
        {
            return new SideEffect<LazyVoid>(() =>
            {
                Console.WriteLine(number.Value);
                return new Lazy<LazyVoid>(() => LazyVoid.Instance);
            });
        }
    }
}

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

        public Lazy<SideEffect<RT>> Bind<RT>(Func<Lazy<T>, Lazy<SideEffect<RT>>> secondEffect)
        {
            return new Lazy<SideEffect<RT>>(() => secondEffect(func()).Value);
        }

        public void Execute()
        {
            func();
        }
    }

    public static class SideEffect
    {
        public static Lazy<SideEffect<int>> ReadNumber()
        {
            return new Lazy<SideEffect<int>>(() => new SideEffect<int>(() =>
             {
                 var line = Console.ReadLine();
                 return new Lazy<int>(() => int.Parse(line));
             }));
        }

        public static Lazy<SideEffect<LazyVoid>> PrintNumber(Lazy<int> number)
        {
            return new Lazy<SideEffect<LazyVoid>>(() => new SideEffect<LazyVoid>(() =>
            {
                Console.WriteLine(number.Value);
                return LazyVoid.Instance;
            }));
        }

        public static Lazy<SideEffect<LazyVoid>> DoNothing()
        {
            return new Lazy<SideEffect<LazyVoid>>(() => new SideEffect<LazyVoid>(() => LazyVoid.Instance));
        }

        public static Lazy<SideEffect<LazyVoid>> PrintString(string str)
        {
            return new Lazy<SideEffect<LazyVoid>>(() => new SideEffect<LazyVoid>(() =>
            {
                Console.WriteLine(str);
                return LazyVoid.Instance;
            }));
        }

        //public static Lazy<SideEffect<LazyVoid>> PrintNumbers(Lazy<List<int>> list)
        //{
        //    return list.Map(num => PrintNumber(num))
        //        .FoldLeft(DoNothing, (x, y) => x.Value.Bind(v => y));
        //}
    }
}

using LazyTypes;
using System;

namespace LazyRecursion
{
    //class Lazy<T>
    //    where T : struct
    //{
    //    private T? value;
    //    private Func<T> func;

    //    public Lazy(Func<T> f)
    //    {
    //        value = null;
    //        func = f;
    //    }

    //    public T Value
    //    {
    //        get
    //        {
    //            if (!value.HasValue)
    //            {
    //                value = func();
    //            }
    //            return (T)value;
    //        }
    //    }
    //}

    class Program
    {
        static Lazy<Optional<int>> Divide(Lazy<int> x, Lazy<int> y)
        {
            return y.Value == 0
				? Optional.None<int>()
				: Optional.Value(new Lazy<int>(() => x.Value / y.Value));
        }

        static void DivisionTest()
        {
            var x = 18.ToLazy();
            var y = 2.ToLazy();
            var z = 3.ToLazy();

            Optional.Value(x)
                .Bind(v => Divide(v, y))
                .Bind(v => Divide(v, z))
                .WithOptional(
					SideEffect.PrintString("Cannot divide by zero"),
                    SideEffect.PrintNumber)
				.Execute();
        }

        static void Main()
        {
            //var _42 = new Lazy<int>(() => 42);
            //SideEffect.ReadNumber()
            //    .Bind(x => SideEffect.PrintNumber(_42).Bind((v) => SideEffect.ReadNumber())
            //        .Bind(y =>
            //        {
            //            var sum = new Lazy<int>(() => y.Value + x.Value);
            //            return SideEffect.PrintNumber(sum);
            //        }))
            //    .Execute();



            var array = new int[] { 4, 6, 2, 7, 8, 1 };
            //var e = array.GetEnumerator();
            //e.MoveNext();
            //e.MoveNext();
            //e.MoveNext();
            //e.MoveNext();
            //Console.WriteLine(e.MoveNext());
            //Console.WriteLine(e.MoveNext());
            //Console.WriteLine(e.Current);
            //Console.WriteLine(e.MoveNext());

            //return;

            Range.FromTo(0.ToLazy(), 9.ToLazy())
                .Reverse()
                .QuickSort()
                .AtIndex(2.ToLazy())
                .Value
                .WithOptional(
                    SideEffect.DoNothing(),
                    SideEffect.PrintNumber
                ).Value.Execute();

            //.WithOptional(
            //    new Lazy<SideEffect<LazyVoid>>(SideEffect.DoNothing),
            //    num => new Lazy<SideEffect<LazyVoid>>(() => SideEffect.PrintNumber(num))
            //    ).Value
            //    .Execute();
        }
    }
}

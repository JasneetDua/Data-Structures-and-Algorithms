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
        static Optional<int> Divide(Lazy<int> x, Lazy<int> y)
        {
            if (y.Value == 0)
            {
                return new Optional<int>();
            }
            return new Optional<int>(new Lazy<int>(() => x.Value / y.Value));
        }

        static void DivisionTest()
        {
            var x = new Lazy<int>(() => 18);
            var y = new Lazy<int>(() => 0);
            var z = new Lazy<int>(() => 3);

            var result = new Optional<int>(x)
                .Bind(v => Divide(v, y))
                .Bind(v => Divide(v, z))
                .WithOptional(
                    new Lazy<int>(() =>
                    {
                        Console.WriteLine("Connot divide by zero");
                        return 0;
                    }),

                    (value => new Lazy<int>(() =>
                         {
                             Console.WriteLine("Result is " + value.Value);
                             return 0;
                         }))
                  );

            var ignore = result.Value;
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

            Range.FromTo(0.Int(), 9.Int())
                .Reverse()
                .QuickSort()
                .AtIndex(2.Int())
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

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
            var y = 0.ToLazy();
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
			SideEffect.Wrap(() => new [] { 4, 6, 2, 7, 8, 1 }.FromIEnumerable())
				.Bind(nums => SideEffect.PrintString("Original:")
				 .Bind(_ => SideEffect.PrintNumbers(nums))
				 .Bind(_ => SideEffect.PrintString("Reversed:"))
				 .Bind(_ => SideEffect.PrintNumbers(nums.Reverse()))
				 .Bind(_ => SideEffect.PrintString("Sorted:"))
				 .Bind(_ => SideEffect.PrintNumbers(nums.QuickSort())))
				.Execute();
        }
    }
}

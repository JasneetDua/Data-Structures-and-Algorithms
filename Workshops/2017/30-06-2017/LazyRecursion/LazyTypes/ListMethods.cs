using System;

namespace LazyTypes
{
    public static class ListMethods
    {
        public static Lazy<int> Length<T>(this Lazy<List<T>> list)
        {
            return list.WithList(
				0.ToLazy(),
				(head, tail) => tail.Length().Add(1.ToLazy()));
        }

        public static Lazy<Optional<T>> Head<T>(this Lazy<List<T>> list)
        {
            return list.WithList(
				Optional.None<T>(),
                (head, tail) => Optional.Value(head));
        }

        public static Lazy<Optional<List<T>>> Tail<T>(this Lazy<List<T>> list)
        {
            return list.WithList(
				Optional.None<List<T>>(),
                (head, tail) => Optional.Value(tail));
        }

        public static Lazy<Optional<T>> Last<T>(this Lazy<List<T>> list)
        {
            return list.WithList(
				Optional.None<T>(),
                (head, tail) => tail.WithList(
						Optional.Value(head),
                        (second, rest) => tail.Last()));
		}

        public static Lazy<Optional<List<T>>> Init<T>(this Lazy<List<T>> list)
        {
            return list.WithList(
				Optional.None<List<T>>(),
                (head, tail) => tail.WithList(
						Optional.Value(List.Empty<T>()),
                        (second, rest) => tail.Init()));
        }

        public static Lazy<Optional<T>> AtIndex<T>(this Lazy<List<T>> list, Lazy<int> index)
        {
			return index.Value < 0
				? Optional.None<T>()
				: list.Value.WithList(
					Optional.None<T>(),
                    (head, tail) => index.Value == 0
						? Optional.Value(head)
						: tail.AtIndex(index.Subtract(1.ToLazy())));
        }

        public static Lazy<List<T>> Take<T>(this Lazy<List<T>> list, Lazy<int> count)
        {
            return count.Value <= 0
				? List.Empty<T>()
				: list.WithList(
						List.Empty<T>(),
						(head, tail) => List.Cons(head, tail.Take(count.Subtract(1.ToLazy()))));
        }

        public static Lazy<List<T>> Drop<T>(this Lazy<List<T>> list, Lazy<int> count)
        {
			return count.Value == 0
				? list
				: list.WithList(
						List.Empty<T>(),
						(head, tail) => tail.Drop(count.Subtract(1.ToLazy())));
        }

        public static Lazy<List<T>> TakeWhile<T>(this Lazy<List<T>> list, Func<Lazy<T>, Lazy<bool>> f)
        {
			return list.WithList(
					List.Empty<T>(),
					(head, tail) => f(head).Value
						? List.Cons(head, tail.TakeWhile(f))
						: List.Empty<T>());
        }
        public static Lazy<List<T>> DropWhile<T>(this Lazy<List<T>> list, Func<Lazy<T>, Lazy<bool>> f)
        {
            return list.WithList(
					List.Empty<T>(),
                    (head, tail) => f(head).Value
						? tail.DropWhile(f)
						: list);
        }

        public static Lazy<List<R>> Map<T, R>(this Lazy<List<T>> list, Func<Lazy<T>, Lazy<R>> f)
        {
            return list.WithList(
					List.Empty<R>(),
                    (head, tail) => List.Cons(f(head), tail.Map(f)));
        }

        public static Lazy<List<T>> Filter<T>(this Lazy<List<T>> list, Func<Lazy<T>, Lazy<bool>> f)
        {
            return list.WithList(
                    list,
                    (head, tail) => f(head).Value
						? List.Cons(head, tail.Filter(f))
						: tail.Filter(f));
        }

        public static Lazy<List<Pair<T1, T2>>> Zip<T1, T2>(this Lazy<List<T1>> list1, Lazy<List<T2>> list2)
        {
			return ZipWith(Pair.Make, list1, list2);
        }

        public static Lazy<List<T3>> ZipWith<T1, T2, T3>(Func<Lazy<T1>, Lazy<T2>, Lazy<T3>> f, Lazy<List<T1>> list1, Lazy<List<T2>> list2)
        {
			return list1.WithList(
					List.Empty<T3>(),
					(head1, tail1) => list2.WithList(
							List.Empty<T3>(),
							(head2, tail2) => List.Cons(f(head1, head2), ZipWith(f, tail1, tail2))));
        }

        public static Lazy<List<T>> Concat<T>(this Lazy<List<T>> list1, Lazy<List<T>> list2)
        {
            return list1.Value.WithList(
                    list2,
                    (head, tail) => List.Cons(head, tail.Concat(list2)));
        }

        public static Lazy<List<T>> Reverse<T>(this Lazy<List<T>> list)
        {
            return list.Reverse(List.Empty<T>());
        }

        private static Lazy<List<T>> Reverse<T>(this Lazy<List<T>> list, Lazy<List<T>> reversed)
        {
            return list.Value.WithList(
                reversed,
                (head, tail) => tail.Reverse(List.Cons(head, reversed)));
        }

        public static Lazy<R> FoldRight<T, R>(this Lazy<List<T>> list, Lazy<R> initial, Func<Lazy<T>, Lazy<R>, Lazy<R>> f)
        {
            return list.Value.WithList(
                initial,
                (head, tail) => f(head, tail.FoldRight(initial, f)));
        }

        public static Lazy<R> FoldLeft<T, R>(this Lazy<List<T>> list, Lazy<R> initial, Func<Lazy<R>, Lazy<T>, Lazy<R>> f)
        {
            return list.Value.WithList(
                initial,
                (head, tail) => tail.FoldLeft(f(initial, head), f));
        }

//        public static Lazy<List<R>> ScanRight<T, R>(this Lazy<List<T>> list, Lazy<R> initial, Func<Lazy<T>, Lazy<R>, Lazy<R>> f)
//        {
//        }

		public static Lazy<List<R>> ScanLeft<T, R>(this Lazy<List<T>> list, Lazy<R> initial, Func<Lazy<R>, Lazy<T>, Lazy<R>> f)
		{
			return List.Cons(initial, list.WithList(
						List.Empty<R>(),
						(head, tail) => tail.ScanLeft(f(initial, head), f)));
		}

        public static Lazy<List<T>> Flatten<T>(this Lazy<List<List<T>>> lists)
        {
            return lists.FoldRight(
				List.Empty<T>(),
                Concat);
        }

        public static Lazy<List<T>> QuickSortBy<T>(this Lazy<List<T>> list, Func<Lazy<T>, Lazy<T>, Lazy<bool>> less)
        {
            return list.Value.WithList(
                List.Empty<T>(),
                (pivot, rest) =>
                {
                    var left = rest.Filter(x => less(x, pivot)).QuickSortBy(less);
                    var right = rest.Filter(x => less(x, pivot).Not()).QuickSortBy(less);
                    return left.Concat(List.Cons(pivot, right));
                });
        }

        public static Lazy<List<int>> QuickSort(this Lazy<List<int>> list)
        {
            return list.QuickSortBy((x, y) => new Lazy<bool>(() => x.Value < y.Value));
        }
    }
}

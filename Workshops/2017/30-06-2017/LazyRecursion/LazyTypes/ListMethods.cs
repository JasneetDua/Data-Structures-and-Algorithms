using System;

namespace LazyTypes
{
    public static class ListMethods
    {
        public static Lazy<int> Length<T>(this List<T> list)
        {
            return list.WithList(
                new Lazy<int>(() => 0),
                (head, tail) => new Lazy<int>(() => 1 + tail.Value.Length().Value));
        }

        public static Lazy<Optional<T>> Head<T>(this List<T> list)
        {
            return list.WithList(
                new Lazy<Optional<T>>(() => new Optional<T>()),
                (head, tail) => new Lazy<Optional<T>>(() => new Optional<T>(head)));
        }

        public static Lazy<Optional<List<T>>> Tail<T>(this List<T> list)
        {
            return list.WithList(
                new Lazy<Optional<List<T>>>(() => new Optional<List<T>>()),
                (head, tail) => new Lazy<Optional<List<T>>>(() => new Optional<List<T>>(tail)));
        }

        public static Lazy<Optional<T>> Last<T>(this List<T> list)
        {
            return list.WithList(
                new Lazy<Optional<T>>(() => new Optional<T>()),
                (head, tail) => tail.Value.WithList(
                        new Lazy<Optional<T>>(() => new Optional<T>(head)),
                        (second, rest) => tail.Value.Last())
                    );
        }

        public static Lazy<Optional<List<T>>> Init<T>(this List<T> list)
        {
            return list.WithList(
                new Lazy<Optional<List<T>>>(() => new Optional<List<T>>()),
                (head, tail) => tail.Value.WithList(
                    new Lazy<Optional<List<T>>>(()
                                => new Optional<List<T>>(new Lazy<List<T>>(() => new List<T>()))),
                        (second, rest) => new Lazy<Optional<List<T>>>(() =>
                                    new List<T>(second, rest).Init().Value)
                    )
            );
        }

        public static Lazy<Optional<T>> AtIndex<T>(this Lazy<List<T>> list, Lazy<int> index)
        {
            if (index.Value < 0)
            {
                return new Lazy<Optional<T>>(() => new Optional<T>());
            }

            return list.Value.WithList(
                    new Lazy<Optional<T>>(() => new Optional<T>()),
                    (head, tail) =>
                    {
                        if (index.Value == 0)
                        {
                            return new Lazy<Optional<T>>(() => new Optional<T>(head));
                        }
                        var prevIndex = new Lazy<int>(() => index.Value - 1);
                        return tail.AtIndex(prevIndex);
                    }
                );
        }

        public static Lazy<List<T>> Take<T>(this List<T> list, Lazy<int> count)
        {
            if (count.Value <= 0)
            {
                return new Lazy<List<T>>(() => new List<T>());
            }

            var newCount = new Lazy<int>(() => count.Value - 1);
            return list.WithList(
                new Lazy<List<T>>(() => new List<T>()),
                (head, tail) => new Lazy<List<T>>(() => new List<T>(head, tail.Value.Take(newCount)))
                );
        }

        public static Lazy<List<T>> Drop<T>(this List<T> list, Lazy<int> count)
        {
            if (count.Value == 0)
            {
                return new Lazy<List<T>>(() => list);
            }
            var newCount = new Lazy<int>(() => count.Value - 1);
            return list.WithList(
                new Lazy<List<T>>(() => new List<T>()),
                (head, tail) => tail.Value.Drop(newCount)
                );
        }

        public static Lazy<List<T>> TakeWhile<T>(this List<T> list, Func<T, bool> f)
        {
            return list.WithList(
                    new Lazy<List<T>>(() => new List<T>()),
                    (head, tail) =>
                    {
                        if (f(head.Value))
                        {
                            return new Lazy<List<T>>(() => new List<T>(head, tail.Value.TakeWhile(f)));
                        }
                        return new Lazy<List<T>>(() => new List<T>());
                    }
                );
        }
        public static Lazy<List<T>> DropWhile<T>(this List<T> list, Func<T, bool> f)
        {
            return list.WithList(
                    new Lazy<List<T>>(() => new List<T>()),
                    (head, tail) =>
                    {
                        if (f(head.Value))
                        {
                            return tail.Value.DropWhile(f);
                        }
                        return new Lazy<List<T>>(() => list);
                    }
                );
        }

        public static Lazy<List<R>> Map<T, R>(this Lazy<List<T>> list, Func<Lazy<T>, Lazy<R>> f)
        {
            return list.Value.WithList(
                    new Lazy<List<R>>(() => new List<R>()),
                    (head, tail) => new Lazy<List<R>>(() =>
                        new List<R>(f(head), tail.Map(f))
                    )
                );
        }

        public static Lazy<List<T>> Filter<T>(this Lazy<List<T>> list, Func<Lazy<T>, Lazy<bool>> f)
        {
            return list.Value.WithList(
                    list,
                    (head, tail) =>
                    {
                        if (f(head).Value)
                        {
                            return new Lazy<List<T>>(() => new List<T>(head, tail.Filter(f)));
                        }

                        return tail.Filter(f);
                    }
                );
        }

        //public static Lazy<List<Pair<T1, T2>>> Zip<T1, T2>(this List<T1> list1, List<T2> list2)
        //{
        //    Func<Lazy<T1>, Lazy<T2>, Lazy<Pair<T1, T2>> pairFunc =
        //          (v1, v2) => new Lazy<Pair<T1, T2>>(() => Pair.Make(v1, v2));
        //    return ZipWith<T1, T2, Pair<T1, T2>>(pairFunc, list1, list2);
        //}

        public static Lazy<List<T3>> ZipWith<T1, T2, T3>(Func<Lazy<T1>, Lazy<T2>, Lazy<T3>> f, List<T1> list1, List<T2> list2)
        {
            return list1.WithList(
                new Lazy<List<T3>>(() => new List<T3>()),
                (head1, tail1) =>
                    list2.WithList(
                        new Lazy<List<T3>>(() => new List<T3>()),
                        (head2, tail2) => new Lazy<List<T3>>(() => new List<T3>(
                             f(head1, head2),
                            ZipWith(f, tail1.Value, tail2.Value)))
                    )
              );
        }

        public static Lazy<List<T>> Concat<T>(this Lazy<List<T>> list1, Lazy<List<T>> list2)
        {
            return list1.Value.WithList(
                    list2,
                    (head, tail) => new Lazy<List<T>>(() => new List<T>(head, tail.Concat(list2)))
                );
        }

        public static Lazy<List<T>> Reverse<T>(this Lazy<List<T>> list)
        {
            return list.Reverse(new Lazy<List<T>>(() => new List<T>()));
        }

        private static Lazy<List<T>> Reverse<T>(this Lazy<List<T>> list, Lazy<List<T>> reversed)
        {
            return list.Value.WithList(
                reversed,
                (head, tail) => tail.Reverse(new Lazy<List<T>>(() => new List<T>(head, reversed)))
            );
        }

        public static Lazy<R> FoldRight<T, R>(this Lazy<List<T>> list, Lazy<R> initial, Func<Lazy<T>, Lazy<R>, Lazy<R>> f)
        {
            return list.Value.WithList(
                initial,
                (head, tail) => f(head, tail.FoldRight(initial, f))
           );
        }

        public static Lazy<R> FoldLeft<T, R>(this Lazy<List<T>> list, Lazy<R> initial, Func<Lazy<R>, Lazy<T>, Lazy<R>> f)
        {
            return list.Value.WithList(
                initial,
                (head, tail) => tail.FoldLeft(f(initial, head), f)
            );
        }
        //public static Lazy<List<R>> ScanRight<T, R>(this Lazy<List<T>> list, Lazy<R> initial, Func<Lazy<T>, Lazy<R>, Lazy<R>> f)
        //{
        //    return list.Value.WithList(
        //        new Lazy<List<R>>(() => new List<R>(initial, new Lazy<List<R>>(() => new List<R>()))),
        //        (head, tail) => new Lazy<List<R>>(() => new List<R>(head, tail.ScanRight(initial, f))))
        //   );
        //}

        public static Lazy<List<T>> Flatten<T>(this Lazy<List<List<T>>> lists)
        {
            return lists.FoldRight(
                new Lazy<List<T>>(() => new List<T>()),
                Concat
            );
        }

        public static Lazy<List<T>> QuickSortBy<T>(this Lazy<List<T>> list, Func<Lazy<T>, Lazy<T>, Lazy<bool>> less)
        {
            return list.Value.WithList(
                list,
                (pivot, rest) =>
                {
                    var left = rest.Filter(x => less(x, pivot)).QuickSortBy(less);
                    var right = rest.Filter(x => less(x, pivot).Not()).QuickSortBy(less);
                    return left.Concat(new Lazy<List<T>>(() => new List<T>(pivot, right)));
                }
            );
        }

        public static Lazy<List<int>> QuickSort(this Lazy<List<int>> list)
        {
            return list.QuickSortBy((x, y) => new Lazy<bool>(() => x.Value < y.Value));
        }
    }
}

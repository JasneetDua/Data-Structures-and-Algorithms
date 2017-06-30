using System;

namespace LazyTypes
{
    public class LazyVoid
    {
        private static readonly Lazy<LazyVoid> instance = new Lazy<LazyVoid>(() => new LazyVoid());

        private LazyVoid()
        {
        }

        public static Lazy<LazyVoid> Instance => instance;
    }
}

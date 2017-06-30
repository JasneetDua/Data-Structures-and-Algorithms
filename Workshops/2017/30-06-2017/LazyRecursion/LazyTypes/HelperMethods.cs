using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyTypes
{
    public static class HelperMethods
    {
        public static Lazy<int> Int(this int x)
        {
            return new Lazy<int>(() => x);
        }

        public static Lazy<int> Add(this Lazy<int> x, Lazy<int> y)
        {
            return new Lazy<int>(() => x.Value + y.Value);
        }

        public static Lazy<bool> Not(this Lazy<bool> x)
        {
            return new Lazy<bool>(() => !x.Value);
        }
    }
}

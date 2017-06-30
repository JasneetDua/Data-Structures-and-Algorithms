namespace LazyTypes
{
    public class LazyVoid
    {
        private static readonly LazyVoid instance = new LazyVoid();

        private LazyVoid()
        {
        }

        public static LazyVoid Instance => instance;
    }
}

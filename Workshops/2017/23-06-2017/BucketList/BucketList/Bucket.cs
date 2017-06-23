namespace BucketList
{
    class Bucket<T>
    {
        private T[] buffer;
        private int startIndex;
        private int endIndex;
        private int size;

        public Bucket(int bucketSize)
        {
            buffer = new T[bucketSize];
            startIndex = 0;
            endIndex = 0;
            size = 0;
        }

        public Bucket(Bucket<T> left, Bucket<T> right)
        {
            size = left.size + right.size;
            buffer = new T[size];
            startIndex = 0;
            endIndex = 0;

            for (int i = 0; i < left.size; ++i)
            {
                buffer[i] = left[i];
            }
            for (int i = 0; i < right.size; i++)
            {
                buffer[left.size + i] = left[i];
            }
        }

        public Bucket(bool left, Bucket<T> both)
        {
            size = both.buffer.Length / 2;
            buffer = new T[size];
            startIndex = 0;
            endIndex = 0;

            for (int i = 0, j = left ? 0 : size;
                i < size;
                ++i, ++j)
            {
                buffer[i] = both[j];
            }
        }

        public bool Full => size == buffer.Length;
        public bool Empty => size == 0;

        public T this[int index]
        {
            get
            {
                return buffer[AdaptIndex(index)];
            }
            set
            {
                buffer[AdaptIndex(index)] = value;
            }
        }

        public void ShiftRight(T value)
        {
            startIndex = PrevIndex(startIndex);
            buffer[startIndex] = value;

            if (Full)
            {
                endIndex = startIndex;
            }
            else
            {
                ++size;
            }
        }

        public void ShiftLeft(T value)
        {
            buffer[endIndex] = value;
            endIndex = NextIndex(endIndex);
            startIndex = endIndex;
        }

        public void PopFirst()
        {
            buffer[startIndex] = default(T);
            startIndex = NextIndex(startIndex);
            --size;
        }

        public void PopBack()
        {
            --size;
        }

        public void Insert(int index, T value)
        {
            int realIndex = AdaptIndex(index);

            int destinationIndex = endIndex;

            if (Full)
            {
                destinationIndex = PrevIndex(destinationIndex);
            }
            int sourceIndex = PrevIndex(destinationIndex);

            while (destinationIndex != realIndex)
            {
                buffer[destinationIndex] = buffer[sourceIndex];
                destinationIndex = sourceIndex;
                sourceIndex = PrevIndex(sourceIndex);
            }

            buffer[realIndex] = value;

            if (!Full)
            {
                endIndex = NextIndex(endIndex);
                ++size;
            }
        }

        public void Remove(int index)
        {
            int destinationIndex = AdaptIndex(index);
            int sourceIndex = NextIndex(destinationIndex);
            while (sourceIndex != endIndex)
            {
                buffer[destinationIndex] = buffer[sourceIndex];
                destinationIndex = sourceIndex;
                sourceIndex = NextIndex(sourceIndex);
            }

            endIndex = PrevIndex(endIndex);
        }

        private int AdaptIndex(int index)
        {
            int realIndex = startIndex + index;
            if (realIndex >= buffer.Length)
            {
                realIndex -= buffer.Length;
            }
            return realIndex;
        }

        private int PrevIndex(int index)
        {
            if (index == 0)
            {
                return buffer.Length - 1;
            }

            return index - 1;
        }

        private int NextIndex(int index)
        {
            if (index == buffer.Length - 1)
            {
                return 0;
            }

            return index + 1;
        }
    }
}

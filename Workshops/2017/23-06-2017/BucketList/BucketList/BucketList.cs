using System;
using System.Collections;
using System.Collections.Generic;

namespace BucketList
{
    public class BucketList<T> : IBucketList<T>
    {
        private const int MIN_BUCKET_SIZE = 4;

        private int bucketSize;
        private List<Bucket<T>> buckets;

        public BucketList()
        {
            Clear();
        }

        public T this[int index]
        {
            get
            {
                return buckets[index / bucketSize][index % bucketSize];
            }

            set
            {
                buckets[index / bucketSize][index % bucketSize] = value;
            }
        }

        public int Size { get; private set; }

        public void Add(T value)
        {
            Insert(Size, value);
        }

        public void Clear()
        {
            bucketSize = MIN_BUCKET_SIZE;
            buckets = new List<Bucket<T>>();
            Size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; ++i)
            {
                yield return this[i];
            }
        }

        public void Insert(int index, T value)
        {
            if (buckets.Count == bucketSize * 2
                && buckets[buckets.Count - 1].Full)
            {
                var largerBuckets = new List<Bucket<T>>();

                largerBuckets.Capacity = buckets.Count / 2; // will work without

                for (int i = 0; i < buckets.Count; i += 2)
                {
                    largerBuckets.Add(
                        new Bucket<T>(buckets[i], buckets[i + 1]));
                }

                bucketSize *= 2;
                buckets = largerBuckets;
            }

            if (buckets.Count == 0 || buckets[buckets.Count - 1].Full)
            {
                var newBucket = new Bucket<T>(bucketSize);
                buckets.Add(newBucket);
            }

            int destinationBucketIndex = buckets.Count - 1;
            int sourceBucketIndex = destinationBucketIndex - 1;

            int targetBucketIndex = index / bucketSize;
            int targetIndexInBucket = index % bucketSize;

            while (destinationBucketIndex != targetBucketIndex)
            {
                buckets[destinationBucketIndex]
                    .ShiftRight(buckets[sourceBucketIndex][bucketSize - 1]);

                --destinationBucketIndex;
                --sourceBucketIndex;
            }

            buckets[targetBucketIndex].Insert(targetIndexInBucket, value);
            ++Size;
        }

        public void Remove(int index)
        {
            // Needs debugging
            --Size;

            int targetBucketIndex = index / bucketSize;
            int targetIndexInBucket = index % bucketSize;

            buckets[targetBucketIndex].Remove(targetIndexInBucket);

            // This is a HACK!!!
            if (targetBucketIndex < buckets.Count - 1)
            {
                int destinationBucketIndex = targetBucketIndex;
                int sourceBucketIndex = destinationBucketIndex + 1;
                while (sourceBucketIndex < buckets.Count)
                {
                    buckets[destinationBucketIndex]
                        .ShiftLeft(buckets[sourceBucketIndex][0]);
                    ++sourceBucketIndex;
                    ++destinationBucketIndex;
                }

                buckets[buckets.Count - 1].PopFirst();
            }
            else
            {
                buckets[buckets.Count - 1].PopBack();
            }

            if (buckets[buckets.Count - 1].Empty)
            {

                buckets.RemoveAt(buckets.Count - 1);

                if (bucketSize == buckets.Count * 2
                    && buckets.Count >= MIN_BUCKET_SIZE)
                {
                    var smallerBuckets = new List<Bucket<T>>();
                    foreach (var bucket in buckets)
                    {
                        smallerBuckets.Add(
                            new Bucket<T>(true, bucket));
                        smallerBuckets.Add(
                            new Bucket<T>(false, bucket));
                    }

                    bucketSize /= 2;
                    buckets = smallerBuckets;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

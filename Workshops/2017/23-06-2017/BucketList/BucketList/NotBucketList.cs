using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketList
{
    public class NotBucketList<T> : IBucketList<T>
    {
        private List<T> list;

        public NotBucketList()
        {
            list = new List<T>();
        }

        public T this[int index]
        {
            get
            {
                return list[index];
            }

            set
            {
                list[index] = value;
            }
        }

        public int Size => list.Count;

        public void Add(T value)
        {
            list.Add(value);
        }

        public void Clear()
        {
            list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var x in list)
            {
                yield return x;
            }
        }

        public void Insert(int index, T value)
        {
            list.Insert(index, value);
        }

        public void Remove(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

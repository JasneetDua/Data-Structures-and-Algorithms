using System;
using System.Collections;
using System.Collections.Generic;

namespace BucketList
{
	public class BucketList<T> : IBucketList<T>
	{
		public T this[int index]
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public int Size
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void Add(T value)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, T value)
		{
			throw new NotImplementedException();
		}

		public void Remove(int index)
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

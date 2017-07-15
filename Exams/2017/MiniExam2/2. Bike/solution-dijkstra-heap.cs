using System;
using System.Linq;
using System.Collections.Generic;

namespace Bike
{
	class BinaryHeap
	{
		private List<Tuple<int, int, double>> buffer;
		private int[,] indeces;

		public BinaryHeap(int r, int c)
		{
			this.buffer = new List<Tuple<int, int, double>>();
			this.buffer.Add(null);
			this.indeces = new int[r, c];
		}

		public int Count
		{
			get
			{
				return this.buffer.Count - 1;
			}
		}

		public void Push(int r, int c, double damage)
		{
			var currentIndex = this.indeces[r, c];
			if(currentIndex > 0 && this.buffer[currentIndex].Item3 < damage)
			{
				return;
			}

			if(currentIndex == 0)
			{
				currentIndex = this.buffer.Count;
				this.buffer.Add(null);
			}

			var item = new Tuple<int, int, double>(r, c, damage);
			this.HeapifyUp(item, currentIndex);
		}

		public Tuple<int, int, double> Top
		{
			get
			{
				return buffer[1];
			}
		}

		public void Pop()
		{
			var lastIndex = this.buffer.Count - 1;
			var item = this.buffer[lastIndex];
			this.buffer.RemoveAt(lastIndex);

			this.HeapifyDown(item, 1);
		}

		private void HeapifyUp(Tuple<int, int, double> item, int index)
		{
			while(index > 1)
			{
				var parentIndex = index / 2;
				var parent = this.buffer[parentIndex];

				if(item.Item3 < parent.Item3)
				{
					this.buffer[index] = parent;
					this.indeces[parent.Item1, parent.Item2] = index;
				}
				else
				{
					break;
				}

				index = parentIndex;
			}

			this.buffer[index] = item;
			this.indeces[item.Item1, item.Item2] = index;
		}

		private void HeapifyDown(Tuple<int, int, double> item, int index)
		{
			if(this.Count == 0)
			{
				return;
			}

			while(index * 2 < this.buffer.Count)
			{
				var childIndex = index * 2;
				if(childIndex + 1 < this.buffer.Count
					&& this.buffer[childIndex + 1].Item3 < this.buffer[childIndex].Item3)
				{
					++childIndex;
				}

				var child = this.buffer[childIndex];

				if(child.Item3 < item.Item3)
				{
					this.buffer[index] = child;
					this.indeces[child.Item1, child.Item2] = index;
				}
				else
				{
					break;
				}

				index = childIndex;
			}

			this.buffer[index] = item;
			this.indeces[item.Item1, item.Item2] = index;
		}
	}

	class Program
	{
		static void Main()
		{
			var rows = int.Parse(Console.ReadLine());
			var cols = int.Parse(Console.ReadLine());

			var heights = new double[rows][];
			for(int i = 0; i < rows; ++i)
			{
				heights[i] = Console.ReadLine()
					.Split(' ')
					.Select(double.Parse)
					.ToArray();
			}

			var damages = new double[rows, cols];
			for(int i = 0; i < rows; ++i)
			{
				for(int j = 0; j < cols; ++j)
				{
					damages[i, j] = -1;
				}
			}

			var heap = new BinaryHeap(rows, cols);
			heap.Push(0, 0, 0);

			while(heap.Count > 0)
			{
				var x = heap.Top;
				heap.Pop();

				var row = x.Item1;
				var col = x.Item2;
				var damage = x.Item3;
				damages[row, col] = damage;

				foreach(var neigh in GetNeighbours(rows, cols, row, col))
				{
					var r = neigh.Item1;
					var c = neigh.Item2;
					if(damages[r, c] < 0)
					{
						heap.Push(r, c, damage + GetDamage(heights[row][col], heights[r][c]));
					}
				}
			}

//			for(int i = 0; i < rows; ++i)
//			{
//				for(int j = 0; j < cols; ++j)
//				{
//					Console.Write(" " + damages[i, j]);
//				}
//				Console.WriteLine();
//			}

			Console.WriteLine("{0:0.00}", damages[rows - 1, cols - 1] + GetDamage(0, heights[0][0]) + GetDamage(0, heights[rows - 1][cols - 1]));
		}

		static double GetDamage(double x, double y)
		{
			return x < y ? y - x : x - y;
		}

		static List<Tuple<int, int>> GetNeighbours(int rows, int cols, int row, int col)
		{
			var neighbours = new List<Tuple<int, int>>();

			if(row > 0)
			{
				neighbours.Add(new Tuple<int, int>(row - 1, col));

				if(row % 2 == 0)
				{
					if(col > 0)
					{
						neighbours.Add(new Tuple<int, int>(row - 1, col - 1));
					}
				}
				else
				{
					if(col < cols - 1)
					{
						neighbours.Add(new Tuple<int, int>(row - 1, col + 1));
					}
				}
			}
			if(row < rows - 1)
			{
				neighbours.Add(new Tuple<int, int>(row + 1, col));

				if(row % 2 == 0)
				{
					if(col > 0)
					{
						neighbours.Add(new Tuple<int, int>(row + 1, col - 1));
					}
				}
				else
				{
					if(col < cols - 1)
					{
						neighbours.Add(new Tuple<int, int>(row + 1, col + 1));
					}
				}
			}
			if(col > 0)
			{
				neighbours.Add(new Tuple<int, int>(row, col - 1));
			}
			if(col < cols - 1)
			{
				neighbours.Add(new Tuple<int, int>(row, col + 1));
			}

			return neighbours;
		}
	}
}

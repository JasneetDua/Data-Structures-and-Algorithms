using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Deduplication
{
	class Block
	{
		private readonly string buffer;
		private readonly int bufferHash;
		private int referenceCount;

		public Block(string str)
		{
			this.buffer = str;
			this.bufferHash = str.GetHashCode();
			this.referenceCount = 0;
		}

		public Block Reference()
		{
			++this.referenceCount;
			return this;
		}

		public bool Free()
		{
			--this.referenceCount;
			return this.referenceCount == 0;
		}

		public Block Copy()
		{
			return new Block(this.buffer);
		}

		public override int GetHashCode()
		{
			return this.bufferHash;
		}

		public override bool Equals(object obj)
		{
			var other = obj as Block;
			if (this.bufferHash != other.bufferHash)
			{
				return false;
			}

			return this.buffer == other.buffer;
		}
	}

	class File
	{
		private readonly List<Block> blocks;

		public File()
		{
			this.blocks = new List<Block>();
		}

		public void Append(Block[] blocks)
		{
			foreach (var b in blocks)
			{
				this.blocks.Add(b.Reference());
			}
		}

		public int Size()
		{
			return this.blocks.Count;
		}

		public int Remove()
		{
			int freed = 0;
			foreach (var b in this.blocks)
			{
				if (b.Free())
				{
					++freed;
				}
			}
			return freed;
		}

		public List<Block> GetBlocks()
		{
			return this.blocks;
		}
	}

	class Filesystem
	{
		private const int BLOCK_SIZE = 256;

		private readonly Dictionary<string, File> files;
		private int allocatedBlocksCount;

		public Filesystem()
		{
			this.files = new Dictionary<string, File>();
			this.allocatedBlocksCount = 0;
		}

		public void Append(string filename, string content)
		{
			var blocks = Filesystem.SplitBlocks(content);
			File file;
			if (!this.files.TryGetValue(filename, out file))
			{
				file = new File();
				this.files[filename] = file;
			}
			file.Append(blocks);
			this.allocatedBlocksCount += blocks.Length;
		}

		private static Block[] SplitBlocks(string content)
		{
			var blocks = new Block[content.Length / Filesystem.BLOCK_SIZE];
			for (int i = 0, j = 0; j < blocks.Length; i += Filesystem.BLOCK_SIZE, ++j)
			{
				blocks[j] = new Block(content.Substring(i, Filesystem.BLOCK_SIZE));
			}
			return blocks;
		}

		public void Remove(string filename)
		{
			File file;
			if(this.files.TryGetValue(filename, out file))
			{
				this.allocatedBlocksCount -= file.Remove();
				this.files.Remove(filename);
			}
		}

		public void Copy(string source, string destination)
		{
			File sourceFile;
			File destinationFile;
			this.PreCopy(source, destination, out sourceFile, out destinationFile);

			var blocks = sourceFile.GetBlocks()
				.Select(b => b.Copy())
				.ToArray();
			destinationFile.Append(blocks);
			this.allocatedBlocksCount += blocks.Length;
		}

		public void CoW(string source, string destination)
		{
			File sourceFile;
			File destinationFile;
			this.PreCopy(source, destination, out sourceFile, out destinationFile);

			var blocks = sourceFile.GetBlocks()
				.ToArray();
			destinationFile.Append(blocks);
		}

		private void PreCopy(string sourceFilename, string destinationFilename, out File sourceFile, out File destinationFile)
		{
			if (!this.files.TryGetValue(sourceFilename, out sourceFile))
			{
				sourceFile = new File();
				this.files[sourceFilename] = sourceFile;
			}

			if (this.files.TryGetValue(destinationFilename, out destinationFile))
			{
				destinationFile.Remove();
			}
			destinationFile = new File();
			this.files[destinationFilename] = destinationFile;
		}

		public void Dedup()
		{
			var dedup = new Dictionary<Block, Block>(); // C# HashSet is stupid
			foreach (var kvp in this.files)
			{
				var file = kvp.Value;
				var blocks = file.GetBlocks();

				for(int i = 0; i < blocks.Count; ++i)
				{
					Block prevBlock;
					if(dedup.TryGetValue(blocks[i], out prevBlock))
					{
						blocks[i].Free();
						blocks[i] = prevBlock.Reference();
						--this.allocatedBlocksCount;
					}
					else
					{
						dedup[blocks[i]] = blocks[i];
					}
				}
			}
		}

		public int Usage()
		{
			return this.allocatedBlocksCount;
		}

		public int Size(string filename)
		{
			File file;
			if (!this.files.TryGetValue(filename, out file))
			{
				return 0;
			}
			return file.Size();
		}
	}

	class Program
	{
		static void Main()
		{
			var fs = new Filesystem();

			var output = new StringBuilder();

			while (true)
			{
				var line = Console.ReadLine();
				if (line == "exit")
				{
					break;
				}

				var strs = line.Split(' ');
				if (strs[0] == "append")
				{
					fs.Append(strs[1], strs[2]);
				}
				else if (strs[0] == "copy")
				{
					fs.Copy(strs[1], strs[2]);
				}
				else if (strs[0] == "cow")
				{
					fs.CoW(strs[1], strs[2]);
				}
				else if (strs[0] == "remove")
				{
					fs.Remove(strs[1]);
				}
				else if (strs[0] == "dedup")
				{
					fs.Dedup();
				}
				else if (strs[0] == "usage")
				{
					var usage = fs.Usage();
					output.AppendLine(string.Format("{0} blocks are currently in use.", usage));
				}
				else if (strs[0] == "size")
				{
					var size = fs.Size(strs[1]);
					output.AppendLine(string.Format("{0} is {1} blocks large.", strs[1], size));
				}
				else
				{
					throw new NotSupportedException("No such command " + line);
				}
			}

			Console.WriteLine(output.ToString().Trim());
		}
	}
}

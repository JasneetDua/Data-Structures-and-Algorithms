using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _FileSystem2
{
    class FileSystem
    {
        enum ConnectionType
        {
            Parent, Child
        }

        enum Operation
        {
            Move, Copy,
        }

        class FileSystemNode : IComparable<FileSystemNode>
        {
            public FileSystemNode(string name, string path, FileSystemNode parent)
            {
                this.Name = name;
                this.Path = path;
                this.Parent = parent;
                this.Children = new SortedSet<FileSystemNode>();
            }

            public string Path { get; set; }

            public string Name { get; set; }

            public FileSystemNode Parent { get; set; }

            public ISet<FileSystemNode> Children { get; set; }

            public int CompareTo(FileSystemNode other)
            {
                return this.Path.CompareTo(other.Path);
            }
        }

        FileSystemNode root;

        FileSystemNode location;

        Dictionary<string, FileSystemNode> graph;

        public FileSystem()
        {
            this.root = new FileSystemNode("", "/", null);
            this.location = root;
            this.graph = new Dictionary<string, FileSystemNode>();
            this.graph.Add(root.Path, root);
        }

        void AddEdge(string from, string to, string fromPath, string toPath)
        {
            if (this.graph.ContainsKey(fromPath) == false)
            {
                throw new Exception("Invalid parent");
            }

            var parent = this.graph[fromPath];

            if (this.graph.ContainsKey(toPath) == false)
            {
                this.graph[toPath] = new FileSystemNode(to, toPath, parent);
            }

            var child = this.graph[toPath];

            parent.Children.Add(child);
        }

        void Traverse(FileSystemNode node, ISet<string> visited, string prefix = "", Func<string, bool> filter = null)
        {
            if (node == null || visited.Contains(node.Path))
            {
                return;
            }

            visited.Add(node.Path);

            var pathToPrint = (prefix + node.Path).Replace("//", "/");

            if (filter == null || filter(node.Name))
            {
                Console.WriteLine(pathToPrint);
            }

            Traverse(node.Parent, visited, "../" + prefix, filter);

            node.Children
                .Where(next => visited.Contains(next.Path) == false)
                .ToList()
                .ForEach(next => Traverse(next, visited, prefix, filter));
        }

        FileSystemNode FindNode(string path)
        {
            if (path.StartsWith("/"))
            {
                return this.graph.ContainsKey(path)
                           ? this.graph[path]
                           : null;
            }

            var parts = path.Split('/');

            var current = this.location;

            foreach (var part in parts)
            {
                if(current == null) 
                {
                    return null;
                }

                if(part == "..")
                {
                    current = current.Parent;
                } 
                else {
                    current = current.Children.FirstOrDefault(next => next.Name == part);
                }
            }

            return current;
        }

        void CopyOrMove(string sourcePath, string destDirPath, Operation operation)
        {
            var source = this.FindNode(sourcePath);

            //if (this.graph.ContainsKey(sourcePath) == false)
            //{
            //    throw new Exception("Invalid file path");
            //}

            //var source = this.graph[sourcePath];
            if (source == null)
            {
                throw new Exception("Invalid file path");
            }

            if (source.Children.Count > 0)
            {
                throw new Exception("Cannot copy directories");
            }

            if (destDirPath.EndsWith("/") == true)
            {
                destDirPath = destDirPath.Substring(0, destDirPath.Length - 1);
            }

            var destPath = destDirPath + "/" + source.Name;

            if (this.graph.ContainsKey(destPath) == true)
            {
                throw new Exception("Move cannot overwrite files");
            }

            if (operation == Operation.Move)
            {
                if (source.Parent != null)
                {
                    source.Parent.Children.Remove(source);
                }

                this.graph.Remove(source.Path);
            }

            this.Add(destPath);
        }

		public void Add(string filepath)
		{
			var edges = filepath.Split('/');
			var path = new StringBuilder();

			path.Append(edges[0]);

			var isRoot = filepath.StartsWith("/");

			for (int i = 1; i < edges.Length; i++)
			{
				var parent = edges[i - 1];
				var child = edges[i];
				var parentPath = path.ToString();
				if (isRoot)
				{
					parentPath = "/" + parentPath;
					isRoot = false;
				}
				var childPath = path + "/" + edges[i];

				this.AddEdge(parent, child, parentPath, childPath);
				path.Append("/");
				path.Append(edges[i]);
			}
		}

        public void ChangeDir(string destPath) 
        {
            var dest = this.FindNode(destPath);

            if(dest == null) 
            {
                throw new Exception("Invalid path");
            }

            this.location = dest;
        }

        public void Move(string sourcePath, string destDirPath)
        {
            this.CopyOrMove(sourcePath, destDirPath, Operation.Move);
        }

        public void Copy(string sourcePath, string destDirPath)
        {
            this.CopyOrMove(sourcePath, destDirPath, Operation.Copy);
        }

        public void Find(string pattern)
        {
            this.Traverse(this.location, new HashSet<string>(), filter: (str) => str.Contains(pattern));
        }

        public void Print()
        {
            this.Traverse(this.location, new HashSet<string>());
        }
    }

    class FileSystemSolution
    {
        static void HandleAdd(FileSystem fs, params string[] args)
        {
            fs.Add(args[1]);
        }

        static void HandleCopy(FileSystem fs, params string[] args) 
        {
            fs.Copy(args[1], args[2]);
        }

		static void HandleMove(FileSystem fs, params string[] args)
		{
            fs.Move(args[1], args[2]);
		}

        static void HandleChangeDir(FileSystem fs, params string[] args) 
        {
            fs.ChangeDir(args[1]);
        }

        static void HandleFind(FileSystem fs, params string[] args)
        {
            fs.Find(args[1]);
        }

        static void HandlePrint(FileSystem fs, params string[] args)
        {
            fs.Print();
        }

        public static void Main()
        {
            var commands = new Dictionary<string, Action<FileSystem, string[]>>()
            {
                { "mk", HandleAdd },
                { "cp", HandleCopy },
                { "find", HandleFind },
                { "mv", HandleMove },
                { "ls", HandlePrint },
                { "cd", HandleChangeDir },
            };

            var input = @"mk /home/minkov/repos/dsa/tasks.md
mk /home/minkov/workspace/cs/FileSystem/FileSystemSolution.cs
mk /home/minkov/workspace/cs/FileSystem/FileSystem.csproj
mk /home/minkov/workspace/cs/FileSystem/bin/Debug/FileSystem.exe
mk /home/minkov/workspace/cs/FileSystem/bin/Release
mk /tmp/coki.tmp
ls
exit";

            // Console.SetIn(new StringReader(input));

            var output = new StringBuilder();
            var oldOutput = Console.Out;
            Console.SetOut(new StringWriter(output));

            var fs = new FileSystem();

            var command = Console.ReadLine()
                                 .Split(' ');
            
            while(command[0] != "exit")
            {
                try
                {
                    commands[command[0]](fs, command);
                }
                catch
                {
                    Console.WriteLine("ERROR");
                }
                command = Console.ReadLine()
                                 .Split(' ');
            }

            Console.SetOut(oldOutput);

            Console.WriteLine(output);
        }
    }
}

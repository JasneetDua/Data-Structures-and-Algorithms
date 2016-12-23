using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeSpaceTopological
{
    class Job : IComparable<Job>
    {
        public int Time { get; private set; }

        public int Id { get; private set; }

        public Job(int id, int time)
        {
            this.Id = id;
            this.Time = time;
        }

        public int CompareTo(Job other)
        {
            var timeComparison = this.Time.CompareTo(other.Time);

            return timeComparison != 0 ? timeComparison : this.Id.CompareTo(other.Id);
        }
    }

    class Solution
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var minutes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var parentsCount = new int[n];
            List<int>[] parentToChildren = new List<int>[n];

            for (var i = 0; i < n; i++)
            {
                var dependencies = Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1).ToList();

                if(dependencies.Count == 1 && dependencies[0] == -1)
                {
                    continue;
                }

                parentsCount[i] += dependencies.Count;

                foreach (var dependencyId in dependencies)
                {
                    if (parentToChildren[dependencyId] == null)
                    {
                        parentToChildren[dependencyId] = new List<int>();
                    }

                    parentToChildren[dependencyId].Add(i);
                }
            }

            var result = TraverseTopological(minutes, parentsCount, parentToChildren);

            Console.WriteLine(result);
        }

        static int TraverseTopological(int[] minutes, int[] parentsCount, List<int>[] parents)
        {
            var jobs = new SortedSet<Job>();

            for (int i = 0; i < parentsCount.Length; i++)
            {
                if(parentsCount[i] == 0)
                {
                    jobs.Add(new Job(i, minutes[i]));
                }
            }

            var result = 0;
            var jobsCompleted = 0;

            while (jobs.Count > 0)
            {
                var current = jobs.First();
                jobs.Remove(current);

                jobsCompleted++;
                result = current.Time;

                if (parents[current.Id] == null)
                {
                    continue;
                }

                // insert other jobs without dependencies in the set
                foreach (var childIndex in parents[current.Id])
                {
                    parentsCount[childIndex]--;
                    if(parentsCount[childIndex] == 0)
                    {
                        jobs.Add(new Job(childIndex, minutes[childIndex] + current.Time));
                    }
                }
            }

            return jobsCompleted == parents.Length ? result : -1;
        }
    }
}
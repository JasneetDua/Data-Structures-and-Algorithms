namespace StackExample
{
    using System;
    using System.Collections.Generic;

    public static class StackExample
    {
        public static void Main()
        {
            var stack = new Stack<string>();

            stack.Push("1. Nikolay");
            stack.Push("2. Ivo");
            stack.Push("3. Doncho");
            stack.Push("4. Cuki");
            stack.Push("5. Evlogi");

            Console.WriteLine("Top = {0}", stack.Peek());
            while (stack.Count > 0)
            {
                var personName = stack.Pop();
                Console.WriteLine(personName);
            }
        }
    }
}
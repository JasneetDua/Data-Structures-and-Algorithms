using System;
using System.Collections.Generic;

class RPN
{
	static void Main()
	{
		var expression = Console.ReadLine();
		var stack = new Stack<long>();

		foreach(var element in expression.Split(' '))
		{
			long number;
			if(!long.TryParse(element, out number))
			{
				var op2 = stack.Pop();
				var op1 = stack.Pop();

				switch(element)
				{
					case "+": number = op1 + op2; break;
					case "-": number = op1 - op2; break;
					case "*": number = op1 * op2; break;
					case "/": number = op1 / op2; break;
					case "&": number = op1 & op2; break;
					case "|": number = op1 | op2; break;
					case "^": number = op1 ^ op2; break;
					default: throw new Exception("Invalid operator");
				}
			}

			stack.Push(number);
		}

		if(stack.Count != 1)
		{
			throw new Exception("Incomplete expression");
		}

		Console.WriteLine(stack.Peek());
	}
}

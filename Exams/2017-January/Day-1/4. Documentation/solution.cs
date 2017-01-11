using System;

namespace Documentation
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();

            int operations = 0;
            int englishCharactersCount = 26;
            int minCharValue = 97;
            int maxCharValue = 122;

            int left = 0;
            int right = text.Length - 1;
            while (left < right)
            {
                int leftChar = text[left];
                int rightChar = text[right];

                while ((leftChar < minCharValue || leftChar > maxCharValue) && left < right)
                {
                    left++;
                    leftChar = text[left];
                }

                while ((rightChar < minCharValue || rightChar > maxCharValue) && left < right)
                {
                    right--;
                    rightChar = text[right];
                }

                if (left >= right)
                {
                    break;
                }

                int diff = Math.Abs(text[left] - text[right]);
                operations += Math.Min(diff, englishCharactersCount - diff);

                left++;
                right--;
            }
            
            Console.WriteLine(operations);
        }
    }
}
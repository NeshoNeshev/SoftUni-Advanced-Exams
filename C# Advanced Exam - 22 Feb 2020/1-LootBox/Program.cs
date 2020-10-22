using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray());

            Stack<int> stack = new Stack<int>(Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray());

            //Queue<int> queue = new Queue<int>(queueNumbers);
            //Stack<int> stack = new Stack<int>(stackNumbers);
            

            int value = 0;
            bool isEpic = false;
            while (true)
            {
                if (stack.Count == 0 || queue.Count == 0)
                {
                    break;
                }
                int sum = stack.Peek() + queue.Peek();
                if (sum % 2 == 0)
                {
                    value += sum;
                    stack.Pop();
                    queue.Dequeue();
                    
                }
                else
                {
                    queue.Enqueue(stack.Pop());
                }
            }
            if (value >= 100)
            {
                isEpic = true;
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
                if (isEpic)
                {
                    Console.WriteLine($"Your loot was epic! Value: {value}");
                }
                else
                {
                    Console.WriteLine($"Your loot was poor... Value: {value}");
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
                if (isEpic)
                {
                    Console.WriteLine($"Your loot was epic! Value: {value}");
                }
                else
                {
                    Console.WriteLine($"Your loot was poor... Value: {value}");
                }
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var thread = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
           
            int num = int.Parse(Console.ReadLine());
            
            Queue<int> threads = new Queue<int>(thread);
            Stack<int> tasks = new Stack<int>(task);
            int tr = 0;
            while (true)
            {
                int a = tasks.Peek();
                int b = threads.Peek();
                if (threads.Peek() >= tasks.Peek())
                {
                    
                    if (tasks.Peek()==num)
                    {
                        tr = threads.Peek();
                        
                        break;
                    }
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    if (tasks.Peek() == num)
                    {
                        tr = threads.Peek();
                        
                        break;
                    }
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {tr} killed task {num}");
            Console.WriteLine(string.Join(" ",threads));
            
        }
    }
}

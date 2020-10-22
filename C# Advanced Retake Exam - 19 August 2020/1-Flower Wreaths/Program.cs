using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var lilies = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var roses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(lilies);
            Queue<int> queue = new Queue<int>(roses);
            int flowers = 0;
            int counter = 0;
            while (true)
            {
                if (stack.Count == 0 || queue.Count == 0)
                {
                    break;
                }
                int lilie = stack.Pop();
                if (lilie + queue.Peek() == 15)
                {
                    counter++;
                    queue.Dequeue();
                }
                else if (lilie + queue.Peek() < 15)
                {
                    flowers += queue.Dequeue() + lilie;
                }
                else if (lilie + queue.Peek() > 15)
                {

                    lilie -= 2;
                    stack.Push(lilie);
                }
            }
            if (flowers > 15)
            {
                counter += flowers / 15; ;
            }

            if (counter >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {counter} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - counter} wreaths more!");
            }


        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            int matches = 0;


            var m = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var f = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> males = new Stack<int>(m);
            Queue<int> females = new Queue<int>(f);
            
            while (true)
            {
                if (males.Count == 0 || females.Count == 0)
                {
                    break;

                }
                int male = males.Peek();
                int female = females.Peek();
                if (male <= 0)
                {
                    males.Pop();
                    continue;
                }
                if (female <= 0)
                {
                    females.Dequeue();
                    continue;
                }
                if (male == female)
                {
                    males.Pop();
                    females.Dequeue();
                    matches++;
                }
                else
                {
                    if (female % 25 == 0 && female != 0)
                    {
                        females.Dequeue();
                        if (females.Count == 0)
                        {
                            break;
                        }
                        females.Dequeue();
                        continue;
                    }
                    else if (male % 25 == 0 && male != 0)
                    {
                        males.Pop();
                        if (males.Count == 0)
                        {
                            break;
                        }
                        males.Pop();
                        continue;
                    }
                    females.Dequeue();

                    int num = males.Pop();
                    num -= 2;
                    males.Push(num);

                }
            }
            Console.WriteLine($"Matches: {matches}");
            if (males.Count != 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }
            if (females.Count != 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}

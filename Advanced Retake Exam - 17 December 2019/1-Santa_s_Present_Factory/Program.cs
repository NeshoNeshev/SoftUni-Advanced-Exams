using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            const int doll = 150;
            const int woodenTrain = 250;
            const int tedyBear = 300;
            const int bicycle = 400;
            string bicycleCount = "Bicycle";
            string dollCount = "Doll";
            string bearCount = "Teddy bear";
            string trainCount = "Wooden train";

            Dictionary<string, int> gifts = new Dictionary<string, int>();

            gifts.Add(bicycleCount, 0);
            gifts.Add(dollCount, 0);
            gifts.Add(bearCount, 0);
            gifts.Add(trainCount, 0);


            var stack = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var queue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> materials = new Stack<int>(stack);
            Queue<int> magics = new Queue<int>(queue);

            while (true)
            {
                if (materials.Count == 0 || magics.Count == 0)
                {
                    break;
                }
                if (magics.Peek() == 0|| materials.Peek() == 0)
                {
                    if (magics.Peek() == 0)
                    {
                        magics.Dequeue();
                        
                    }
                    if (materials.Peek() == 0)
                    {
                        materials.Pop();
                       
                    }
                    continue;
                }
                
                int result = magics.Peek() * materials.Peek();
                if (result < 0)
                {
                    int newMaterials = materials.Pop() + magics.Dequeue();//
                    if (newMaterials>0)
                    {
                        materials.Push(newMaterials);
                    }
                    
                }
                else if (result == doll)
                {
                    gifts[dollCount]++;
                    magics.Dequeue();
                    materials.Pop();
                }
                else if (result == woodenTrain)
                {
                    gifts[trainCount]++;
                    magics.Dequeue();
                    materials.Pop();
                }
                else if (result == tedyBear)
                {
                    gifts[bearCount]++;
                    magics.Dequeue();
                    materials.Pop();
                }
                else if (result == bicycle)
                {
                    gifts[bicycleCount]++;
                    magics.Dequeue();
                    materials.Pop();
                }
                else
                {
                    magics.Dequeue();
                    materials.Push(materials.Pop() + 15);
                }


            }
            var sorted = gifts.OrderBy(x => x.Key).Where(x => x.Value > 0);
            if ((gifts[dollCount] > 0 && gifts[trainCount] > 0) || (gifts[bearCount] > 0 && gifts[bicycleCount] > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
                if (materials.Count > 0)
                {
                    Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
                }
                if (magics.Count > 0)
                {
                    Console.WriteLine($"Magic left: {string.Join(", ", magics)}");
                }
                foreach (var item in sorted)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
                if (materials.Count > 0)
                {
                    Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
                }
                if (magics.Count > 0)
                {
                    Console.WriteLine($"Magic left: {string.Join(", ", magics)}");
                }
                foreach (var item in sorted)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1Bombs
{
    class Program
    {
        static void Main(string[] args)
        {

            const int datura = 40;
            const int cherry = 60;
            const int smoke = 120;

            int daturaCount = 0;
            int cherryCount = 0;
            int smokeCount = 0;

            var input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var secondInput = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> bombEfect = new Queue<int>(input);
            Stack<int> bombCaasting = new Stack<int>(secondInput);

            bool isFull = false;
            bool isEmty = false;
            while (true)
            {
                if (daturaCount >= 3 && smokeCount >= 3 && cherryCount >= 3)
                {
                    isFull = true;
                    break;
                }
                if (bombEfect.Count == 0 || bombCaasting.Count == 0)
                {
                    isEmty = true;
                    break;
                }
                int efect = bombEfect.Peek() + bombCaasting.Peek();
                if (efect == cherry)
                {
                    cherryCount++;
                    bombEfect.Dequeue();
                    bombCaasting.Pop();
                }
                else if (efect == datura)
                {
                    daturaCount++;
                    bombEfect.Dequeue();
                    bombCaasting.Pop();
                }
                else if (efect == smoke)
                {
                    smokeCount++;
                    bombEfect.Dequeue();
                    bombCaasting.Pop();
                }
                else
                {
                    int casting = bombCaasting.Pop() - 5;
                    bombCaasting.Push(casting);
                }
            }
            if (isFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                if (bombEfect.Count > 0)
                {
                    Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEfect)}");
                }
                else
                {
                    Console.WriteLine("Bomb Effects: empty");
                }
                if (bombCaasting.Count > 0)
                {
                    Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCaasting)}");
                }
                else
                {
                    Console.WriteLine("Bomb Casings: empty");
                }
                Console.WriteLine($"Cherry Bombs: {cherryCount}");
                Console.WriteLine($"Datura Bombs: {daturaCount}");
                Console.WriteLine($"Smoke Decoy Bombs: {smokeCount}");
            }
            if (isEmty)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
                if (bombEfect.Count > 0)
                {
                    Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEfect)}");
                }
                else
                {
                    Console.WriteLine("Bomb Effects: empty");
                }
                if (bombCaasting.Count > 0)
                {
                    Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCaasting)}");
                }
                else
                {
                    Console.WriteLine("Bomb Casings: empty");
                }
                Console.WriteLine($"Cherry Bombs: {cherryCount}");
                Console.WriteLine($"Datura Bombs: {daturaCount}");
                Console.WriteLine($"Smoke Decoy Bombs: {smokeCount}");
            }
        }
    }
}

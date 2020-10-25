using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int r = nums[0];
            int c = nums[1];
            int[,] matrix = new int[r, c];
            FillMatrix(matrix);
            
            var command = Console.ReadLine().Split();
            while (true)
            {
                if (command.Contains("Plow"))
                {
                    break;
                }
                int row = int.Parse(command[0]);
                int col = int.Parse(command[1]);
                if (!IsInside(matrix, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        matrix[row, i] += 1;
                    }
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        matrix[j, col] += 1;
                    }
                    matrix[row, col] -= 1;
                }
                command = Console.ReadLine().Split();
            }
            PrintMatrix(matrix);
        }
        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }

        private static void PrintMatrix(int[,] cheesBoard)
        {
            for (int row = 0; row < cheesBoard.GetLength(0); row++)
            {
                for (int col = 0; col < cheesBoard.GetLength(1); col++)
                {
                    Console.Write(cheesBoard[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        private static bool IsInside(int[,] board, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < board.GetLength(0)
                   && targetCol >= 0 && targetCol < board.GetLength(1);

        }
    }
}
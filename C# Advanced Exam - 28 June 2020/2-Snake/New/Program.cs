using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int startingRow = -1;
            int startingCol = -1;
            int food = 0;
            FillMatrix(matrix, ref startingRow, ref startingCol);

            bool isWin = false;
            while (true)
            {
               
                matrix[startingRow, startingCol] = '.';
                if (food == 10)
                {
                    isWin = true;
                    matrix[startingRow, startingCol] = 'S';
                    break;
                }
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        startingRow--;

                        break;
                    case "down":
                        startingRow++;

                        break;
                    case "left":
                        startingCol--;

                        break;
                    case "right":
                        startingCol++;

                        break;
                }
                if (IsInside(matrix, startingRow, startingCol))
                {
                    if (matrix[startingRow, startingCol] == '*')
                    {
                        matrix[startingRow, startingCol] = '.';
                        food++;
                    }
                    if (matrix[startingRow, startingCol] == 'B')
                    {
                        matrix[startingRow, startingCol] = '.';
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {                          
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                
                                if (matrix[row, col] == 'B')
                                {
                                    startingRow = row;
                                    startingCol = col;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            if (isWin)
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {food}");
            }
            else
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {food}");
            }
            PrintMatrix(matrix);
        }

        private static void FillMatrix(char[,] matrix, ref int startingRow, ref int startingCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];
                    if (matrix[row, col] == 'S')
                    {
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] cheesBoard)
        {
            for (int row = 0; row < cheesBoard.GetLength(0); row++)
            {
                for (int col = 0; col < cheesBoard.GetLength(1); col++)
                {
                    Console.Write(cheesBoard[row, col]);
                }
                Console.WriteLine();
            }
        }


        private static bool IsInside(char[,] board, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < board.GetLength(0)
                   && targetCol >= 0 && targetCol < board.GetLength(1);

        }
    }
}

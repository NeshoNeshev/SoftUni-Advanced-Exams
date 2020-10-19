using System;

namespace _2Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] snakeBoard = new char[n, n];

            int foodEaten = 0;

            int startingRow = -1;
            int startingColl = -1;

           

            FillMatrix(snakeBoard, ref startingRow, ref startingColl);
            bool isOutside = false;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "left")
                {
                    if (IsInside(snakeBoard, startingRow, startingColl - 1))
                    {
                        if (snakeBoard[startingRow, startingColl - 1] != 'B')
                        {
                            if (snakeBoard[startingRow, startingColl - 1] == '*')
                            {
                                foodEaten++;
                            }
                            snakeBoard[startingRow, startingColl] = '.';
                            snakeBoard[startingRow, startingColl - 1] = 'S';
                            startingColl -= 1;
                        }
                        else
                        {
                            snakeBoard[startingRow, startingColl - 1] = '.';
                            snakeBoard[startingRow, startingColl] = '.';
                            for (int row = 0; row < snakeBoard.GetLength(0); row++)
                            {
                                for (int col = 0; col < snakeBoard.GetLength(1); col++)
                                {
                                    if (snakeBoard[row, col] == 'B')
                                    {
                                        startingRow = row;
                                        startingColl = col;
                                        snakeBoard[row, col] = 'S';
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        snakeBoard[startingRow, startingColl] = '.';
                        isOutside = true;
                        break;
                    }

                }
                if (command == "right")
                {
                    if (IsInside(snakeBoard, startingRow, startingColl + 1))
                    {
                        if (snakeBoard[startingRow, startingColl + 1] != 'B')
                        {
                            if (snakeBoard[startingRow, startingColl + 1] == '*')
                            {
                                foodEaten++;
                            }
                            snakeBoard[startingRow, startingColl] = '.';
                            snakeBoard[startingRow, startingColl + 1] = 'S';
                            startingColl += 1;
                        }
                        else
                        {
                            snakeBoard[startingRow, startingColl + 1] = '.';
                            snakeBoard[startingRow, startingColl] = '.';
                            for (int row = 0; row < snakeBoard.GetLength(0); row++)
                            {
                                for (int col = 0; col < snakeBoard.GetLength(1); col++)
                                {
                                    if (snakeBoard[row, col] == 'B')
                                    {
                                        startingRow = row;
                                        startingColl = col;
                                        snakeBoard[row, col] = 'S';
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        snakeBoard[startingRow, startingColl] = '.';
                        isOutside = true;
                        break;
                    }
                }
                if (command == "down")
                {
                    if (IsInside(snakeBoard, startingRow + 1, startingColl))
                    {
                        if (snakeBoard[startingRow + 1, startingColl] != 'B')
                        {
                            if (snakeBoard[startingRow + 1, startingColl] == '*')
                            {
                                foodEaten++;
                            }
                            snakeBoard[startingRow, startingColl] = '.';
                            snakeBoard[startingRow + 1, startingColl] = 'S';
                            startingRow += 1;
                        }
                        else
                        {
                            snakeBoard[startingRow + 1, startingColl] = '.';
                            snakeBoard[startingRow, startingColl] = '.';
                            for (int row = 0; row < snakeBoard.GetLength(0); row++)
                            {
                                for (int col = 0; col < snakeBoard.GetLength(1); col++)
                                {
                                    if (snakeBoard[row, col] == 'B')
                                    {
                                        startingRow = row;
                                        startingColl = col;
                                        snakeBoard[row, col] = 'S';
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        snakeBoard[startingRow, startingColl] = '.';
                        isOutside = true;
                        break;
                    }
                }
                if (command == "up")
                {
                    if (IsInside(snakeBoard, startingRow - 1, startingColl))
                    {
                        if (IsInside(snakeBoard, startingRow - 1, startingColl))
                        {
                            if (snakeBoard[startingRow - 1, startingColl] != 'B')
                            {
                                if (snakeBoard[startingRow - 1, startingColl] == '*')
                                {
                                    foodEaten++;
                                }
                                snakeBoard[startingRow, startingColl] = '.';
                                snakeBoard[startingRow - 1, startingColl] = 'S';
                                startingRow -= 1;
                            }
                            else
                            {
                                snakeBoard[startingRow - 1, startingColl] = '.';
                                snakeBoard[startingRow, startingColl] = '.';
                                for (int row = 0; row < snakeBoard.GetLength(0); row++)
                                {
                                    for (int col = 0; col < snakeBoard.GetLength(1); col++)
                                    {
                                        if (snakeBoard[row, col] == 'B')
                                        {
                                            startingRow = row;
                                            startingColl = col;
                                            snakeBoard[row, col] = 'S';
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        snakeBoard[startingRow, startingColl] = '.';
                        isOutside = true;
                        break;
                    }
                }
                if (foodEaten == 10)
                {
                    break;
                }

            }
            if (isOutside)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {foodEaten}");
                PrintMatrix(snakeBoard);
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {foodEaten}");
                PrintMatrix(snakeBoard);
            }
        }
        private static void PrintMatrix(char[,] snakeBoard)
        {
            for (int row = 0; row < snakeBoard.GetLength(0); row++)
            {
                for (int col = 0; col < snakeBoard.GetLength(1); col++)
                {
                    Console.Write(snakeBoard[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static bool IsInside(char[,] snakeBoard, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < snakeBoard.GetLength(0)
                   && targetCol >= 0 && targetCol < snakeBoard.GetLength(1);

        }
        private static void FillMatrix(char[,] snakeBoard, ref int startingRow, ref int startingColl)
        {
            for (int row = 0; row < snakeBoard.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
                for (int col = 0; col < snakeBoard.GetLength(1); col++)
                {
                    snakeBoard[row, col] = chars[col];
                    if (chars[col] == 'S')
                    {
                        startingRow = row;
                        startingColl = col;
                    }
                   
                }
            }
        }
    }
}

using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int counter = 0;
            int startingRow = -1;
            int startingCol = -1;
            FillMatrix(matrix, ref startingRow, ref startingCol);
            bool isWin = false;
            matrix[startingRow, startingCol] = '.';
            while (true)
            {
                string command = Console.ReadLine();
                if (command=="End")
                {
                    isWin = true;
                    matrix[startingRow, startingCol] = 'B';
                    break;
                }
                switch (command)
                {
                    case "up":
                        startingRow--;
                        if (IsInside(matrix,startingRow,startingCol) && matrix[startingRow, startingCol] == 'O')
                        {
                            matrix[startingRow, startingCol] = '.';
                            startingRow--;
                        }
                        break;
                    case "down":
                        startingRow++;
                        if (IsInside(matrix, startingRow, startingCol) && matrix[startingRow, startingCol] == 'O')
                        {
                            matrix[startingRow, startingCol] = '.';
                            startingRow++;
                        }
                        break;
                    case "left":
                        startingCol--;
                        if (IsInside(matrix, startingRow, startingCol) && matrix[startingRow, startingCol] == 'O')
                        {
                            matrix[startingRow, startingCol] = '.';
                            startingCol--;
                        }
                        break;
                    case "right":
                        startingCol++;
                        if (IsInside(matrix, startingRow, startingCol) && matrix[startingRow, startingCol] == 'O')
                        {
                            matrix[startingRow, startingCol] = '.';
                            startingCol++;
                        }
                        break;
                }
                if (IsInside(matrix,startingRow,startingCol))
                {
                    if (matrix[startingRow,startingCol]=='f')
                    {
                        counter++;
                        matrix[startingRow, startingCol] = '.';

                    }
                    
                }
                else
                {
                    break;
                }
            }
            if (!isWin)
            {
                Console.WriteLine("The bee got lost!");
            }
            if (counter>=5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {counter} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-counter} flowers more");
            }
            PrintMatrix(matrix);
        }

        private static void FillMatrix(char[,] matrix, ref int startingRow, ref int startingCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var chars = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];
                    if (matrix[row, col] == 'B')
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
                    Console.Write(cheesBoard[row, col] );
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


using System;
using System.Linq;

namespace Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPresents = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int startingRow = -1;
            int startingCol = -1;
            int niceKid = 0;

            FillMatrix(matrix, ref startingRow, ref startingCol, ref niceKid);
            int count = niceKid;
            matrix[startingRow, startingCol] = '-';
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Christmas morning" || numberPresents <= 0)
                {
                    break;
                }
                
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
                    if (matrix[startingRow, startingCol] == 'V')
                    {
                        niceKid--;
                        numberPresents--;
                        matrix[startingRow, startingCol] = '-';
                    }
                    if (matrix[startingRow, startingCol] == 'X')
                    {
                        matrix[startingRow, startingCol] = '-';
                    }
                    if (IsHappy(matrix, startingRow, startingCol))
                    {
                        if (matrix[startingRow - 1, startingCol] != '-')
                        {
                            if (NiceKid(matrix, startingRow - 1, startingCol))
                            {
                                niceKid--;
                            }
                            numberPresents--;
                            matrix[startingRow - 1, startingCol] = '-';
                            if (numberPresents == 0)
                            {
                                break;
                            }
                        }
                        if (matrix[startingRow + 1, startingCol] != '-')
                        {
                            if (NiceKid(matrix, startingRow + 1, startingCol))
                            {
                                niceKid--;
                            }
                            numberPresents--;
                            matrix[startingRow + 1, startingCol] = '-';
                            if (numberPresents == 0)
                            {
                                break;
                            }
                        }
                        if (matrix[startingRow, startingCol - 1] != '-')
                        {
                            if (NiceKid(matrix, startingRow, startingCol - 1))
                            {
                                niceKid--;
                            }
                            numberPresents--;
                            matrix[startingRow, startingCol - 1] = '-';
                            if (numberPresents == 0)
                            {
                                break;
                            }
                        }
                        if (matrix[startingRow, startingCol + 1] != '-')
                        {
                            if (NiceKid(matrix, startingRow, startingCol + 1))
                            {
                                niceKid--;
                            }
                            numberPresents--;
                            matrix[startingRow, startingCol + 1] = '-';
                            if (numberPresents == 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            matrix[startingRow, startingCol] = 'S';
            if (numberPresents == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            PrintMatrix(matrix);
            if (niceKid == 0)
            {
                Console.WriteLine($"Good job, Santa! {count} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKid} nice kid/s.");
            }
        }
        public static bool NiceKid(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == 'V')
            {
                return true;
            }
            return false;
        }
        public static bool IsHappy(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == 'C')
            {
                return true;
            }
            return false;
        }
        private static void FillMatrix(char[,] matrix, ref int startingRow, ref int startingCol, ref int niceKid)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var chars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];
                    if (matrix[row, col] == 'S')
                    {
                        startingRow = row;
                        startingCol = col;
                    }
                    if (matrix[row, col] == 'V')
                    {
                        niceKid++;
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
                    Console.Write(cheesBoard[row, col] + " ");
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

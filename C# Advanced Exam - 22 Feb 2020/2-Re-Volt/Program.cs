using System;

namespace _2Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCommand = int.Parse(Console.ReadLine());

            int curentRow = -1;
            int curentCol = -1;
            char[,] board = new char[n, n];
            bool winer = false;
            FillMatrix(ref curentRow, ref curentCol, board);
            for (int i = 0; i < countOfCommand; i++)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    int row = curentRow - 1;

                    if (IsInside(board, row, curentCol))
                    {
                        if (isWin(board, row, curentCol))
                        {
                            board[curentRow, curentCol] = '-';
                            board[row, curentCol] = 'f';
                            winer = true;
                            break;
                        }
                        else if (board[row, curentCol] == 'T')
                        {
                            continue;
                        }
                        else if (IsBonus(board, row, curentCol))
                        {
                            row -= 1;
                            if (IsInside(board, row, curentCol))
                            {
                                board[row, curentCol] = 'f';
                                board[curentRow, curentCol] = '-';
                                curentRow = row;
                            }
                            else
                            {
                                board[curentRow, curentCol] = '-';
                                curentRow = board.GetLength(0)-1;//sdjasdjaldska
                                if (isWin(board,curentRow,curentCol))
                                {
                                    board[curentRow, curentCol] = 'f';
                                    winer = true;
                                    break;
                                }
                                board[curentRow, curentCol] = 'f';
                            }
                        }
                        else
                        {
                            board[curentRow, curentCol] = '-';
                            curentRow -= 1;
                            board[curentRow, curentCol] = 'f';
                        }
                    }
                    else
                    {
                        board[curentRow, curentCol] = '-';
                        curentRow = board.GetLength(0)-1;
                        if (isWin(board, curentRow, curentCol))
                        {
                            board[curentRow, curentCol] = 'f';
                            winer = true;
                            break;
                        }
                        board[curentRow, curentCol] = 'f';
                    }
                }
                if (command == "down")
                {
                    int row = curentRow + 1;

                    if (IsInside(board, row, curentCol))
                    {
                        if (isWin(board, row, curentCol))
                        {
                            board[curentRow, curentCol] = '-';
                            board[row, curentCol] = 'f';
                            winer = true;
                            break;
                        }
                        else if (board[row, curentCol] == 'T')
                        {
                            continue;
                        }
                        else if (IsBonus(board, row, curentCol))
                        {
                            row += 1;
                            if (IsInside(board, row, curentCol))
                            {
                                board[row, curentCol] = 'f';
                                board[curentRow, curentCol] = '-';
                                curentRow = row;
                            }
                            else
                            {
                                board[curentRow, curentCol] = '-';
                                curentRow = 0;
                                if (isWin(board, curentRow, curentCol))
                                {
                                    board[curentRow, curentCol] = 'f';
                                    winer = true;
                                    break;
                                }
                                board[curentRow, curentCol] = 'f';
                            }
                        }
                        else
                        {
                            board[curentRow, curentCol] = '-';
                            curentRow += 1;
                            board[curentRow, curentCol] = 'f';
                        }
                    }
                    else
                    {
                        board[curentRow, curentCol] = '-';
                        curentRow = 0;
                        if (isWin(board, curentRow, curentCol))
                        {
                            board[curentRow, curentCol] = 'f';
                            winer = true;
                            break;
                        }
                        board[curentRow, curentCol] = 'f';
                    }
                }
                if (command == "right")
                {
                    int col = curentCol + 1;

                    if (IsInside(board, curentRow, col))
                    {
                        if (isWin(board, curentRow, col))
                        {
                            board[curentRow, curentCol] = '-';
                            board[curentRow, col] = 'f';
                            winer = true;
                            break;
                        }
                        else if (board[curentRow, col] == 'T')
                        {
                            continue;
                        }
                        else if (IsBonus(board, curentRow, col))
                        {
                            col += 1;
                            if (IsInside(board, curentRow, col))
                            {
                                board[curentRow, col] = 'f';
                                board[curentRow, curentCol] = '-';
                                curentCol = col;
                            }
                            else
                            {
                                board[curentRow, curentCol] = '-';
                                curentCol = 0;
                                if (isWin(board, curentRow, curentCol))
                                {
                                    board[curentRow, curentCol] = 'f';
                                    winer = true;
                                    break;
                                }
                                board[curentRow, curentCol] = 'f';
                            }
                        }
                        else
                        {
                            board[curentRow, curentCol] = '-';
                            curentCol += 1;
                            board[curentRow, curentCol] = 'f';
                        }
                    }
                    else
                    {
                        board[curentRow, curentCol] = '-';
                        curentCol = 0;
                        if (isWin(board, curentRow, curentCol))
                        {
                            board[curentRow, curentCol] = 'f';
                            winer = true;
                            break;
                        }
                        board[curentRow, curentCol] = 'f';
                    }
                }
                if (command == "left")
                {
                    int col = curentCol - 1;

                    if (IsInside(board, curentRow, col))
                    {
                        if (isWin(board, curentRow, col))
                        {
                            board[curentRow, curentCol] = '-';
                            board[curentRow, col] = 'f';
                            winer = true;
                            break;
                        }
                        else if (board[curentRow, col] == 'T')
                        {
                            continue;
                        }
                        else if (IsBonus(board, curentRow, col))
                        {
                            col -= 1;
                            if (IsInside(board, curentRow, col))
                            {
                                board[curentRow, col] = 'f';
                                board[curentRow, curentCol] = '-';
                                curentCol = col;
                            }
                            else
                            {
                                board[curentRow, curentCol] = '-';
                                curentCol = board.GetLength(1)-1;
                                if (isWin(board, curentRow, curentCol))
                                {
                                    board[curentRow, curentCol] = 'f';
                                    winer = true;
                                    break;
                                }
                                board[curentRow, curentCol] = 'f';
                            }
                        }
                        else
                        {
                            board[curentRow, curentCol] = '-';
                            curentCol -= 1;
                            board[curentRow, curentCol] = 'f';
                        }
                    }
                    else
                    {
                        board[curentRow, curentCol] = '-';
                        curentCol = board.GetLength(1)-1;
                        if (isWin(board, curentRow, curentCol))
                        {
                            board[curentRow, curentCol] = 'f';
                            winer = true;
                            break;
                        }
                        board[curentRow, curentCol] = 'f';
                    }
                }            
            }
            if (winer)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(board);
        }
        public static bool IsBonus(char[,] board, int row, int col)
        {
            if (board[row, col] == 'B')
            {
                return true;
            }
            return false;
        }
        public static bool isWin(char[,] board, int row, int col)
        {
            if (IsInside(board,row,col) && board[row, col] == 'F')
            {
                return true;
            }
            return false;
        }


        private static void FillMatrix(ref int startingRow, ref int startingCol, char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = chars[col];
                    if (board[row, col] == 'f')
                    {
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }
        }

        private static bool IsInside(char[,] board, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < board.GetLength(0)
                   && targetCol >= 0 && targetCol < board.GetLength(1);

        }
        private static void PrintMatrix(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

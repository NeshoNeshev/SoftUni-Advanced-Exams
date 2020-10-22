using System;
using System.Linq;

namespace Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int fRow = -1;
            int fCol = -1;

            int sRow = -1;
            int sCol = -1;
            FillMatrix(matrix, ref fRow, ref fCol, ref sRow, ref sCol);

            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0] == "up")
                {
                    fRow--;
                    if (IsInside(matrix, fRow, fCol))
                    {
                        if (IsDead(matrix, fRow, fCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[fRow, fCol] = 'f';
                        }
                    }
                    else
                    {
                        fRow = matrix.GetLength(0) - 1;
                        if (IsDead(matrix, fRow, fCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[fRow, fCol] = 'f';
                        }
                    }
                }
                else if (command[0] == "down")
                {
                    fRow++;
                    if (IsInside(matrix, fRow, fCol))
                    {
                        if (IsDead(matrix, fRow, fCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[fRow, fCol] = 'f';
                        }
                    }
                    else
                    {
                        fRow = 0;
                        if (IsDead(matrix, fRow, fCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[fRow, fCol] = 'f';
                        }
                    }
                }
                else if (command[0] == "right")
                {
                    fCol++;
                    if (IsInside(matrix, fRow, fCol))
                    {
                        if (IsDead(matrix, fRow, fCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[fRow, fCol] = 'f';
                        }
                    }
                    else
                    {
                        fCol = 0;
                        if (IsDead(matrix, fRow, fCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[fRow, fCol] = 'f';
                        }
                    }
                }
                else if (command[0] == "left")
                {
                    fCol--;
                    if (IsInside(matrix, fRow, fCol))
                    {
                        if (IsDead(matrix, fRow, fCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[fRow, fCol] = 'f';
                        }
                    }
                    else
                    {
                        fCol = matrix.GetLength(1) - 1;
                        if (IsDead(matrix, fRow, fCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[fRow, fCol] = 'f';
                        }
                    }
                }

                if (command[1] == "up")
                {
                    sRow--;
                    if (IsInside(matrix, sRow, sCol))
                    {
                        if (IsDead(matrix, sRow, sCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[sRow, sCol] = 's';
                        }
                    }
                    else
                    {
                        sRow = matrix.GetLength(0) - 1;
                        if (IsDead(matrix, sRow, sCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[sRow, sCol] = 's';
                        }
                    }
                }
                else if (command[1] == "down")
                {
                    sRow++;
                    if (IsInside(matrix, sRow, sCol))
                    {
                        if (IsDead(matrix, sRow, sCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[sRow, sCol] = 's';
                        }
                    }
                    else
                    {
                        sRow = 0;
                        if (IsDead(matrix, sRow, sCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[sRow, sCol] = 's';
                        }
                    }
                }
                else if (command[1] == "right")
                {
                    sCol++;
                    if (IsInside(matrix, sRow, sCol))
                    {
                        if (IsDead(matrix, sRow, sCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[sRow, sCol] = 's';
                        }
                    }
                    else
                    {
                        sCol = 0;
                        if (IsDead(matrix, sRow, sCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[sRow, sCol] = 's';
                        }
                    }
                }
                else if (command[1] == "left")
                {
                    sCol--;
                    if (IsInside(matrix, sRow, sCol))
                    {
                        if (IsDead(matrix, sRow, sCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[sRow, sCol] = 's';
                        }
                    }
                    else
                    {
                        sCol = matrix.GetLength(1) - 1;
                        if (IsDead(matrix, sRow, sCol))
                        {
                            break;
                        }
                        else
                        {
                            matrix[sRow, sCol] = 's';
                        }
                    }
                }
            }
            PrintMatrix(matrix);
        }
        private static void FillMatrix(char[,] matrix, ref int fRow, ref int fCol, ref int sRow, ref int sCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];
                    if (matrix[row, col] == 'f')
                    {
                        fRow = row;
                        fCol = col;
                    }
                    if (matrix[row, col] == 's')
                    {
                        sRow = row;
                        sCol = col;
                    }
                }
            }
        }

        public static bool IsDead(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == 's' || matrix[row, col] == 'f')
            {
                matrix[row, col] = 'x';
                return true;
            }
            return false;
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static bool IsInside(char[,] matrix, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < matrix.GetLength(0)
                   && targetCol >= 0 && targetCol < matrix.GetLength(1);
        }
    }
}

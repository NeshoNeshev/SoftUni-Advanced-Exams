using System;
using System.Text;

namespace Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder(text);
            int n = int.Parse(Console.ReadLine());
            int rowIndex = -1;
            int colIndex = -1;
            char[,] matrix = new char[n, n];

            FilMatrix(ref rowIndex, ref colIndex, matrix);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "up")
                {
                    int curentRow = rowIndex - 1;
                    if (IsInside(matrix, curentRow, colIndex))
                    {
                        if (matrix[curentRow, colIndex] != '-')
                        {
                            sb.Append(matrix[curentRow, colIndex]);
                            
                        }
                        matrix[curentRow, colIndex] = 'P';
                        matrix[rowIndex, colIndex] = '-';
                        rowIndex = curentRow;
                    }
                    else
                    {
                        if (sb.Length != 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                    }
                }

                else if (command == "down")
                {
                    int curentRow = rowIndex + 1;
                    if (IsInside(matrix, curentRow, colIndex))
                    {
                        if (matrix[curentRow, colIndex] != '-')
                        {
                            sb.Append(matrix[curentRow, colIndex]);
                            
                        }
                        matrix[curentRow, colIndex] = 'P';
                        matrix[rowIndex, colIndex] = '-';
                        rowIndex = curentRow;
                    }
                    else
                    {
                        if (sb.Length != 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                    }
                }

                else if (command == "left")
                {
                    int currentCol = colIndex -1 ;
                    if (IsInside(matrix, rowIndex, currentCol))
                    {
                        if (matrix[rowIndex, currentCol] != '-')
                        {
                            sb.Append(matrix[rowIndex, currentCol]);
                            
                        }
                        matrix[rowIndex, currentCol] = 'P';
                        matrix[rowIndex, colIndex] = '-';
                        colIndex = currentCol;
                    }
                    else
                    {
                        if (sb.Length != 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                    }
                }

                else if (command == "right")
                {
                    int currentCol = colIndex + 1;
                    if (IsInside(matrix, rowIndex, currentCol))
                    {
                        if (matrix[rowIndex, currentCol] != '-')
                        {
                            sb.Append(matrix[rowIndex, currentCol]);
                            
                        }
                        matrix[rowIndex, currentCol] = 'P';
                        matrix[rowIndex, colIndex] = '-';
                        colIndex = currentCol;
                    }
                    else
                    {
                        if (sb.Length != 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                    }
                }               
            }

            Console.WriteLine(sb.ToString());
            PrintMatrix(matrix);
            
        }
        private static void FilMatrix(ref int rowIndex, ref int colIndex, char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];
                    if (matrix[row, col] == 'P')
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }
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


        private static bool IsInside(char[,] board, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < board.GetLength(0)
                   && targetCol >= 0 && targetCol < board.GetLength(1);

        }
    }
}

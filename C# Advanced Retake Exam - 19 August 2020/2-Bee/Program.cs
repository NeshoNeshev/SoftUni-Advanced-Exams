using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int startingRow = -1;
            int startingCol = -1;
            int counter = 0;
            bool isWin = false;
            FilMatrix(matrix, ref startingRow, ref startingCol);
            while (true)
            {
                string command = Console.ReadLine();
                if (command=="End")
                {
                    isWin = true;
                    break;
                }
                if (command=="up")
                {
                    matrix[startingRow, startingCol] = '.';
                    startingRow--;
                    if (!IsInside(matrix,startingRow,startingCol))
                    {
                        break;
                    }
                    else
                    {
                        if (Bonus(matrix,startingRow,startingCol))
                        {
                            matrix[startingRow, startingCol] = '.';
                            startingRow--;
                            if (!IsInside(matrix,startingRow,startingCol))
                            {
                                break;
                            }
                            else
                            {
                                if (Counter(matrix,startingRow,startingCol))
                                {
                                    counter++;
                                }
                                matrix[startingRow, startingCol] = 'B';
                            }
                           
                        }
                        if (Counter(matrix, startingRow, startingCol))
                        {
                            counter++;
                        }
                        matrix[startingRow, startingCol] = 'B';
                    }
                }
                if (command == "down")
                {
                    matrix[startingRow, startingCol] = '.';
                    startingRow++;
                    if (!IsInside(matrix, startingRow, startingCol))
                    {
                        break;
                    }
                    else
                    {
                        if (Bonus(matrix, startingRow, startingCol))
                        {
                            matrix[startingRow, startingCol] = '.';
                            startingRow++;
                            if (!IsInside(matrix, startingRow, startingCol))
                            {
                                break;
                            }
                            else
                            {
                                if (Counter(matrix, startingRow, startingCol))
                                {
                                    counter++;
                                }
                                matrix[startingRow, startingCol] = 'B';
                            }

                        }
                        if (Counter(matrix, startingRow, startingCol))
                        {
                            counter++;
                        }
                        matrix[startingRow, startingCol] = 'B';
                    }
                }
                if (command == "left")
                {
                    matrix[startingRow, startingCol] = '.';
                    startingCol--;
                    if (!IsInside(matrix, startingRow, startingCol))
                    {
                        break;
                    }
                    else
                    {
                        if (Bonus(matrix, startingRow, startingCol))
                        {
                            matrix[startingRow, startingCol] = '.';
                            startingCol--;
                            if (!IsInside(matrix, startingRow, startingCol))
                            {
                                break;
                            }
                            else
                            {
                                if (Counter(matrix, startingRow, startingCol))
                                {
                                    counter++;
                                }
                                matrix[startingRow, startingCol] = 'B';
                            }

                        }
                        if (Counter(matrix, startingRow, startingCol))
                        {
                            counter++;
                        }
                        matrix[startingRow, startingCol] = 'B';
                    }
                }
                if (command == "right")
                {
                    matrix[startingRow, startingCol] = '.';
                    startingCol++;
                    if (!IsInside(matrix, startingRow, startingCol))
                    {
                        break;
                    }
                    else
                    {
                        if (Bonus(matrix, startingRow, startingCol))
                        {
                            matrix[startingRow, startingCol] = '.';
                            startingCol++;
                            if (!IsInside(matrix, startingRow, startingCol))
                            {
                                break;
                            }
                            else
                            {
                                if (Counter(matrix, startingRow, startingCol))
                                {
                                    counter++;
                                }
                                matrix[startingRow, startingCol] = 'B';
                            }

                        }
                        if (Counter(matrix, startingRow, startingCol))
                        {
                            counter++;
                        }
                        matrix[startingRow, startingCol] = 'B';
                    }
                }
                
            }
            if (!isWin)
            {
                Console.WriteLine("The bee got lost!");
                if (counter>=5)
                {
                    Console.WriteLine($"Great job, the bee managed to pollinate {counter} flowers!");
                }
                else
                {
                    Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-counter} flowers more");
                }
            }
            else
            {
                if (counter >= 5)
                {
                    Console.WriteLine($"Great job, the bee managed to pollinate {counter} flowers!");
                }
                else
                {
                    Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - counter} flowers more");
                }
            }
            PrintMatrix(matrix);
        }
        public static bool Counter(char[,] matrix, int row, int col)
        {
            
            if (matrix[row,col]=='f')
            {
                return true;
            }
            return false;
        
        }
        public static bool Bonus(char[,] matrix, int row, int col)
        {
            if (matrix[row,col]=='O')
            {
                return true;
            }
            return false;
        
        }
        private static void FilMatrix(char[,] matrix, ref int startingRow, ref int startingCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
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

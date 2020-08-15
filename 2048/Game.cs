using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    class Game
    {
        private const int ROWS = 4;
        private const int COLS = 4;
        public int[,] Field { get; set; } = new int[ROWS, COLS];
        public Moving[] Movings { get; set; } = new Moving[4] {new MoveLeft(), new MoveRight(), new MoveUp(), new MoveDown() };
        public int Score { get; set; } = 0;
        public int NumberMoves { get; set; } = 0;

        public void Start()
        {
            FillRandNumberField fill = new FillRandNumberField();
            Field = fill.Fill(Field);
            Field = fill.Fill(Field);

            ConsoleKeyInfo keyInfo;
            do
            {
                PrintField();
                keyInfo = Console.ReadKey();
                Field = Action(keyInfo);
            } while (keyInfo.Key != ConsoleKey.D0);
        }
        
        private void PrintField()
        {
            Console.Clear();
            Console.WriteLine("Счет: " + Score);

            for(int i = 0; i < Field.GetLength(0); ++i)
            {
                for(int j = 0; j < Field.GetLength(1); ++j)
                {
                    if(Field[i, j] != 0)
                    {
                        Console.Write($"[{Field[i, j],4}] ");
                    }
                    else
                    {
                        Console.Write("[    ] ");
                    }                    
                }
                Console.WriteLine();
            }
            Console.Write("Количество ходов: " + NumberMoves +
                "\n\nДля выхода нажмите 0!\n" + "->");
        }

        private int[,] Action(ConsoleKeyInfo keyInfo)
        {
            int[,] newField = new int[4, 4];
            CopyIntArray.Copy(newField, Field);

            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                CopyIntArray.Copy(newField, Move(newField, 0));
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                CopyIntArray.Copy(newField, Move(newField, 1));
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                CopyIntArray.Copy(newField, Move(newField, 2));
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                CopyIntArray.Copy(newField, Move(newField, 3));
            }

            if (Compare(Field, newField))
            {
                FillRandNumberField fill = new FillRandNumberField();
                newField = fill.Fill(newField);
                NumberMoves++;
            }

            return newField;
        }

        private int[,] Move(int[,] newField, int action)
        {
            int score = Score;
            int[,] move = Movings[action].Move(newField, ref score);
            Score = score;

            return move;
        }

        private bool Compare(int[,] arg_1, int[,] arg_2)
        {
            for(int i = 0; i < 4; ++i)
            {
                for(int j = 0; j < 4; ++j)
                {
                    if(arg_1[i, j] != arg_2[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

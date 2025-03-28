using System.Diagnostics;
using SeventhLabor.Terrains;

namespace SeventhLabor
{
    public class View
    {
        private readonly Model model;

        public View(Model model)
        {
            this.model = model;
        }

        public void Run()
        {
            Console.Clear();
            Console.CursorVisible = false;
            WriteMap();
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                WriteTerrain(model.Entity.Row, model.Entity.Col);
                Act(key);
                WriteEntity();
            } while (key != ConsoleKey.Q);
        }

        private void Act(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Spacebar:
                    model.Transform();
                    break;
                case ConsoleKey.LeftArrow:
                    model.Move(0, -1);
                    break;
                case ConsoleKey.UpArrow:
                    model.Move(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    model.Move(0, 1);
                    break;
                case ConsoleKey.DownArrow:
                    model.Move(1, 0);
                    break;
            }
        }

        private void WriteMap()
        {
            for (int i = 0; i < model.Map.Rows; i++)
            {
                for (int j = 0; j < model.Map.Cols; j++)
                {
                    WriteTerrain(i, j);
                }
                Console.WriteLine();
            }
        }

        private void WriteTerrain(int row, int col)
        {
            char text;
            Console.SetCursorPosition(col, row);
            switch (model.Map[row, col])
            {
                case Field:
                    text = '#';
                    break;
                case Lake:
                    text = '~';
                    break;
                case Mountain:
                    text = '^';
                    break;
                default:
                    throw new Exception();
            }

            Console.Write(text);
        }

        private void WriteEntity()
        {
            Console.SetCursorPosition(model.Entity.Col, model.Entity.Row);
            Console.Write('o');
        }
    }
}


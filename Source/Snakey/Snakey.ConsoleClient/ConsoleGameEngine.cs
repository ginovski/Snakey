namespace Snakey.ConsoleClient
{
    using System;
    using System.Threading;

    using Logic;
    using Logic.GameObjects;

    public class ConsoleGameEngine : GameEngine
    {
        public override void Setup()
        {
            Console.BufferHeight = Console.WindowHeight;
        }

        public override void Run()
        {
            foreach (var element in this.snake.SnakeElements)
            {
                Console.SetCursorPosition(element.Col, element.Row);
                Console.Write(Snake.TailElementSymbol);
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        this.newGame.MoveRight();
                    }
                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        this.newGame.MoveLeft();
                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        this.newGame.MoveUp();
                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        this.newGame.MoveDown();
                    }
                }

                this.newGame.ChangePosition();

                Console.Clear();

                // Draw
                foreach (var element in this.snake.SnakeElements)
                {
                    Console.SetCursorPosition(element.Col, element.Row);
                    Console.Write(Snake.TailElementSymbol);
                }

                Thread.Sleep(Speed);
            }
        }
    }
}

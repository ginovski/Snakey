namespace Snakey.ConsoleClient
{
    using System;

    using Logic;
    using Logic.GameObjects;
    using System.Threading;
    public class ConsoleGameEngine
    {
        private const int Speed = 100;

        private Snake snake;
        private Food food;
        private Game newGame;

        public ConsoleGameEngine()
        {
            this.newGame = new Game(new Snake());
            this.snake = this.newGame.Snake;
            this.food = this.newGame.Food;
        }

        public void Run()
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

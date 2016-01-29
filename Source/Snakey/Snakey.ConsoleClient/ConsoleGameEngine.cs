namespace Snakey.ConsoleClient
{
    using System;
    using System.Threading;

    using Logic;
    using Logic.GameObjects;
    using Common;

    public class ConsoleGameEngine : GameEngine
    {
        private Random randomGenerator = new Random();

        protected override void Setup()
        {
            Console.BufferHeight = Console.WindowHeight;
        }

        protected override Position GetRandomPosition()
        {
            int foodX = this.randomGenerator.Next(0, Console.BufferHeight - 1);
            int foodY = this.randomGenerator.Next(0, Console.BufferWidth - 1);

            var position = new Position(foodX, foodY);

            return position;
        }

        public override void Run()
        {
            // Draw
            foreach (var element in this.snake.SnakeElements)
            {
                Console.SetCursorPosition(element.Col, element.Row);
                Console.Write(Snake.TailElementSymbol);
            }

            Console.SetCursorPosition(this.food.Position.Col, this.food.Position.Row);
            Console.Write(Food.Symbol);

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

                Console.SetCursorPosition(this.food.Position.Col, this.food.Position.Row);
                Console.Write(Food.Symbol);

                Thread.Sleep(Speed);
            }
        }
    }
}

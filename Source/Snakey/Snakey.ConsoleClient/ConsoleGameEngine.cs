namespace Snakey.ConsoleClient
{
    using System;
    using System.Threading;

    using Common;
    using Logic;
    using Logic.GameObjects;

    public class ConsoleGameEngine : GameEngine
    {
        private static Random randomGenerator = new Random();

        private const string EndMessageFormat = "Game Over.Your score is {0} points";

        private ConsoleColor snakeColor;
        private ConsoleColor foodColor;
        private ConsoleColor gameOverColor;

        protected override void Setup()
        {
            Console.BufferHeight = Console.WindowHeight;
            this.snakeColor = ConsoleColor.Cyan;
            this.foodColor = ConsoleColor.Yellow;
            this.gameOverColor = ConsoleColor.Red;
        }

        protected override Position GetRandomPosition()
        {
            int foodX = randomGenerator.Next(0, Console.BufferHeight - 1);
            int foodY = randomGenerator.Next(0, Console.BufferWidth - 1);

            var position = new Position(foodX, foodY);

            return position;
        }

        public override void Run()
        {
            this.Draw();

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

                var newHeadPosition = this.newGame.NewHeadPosition();

                if (newHeadPosition.Row < 0 || newHeadPosition.Row >= Console.BufferHeight ||
                    newHeadPosition.Col < 0 || newHeadPosition.Col >= Console.BufferWidth ||
                    this.snake.SnakeElements.Contains(newHeadPosition))
                {
                    this.End();
                    break;
                }
                
                this.newGame.ChangePosition();

                if (this.snake.Head.Row == this.food.Position.Row &&
                    this.snake.Head.Col == this.food.Position.Col)
                {
                    this.newGame.Points++;
                    this.speed -= 1;

                    var newFoodPosition = this.GetRandomPosition();
                    this.newGame.GenerateNewFood(newFoodPosition);
                    this.newGame.EnlargeSnake();

                    this.food = this.newGame.Food;
                }

                Console.Clear();
                this.Draw();

                Thread.Sleep(this.speed);
            }
        }

        public override void End()
        {
            Console.Clear();
            Console.ForegroundColor = this.gameOverColor;
            Console.SetCursorPosition(Console.BufferWidth / 2 - EndMessageFormat.Length / 2, Console.BufferHeight / 2);
            Console.Write(EndMessageFormat, this.newGame.Points);
            Console.ReadKey();
        }

        public override void Draw()
        {
            Console.ForegroundColor = this.snakeColor;
            foreach (var element in this.snake.SnakeElements)
            {
                Console.SetCursorPosition(element.Col, element.Row);
                Console.Write(Snake.TailElementSymbol);
            }

            Console.ForegroundColor = this.foodColor;
            Console.SetCursorPosition(this.food.Position.Col, this.food.Position.Row);
            Console.Write(Food.Symbol);
        }
    }
}

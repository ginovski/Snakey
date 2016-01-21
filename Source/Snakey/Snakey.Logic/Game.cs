namespace Snakey.Logic
{
    using System;

    using Common;
    using Snakey.Logic.GameObjects;

    public class Game
    {
        private static Random randomGenerator = new Random();

        private Food food;
        private Snake snake;

        public Game(Snake snake, Food food)
        {
            this.snake = snake;
            this.food = food;
        }

        public void MoveRight()
        {
            this.snake.Position.X++;
        }

        public void MoveLeft()
        {
            this.snake.Position.X--;
        }

        public void MoveDown()
        {
            this.snake.Position.Y--;
        }

        public void MoveUp()
        {
            this.snake.Position.Y++;
        }

        public void GenerateNewFood()
        {
            int foodX = randomGenerator.Next(0, Console.BufferWidth - 1);
            int foodY = randomGenerator.Next(0, Console.BufferHeight - 1);

            var position = new Position(foodX, foodY);
            var food = new Food(position);

            this.food = food;
        }

        public void Draw()
        {
            // TODO: Implement
        }
    }
}

namespace Snakey.Logic
{
    using System;

    using Common;
    using Snakey.Logic.GameObjects;

    public class Game
    {
        private static Random randomGenerator = new Random();
        
        private Position[] directions;
        private Directions direction;
        
        public Game(Snake snake)
        {
            this.Snake = snake;
            this.GenerateNewFood();
            this.direction = Directions.Right;
            this.directions = new Position[]
            {
                new Position(0, 1), // right
                new Position(0, -1), // left
                new Position(1, 0), // down
                new Position(-1, 0), // up
            };
        }
        
        public Food Food { get; set; }

        public Snake Snake { get; set; }

        public void MoveRight()
        {
            direction = Directions.Right;
        }

        public void MoveLeft()
        {
            direction = Directions.Left;
        }

        public void MoveDown()
        {
            direction = Directions.Down;
        }

        public void MoveUp()
        {
            direction = Directions.Up;
        }

        public void ChangePosition()
        {
            this.Snake.Dequeue();

            var headPosition = this.Snake.Head;
            var newDirection = directions[(int)direction];

            var newPosition = new Position(headPosition.Row + newDirection.Row, headPosition.Col + newDirection.Col);

            this.Snake.Enqueue(newPosition);
        }

        public void GenerateNewFood()
        {
            int foodX = randomGenerator.Next(0, Console.BufferWidth - 1);
            int foodY = randomGenerator.Next(0, Console.BufferHeight - 1);

            var position = new Position(foodX, foodY);
            var food = new Food(position);

            this.Food = food;
        }
    }
}

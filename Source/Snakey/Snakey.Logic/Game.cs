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
        
        public Game(Snake snake, Food food)
        {
            this.Snake = snake;
            this.Food = food;
            this.direction = Directions.Right;
            this.directions = new Position[]
            {
                new Position(0, 1), // right
                new Position(0, -1), // left
                new Position(1, 0), // down
                new Position(-1, 0), // up
            };
        }
        
        public Food Food { get; private set; }

        public Snake Snake { get; private set;}

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

        public void GenerateNewFood(Position position)
        {
            var food = new Food(position);
            this.Food = food;
        }
    }
}

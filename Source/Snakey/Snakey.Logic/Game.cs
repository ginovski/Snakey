namespace Snakey.Logic
{
    using System;

    using Common;
    using Snakey.Logic.GameObjects;

    public class Game
    {
        private static Random randomGenerator = new Random();

        private Position[] directions;
        private Direction direction;

        public Game(Snake snake, Food food)
        {
            this.Snake = snake;
            this.Food = food;
            this.Points = 0;
            this.direction = Direction.Right;
            this.directions = new Position[]
            {
                new Position(0, 1), // right
                new Position(0, -1), // left
                new Position(1, 0), // down
                new Position(-1, 0), // up
            };
        }

        public Food Food { get; private set; }

        public Snake Snake { get; private set; }

        public int Points { get; set; }

        public void MoveRight()
        {
            if (direction != Direction.Left)
            {
                direction = Direction.Right;
            }
        }

        public void MoveLeft()
        {
            if (direction != Direction.Right)
            {
                direction = Direction.Left;
            }
        }

        public void MoveDown()
        {
            if (direction != Direction.Up)
            {
                direction = Direction.Down;
            }
        }

        public void MoveUp()
        {
            if (direction != Direction.Down)
            {
                direction = Direction.Up;
            }
        }

        public Position NewHeadPosition()
        {
            var headPosition = this.Snake.Head;
            var newDirection = directions[(int)direction];

            var newPosition = new Position(headPosition.Row + newDirection.Row, headPosition.Col + newDirection.Col);

            return newPosition;
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

        public void EnlargeSnake()
        {
            var headPosition = this.Snake.Head;
            var newDirection = directions[(int)direction];

            var newPosition = new Position(headPosition.Row + newDirection.Row, headPosition.Col + newDirection.Col);

            this.Snake.Enqueue(newPosition);
        }
    }
}

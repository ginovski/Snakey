namespace Snakey.Logic.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Snakey.Common;

    public class Snake
    {
        private const int InitialTailLength = 5;
        public const char HeadSymbol = '@';
        public const char TailElementSymbol = '*';

        private int tailLength;
        private Queue<Position> snakeElements;

        public Snake()
            : this(InitialTailLength)
        {
        }

        public Snake(int tailLength)
        {
            this.TailLength = tailLength;
            this.snakeElements = new Queue<Position>();
            for (int i = 0; i < this.TailLength; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }
        }

        public int TailLength
        {
            get
            {
                return this.tailLength;
            }
            private set
            {
                if (value <= 1)
                {
                    throw new ArgumentOutOfRangeException("Tail length must be 2 and above");
                }

                this.tailLength = value;
            }
        }

        public Queue<Position> SnakeElements
        {
            get
            {
                return new Queue<Position>(this.snakeElements);
            }
        }

        public Position Head
        {
            get
            {
                return this.snakeElements.Last();
            }
        }

        public Position Dequeue()
        {
            return this.snakeElements.Dequeue();
        }

        public void Enqueue(Position position)
        {
            this.snakeElements.Enqueue(position);
        }
    }
}

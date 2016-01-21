namespace Snakey.Logic.GameObjects
{
    using System;

    using Snakey.Common;

    public class Snake
    {
        private const char HeadSymbol = '@';
        private const char TailElementSymbol = '*';
        private const int InitialTailLength = 5;

        private int tailLength;

        public Snake(Position position, int tailLength)
            : this(position)
        {
            this.TailLength = tailLength;
        }

        public Snake(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; set; }

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

        public void AddTailElement()
        {
            this.TailLength++;
        }
    }
}

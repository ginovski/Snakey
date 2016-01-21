namespace Snakey.Common
{
    using System;

    public class Position
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("X cannot be less than zero.");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Y cannot be less than zero.");
                }

                this.y = value;
            }
        }
    }
}
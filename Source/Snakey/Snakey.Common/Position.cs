namespace Snakey.Common
{
    public class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override bool Equals(object obj)
        {
            Position other = obj as Position;
            if (other != null)
            {
                return this.Col == other.Col && this.Row == other.Row;
            }

            return false;
        }
    }
}
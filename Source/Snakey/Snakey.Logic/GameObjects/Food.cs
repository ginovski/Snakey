namespace Snakey.Logic.GameObjects
{
    using Common;

    public class Food
    {
        private const char SYMBOL = 'O';
        
        public Food(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; set; }
    }
}

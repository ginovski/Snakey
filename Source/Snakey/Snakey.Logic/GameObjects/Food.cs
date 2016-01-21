namespace Snakey.Logic.GameObjects
{
    using Common;

    public class Food
    {
        private const char Symbol = 'O';
        
        public Food(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; set; }
    }
}

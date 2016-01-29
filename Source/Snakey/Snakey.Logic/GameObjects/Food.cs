namespace Snakey.Logic.GameObjects
{
    using Common;

    public class Food
    {
        public const char Symbol = '$';
        
        public Food(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; set; }
    }
}

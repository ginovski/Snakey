namespace Snakey.Logic
{
    using Snakey.Logic.GameObjects;

    public abstract class GameEngine
    {
        protected const int Speed = 100;

        protected Snake snake;
        protected Food food;
        protected Game newGame;

        public GameEngine()
        {
            this.newGame = new Game(new Snake());
            this.snake = this.newGame.Snake;
            this.food = this.newGame.Food;

            this.Setup();
        }

        public abstract void Setup();

        public abstract void Run();
    }
}

namespace Snakey.Logic
{
    using System;
    using Common;
    using Snakey.Logic.GameObjects;

    public abstract class GameEngine
    {
        protected const int Speed = 100;

        protected Snake snake;
        protected Food food;
        protected Game newGame;

        public GameEngine()
        {
            this.Setup();

            this.newGame = new Game(new Snake(), new Food(this.GetRandomPosition()));
            this.snake = this.newGame.Snake;
            this.food = this.newGame.Food;
        }

        protected abstract Position GetRandomPosition();

        protected abstract void Setup();

        public abstract void Run();
    }
}

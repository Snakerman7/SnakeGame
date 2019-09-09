using NConsoleGraphics;

namespace SnakeGame
{
    public abstract class GameObject : IGameObject
    {
        public Point Position { get; set; }

        public abstract void Render(ConsoleGraphics graphics);

        public abstract void Update(GameEngine engine);
    }
}

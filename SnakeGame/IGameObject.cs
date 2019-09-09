using NConsoleGraphics;

namespace SnakeGame
{
    public interface IGameObject
    {
        void Render(ConsoleGraphics graphics);

        void Update(GameEngine engine);
    }
}
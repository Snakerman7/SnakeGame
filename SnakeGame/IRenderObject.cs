using NConsoleGraphics;

namespace SnakeGame
{
    public interface IRenderObject
    {
        void Render(ConsoleGraphics graphics);

        void Update(GameEngine engine);
    }
}
using NConsoleGraphics;

namespace SnakeGame.Engine
{
    public interface IRenderObject
    {
        void Render(ConsoleGraphics graphics);

        void Update(GameEngine engine);
    }
}
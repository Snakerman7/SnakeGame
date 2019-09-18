using NConsoleGraphics;

namespace SnakeGame
{
    public static class ResourcesManager
    {
        public static ConsoleImage SnakeImage { get; private set; }
        public static ConsoleImage TreeImage { get; private set; }

        public static void LoadResources(ConsoleGraphics graphics)
        {
            SnakeImage = graphics.LoadImage("images/snake.png");
            TreeImage = graphics.LoadImage("images/tree.png");
        }
    }
}

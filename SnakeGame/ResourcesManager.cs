using NConsoleGraphics;

namespace SnakeGame
{
    public class ResourcesManager
    {
        private static ResourcesManager _instance;
        public static ResourcesManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ResourcesManager();
            }
            return _instance;
        }

        public ConsoleImage SnakeImage { get; private set; }
        public ConsoleImage StoneImage { get; private set; }
        private ResourcesManager()
        {

        }

        public void LoadResources(ConsoleGraphics graphics)
        {
            SnakeImage = graphics.LoadImage("images/snake.png");
            StoneImage = graphics.LoadImage("images/stone.png");
        }
    }
}

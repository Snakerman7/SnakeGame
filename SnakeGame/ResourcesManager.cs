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

        private ConsoleImage _snakeGameImage;
        public ConsoleImage SnakeImage
        {
            get
            {
                return _snakeGameImage;
            }
        }
        private ResourcesManager()
        {

        }

        public void LoadResources(ConsoleGraphics graphics)
        {
            if (_snakeGameImage == null)
                _snakeGameImage = graphics.LoadImage("images/snake.png");
        }
    }
}

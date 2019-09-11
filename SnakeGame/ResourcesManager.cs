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

        private ConsoleImage _snakeImage;
        private ConsoleImage _stoneImage;
        public ConsoleImage SnakeImage
        {
            get
            {
                return _snakeImage;
            }
        }
        public ConsoleImage StoneImage
        {
            get
            {
                return _stoneImage;
            }
        }
        private ResourcesManager()
        {

        }

        public void LoadResources(ConsoleGraphics graphics)
        {
            _snakeImage = graphics.LoadImage("images/snake.png");
            _stoneImage = graphics.LoadImage("images/stone.png");
        }
    }
}

using NConsoleGraphics;
using SnakeGame.Engine;

namespace SnakeGame.Scenes
{
    public abstract class Scene : IRenderObject
    {
        protected bool _isActive = false;

        public void Start()
        {
            _isActive = true;
        }

        public void Stop()
        {
            _isActive = false;
        }

        public abstract void Render(ConsoleGraphics graphics);

        public abstract void Update(GameEngine engine);
    }
}

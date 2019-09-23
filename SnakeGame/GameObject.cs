using NConsoleGraphics;
using SnakeGame.Engine;
using SnakeGame.Common;

namespace SnakeGame.Objects
{
    public abstract class GameObject : IRenderObject
    {
        protected ConsoleImage _image;
        public Point Position { get; set; }

        public abstract void Render(ConsoleGraphics graphics);

        public abstract void Update(GameEngine engine);
    }
}

using NConsoleGraphics;
using SnakeGame.Engine;
using SnakeGame.Utils;

namespace SnakeGame.Objects
{
    public class Tree : GameObject
    {
        public Tree()
        {
            _image = ResourcesManager.ImageResources.TreeImage;
        }
        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImagePart(_image, 0, 0, 16, 16, Position.X, Position.Y);
        }

        public override void Update(GameEngine engine)
        {

        }
    }
}

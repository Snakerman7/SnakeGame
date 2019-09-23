using NConsoleGraphics;
using SnakeGame.Engine;
using SnakeGame.Utils;

namespace SnakeGame.Objects
{
    public class Food : GameObject
    {
        public Food()
        {
            _image = ResourcesManager.ImageResources.SnakeImage;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImagePart(_image, 32, 48, 16, 16, Position.X, Position.Y);
        }

        public override void Update(GameEngine engine)
        {

        }
    }
}

using NConsoleGraphics;

namespace SnakeGame
{
    public class Tree : GameObject
    {
        public Tree()
        {
            _image = ResourcesManager.TreeImage;
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

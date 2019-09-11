using NConsoleGraphics;

namespace SnakeGame
{
    public class Stone : GameObject
    {
        public Stone()
        {
            _image = ResourcesManager.GetInstance().StoneImage;
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

using NConsoleGraphics;

namespace SnakeGame
{
    public class Food : GameObject
    {
        public Food()
        {
            _image = ResourcesManager.GetInstance().SnakeImage;
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

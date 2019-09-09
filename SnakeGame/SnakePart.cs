using NConsoleGraphics;

namespace SnakeGame
{
    public enum MoveDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    public enum SnakePartType
    {
        Head,
        Body,
        BodyLeftUpOrDownRight,
        BodyLeftDownOrUpRight,
        BodyRightUpOrDownLeft,
        BodyRightDownOrUpLeft,
        Tail
    }

    public class SnakePart : GameObject
    {
        private int _size;
        private ConsoleImage _image;
        public MoveDirection Direction { get; set; }
        public SnakePartType Type { get; set; }

        public SnakePart(Point position = new Point(), MoveDirection dir = MoveDirection.Right, SnakePartType type = SnakePartType.Body, int size = 0)
        {
            _size = size;
            Position = position;
            Direction = dir;
            Type = type;
            _image = ResourcesManager.GetInstance().SnakeImage;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            switch (Type)
            {
                case SnakePartType.Tail:
                    if (Direction == MoveDirection.Down)
                    {
                        graphics.DrawImagePart(_image, 32, 16, _size, _size, Position.X, Position.Y);
                    }
                    else if (Direction == MoveDirection.Up)
                    {
                        graphics.DrawImagePart(_image, 0, 16, _size, _size, Position.X, Position.Y);
                    }
                    else if (Direction == MoveDirection.Right)
                    {
                        graphics.DrawImagePart(_image, 16, 16, _size, _size, Position.X, Position.Y);
                    }
                    else
                    {
                        graphics.DrawImagePart(_image, 48, 16, _size, _size, Position.X, Position.Y);
                    }
                    break;
                case SnakePartType.Body:
                    if (Direction == MoveDirection.Down || Direction == MoveDirection.Up)
                    {
                        graphics.DrawImagePart(_image, 0, 48, _size, _size, Position.X, Position.Y);
                    }
                    else
                    {
                        graphics.DrawImagePart(_image, 16, 48, _size, _size, Position.X, Position.Y);
                    }
                    break;
                case SnakePartType.BodyLeftDownOrUpRight:
                    graphics.DrawImagePart(_image, 16, 32, _size, _size, Position.X, Position.Y);
                    break;
                case SnakePartType.BodyLeftUpOrDownRight:
                    graphics.DrawImagePart(_image, 0, 32, _size, _size, Position.X, Position.Y);
                    break;
                case SnakePartType.BodyRightDownOrUpLeft:
                    graphics.DrawImagePart(_image, 32, 32, _size, _size, Position.X, Position.Y);
                    break;
                case SnakePartType.BodyRightUpOrDownLeft:
                    graphics.DrawImagePart(_image, 48, 32, _size, _size, Position.X, Position.Y);
                    break;
                case SnakePartType.Head:
                    if (Direction == MoveDirection.Down)
                    {
                        graphics.DrawImagePart(_image, 32, 0, _size, _size, Position.X, Position.Y);
                    }
                    else if (Direction == MoveDirection.Up)
                    {
                        graphics.DrawImagePart(_image, 0, 0, _size, _size, Position.X, Position.Y);
                    }
                    else if (Direction == MoveDirection.Right)
                    {
                        graphics.DrawImagePart(_image, 16, 0, _size, _size, Position.X, Position.Y);
                    }
                    else
                    {
                        graphics.DrawImagePart(_image, 48, 0, _size, _size, Position.X, Position.Y);
                    }
                    break;
            }
        }

        public override void Update(GameEngine engine)
        {

        }
    }
}

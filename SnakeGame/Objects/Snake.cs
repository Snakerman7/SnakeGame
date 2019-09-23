using GenericCollections;
using NConsoleGraphics;
using SnakeGame.Engine;
using SnakeGame.Common;

namespace SnakeGame.Objects
{
    public class Snake : GameObject
    {
        private readonly LinkedList<SnakePart> _parts;
        private MoveDirection _direction;
        private readonly int _partSize;
        public bool ItselfCollision { get; private set; }

        public Snake()
        {
            _partSize = 16;
            ItselfCollision = false;
            _direction = MoveDirection.Right;
            _parts = new LinkedList<SnakePart>();
            _parts.AddFirst(new SnakePart(type: SnakePartType.Tail, position: new Point(0, 0), dir: MoveDirection.Right));
            _parts.AddFirst(new SnakePart(type: SnakePartType.Body, position: new Point(16, 0), dir: MoveDirection.Right));
            _parts.AddFirst(new SnakePart(type: SnakePartType.Head, position: new Point(32, 0), dir: MoveDirection.Right));
        }

        public void AddPart()
        {
            var tailDirection = _parts.Last.Value.Direction;
            int x = _parts.Last.Value.Position.X;
            int y = _parts.Last.Value.Position.Y;
            SnakePart part;
            switch (tailDirection)
            {
                case MoveDirection.Up:
                    y += _partSize;
                    part = new SnakePart(new Point(x, y), MoveDirection.Up, SnakePartType.Tail);
                    break;
                case MoveDirection.Down:
                    y -= _partSize;
                    part = new SnakePart(new Point(x, y), MoveDirection.Down, SnakePartType.Tail);
                    break;
                case MoveDirection.Right:
                    x -= _partSize;
                    part = new SnakePart(new Point(x, y), MoveDirection.Right, SnakePartType.Tail);
                    break;
                default:
                    x += _partSize;
                    part = new SnakePart(new Point(x, y), MoveDirection.Left, SnakePartType.Tail);
                    break;
            }
            _parts.Last.Value.Type = SnakePartType.Body;
            _parts.Add(part);
        }

        public bool CheckCollision(Point p)
        {
            var bodyPart = _parts.First;
            while (bodyPart != null)
            {
                if (bodyPart.Value.Position.Equals(p))
                {
                    return true;
                }
                bodyPart = bodyPart.Next;
            }
            return false;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            var snake = _parts.ToArray();
            foreach (var part in snake)
            {
                part.Render(graphics);
            }
        }

        public override void Update(GameEngine engine)
        {
            MoveDirection prevMove = _direction;
            if (Input.IsKeyDown(Keys.DOWN) && _direction != MoveDirection.Up)
            {
                _direction = MoveDirection.Down;
            }
            else if (Input.IsKeyDown(Keys.UP) && _direction != MoveDirection.Down)
            {
                _direction = MoveDirection.Up;
            }
            else if (Input.IsKeyDown(Keys.LEFT) && _direction != MoveDirection.Right)
            {
                _direction = MoveDirection.Left;
            }
            else if (Input.IsKeyDown(Keys.RIGHT) && _direction != MoveDirection.Left)
            {
                _direction = MoveDirection.Right;
            }
            var tail = _parts.Last.Value;
            _parts.RemoveLast();
            _parts.Last.Value.Type = SnakePartType.Tail;
            _parts.First.Value.Type = SnakePartType.Body;
            tail.Type = SnakePartType.Head;
            _parts.First.Value.Direction = _direction;
            tail.Direction = _direction;
            int dx = 0, dy = 0;
            switch (_direction)
            {
                case MoveDirection.Up:
                    dy = -_partSize;
                    if (prevMove == MoveDirection.Left)
                    {
                        _parts.First.Value.Type = SnakePartType.BodyLeftUpOrDownRight;
                    }
                    else if (prevMove == MoveDirection.Right)
                    {
                        _parts.First.Value.Type = SnakePartType.BodyRightUpOrDownLeft;
                    }
                    break;
                case MoveDirection.Down:
                    dy = _partSize;
                    if (prevMove == MoveDirection.Left)
                    {
                        _parts.First.Value.Type = SnakePartType.BodyLeftDownOrUpRight;
                    }
                    else if (prevMove == MoveDirection.Right)
                    {
                        _parts.First.Value.Type = SnakePartType.BodyRightDownOrUpLeft;
                    }
                    break;
                case MoveDirection.Right:
                    dx = _partSize;
                    if (prevMove == MoveDirection.Up)
                    {
                        _parts.First.Value.Type = SnakePartType.BodyLeftDownOrUpRight;
                    }
                    else if (prevMove == MoveDirection.Down)
                    {
                        _parts.First.Value.Type = SnakePartType.BodyLeftUpOrDownRight;
                    }
                    break;
                case MoveDirection.Left:
                    dx = -_partSize;
                    if (prevMove == MoveDirection.Up)
                    {
                        _parts.First.Value.Direction = _direction;
                        _parts.First.Value.Type = SnakePartType.BodyRightDownOrUpLeft;
                    }
                    else if (prevMove == MoveDirection.Down)
                    {
                        _parts.First.Value.Direction = _direction;
                        _parts.First.Value.Type = SnakePartType.BodyRightUpOrDownLeft;
                    }
                    break;
            }
            var p = _parts.First.Value.Position;
            tail.Position = new Point(p.X + dx, p.Y + dy);
            Position = tail.Position;
            ItselfCollision = CheckCollision(Position);
            _parts.AddFirst(tail);
        }
    }
}

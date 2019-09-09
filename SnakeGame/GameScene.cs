using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace SnakeGame
{
    public class GameScene : Scene
    {
        private int _gameFieldWidth;
        private int _gameFieldHeight;
        private Snake _player;
        private List<IGameObject> _objects = new List<IGameObject>();

        public GameScene(int width, int height)
        {
            _player = new Snake();
            _gameFieldWidth = width;
            _gameFieldHeight = height;
        }

        public virtual void AddObject(IGameObject obj)
        {
            _objects.Add(obj);
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xff155c12, 0, 0, _gameFieldWidth, _gameFieldHeight);
            foreach (var obj in _objects)
            {
                obj.Render(graphics);
            }
            _player.Render(graphics);
        }

        public override void Update(GameEngine engine)
        {
            if (_isActive)
            {
                foreach (var obj in _objects)
                {
                    obj.Update(engine);
                }
                _player.Update(engine);
            }
            if (CheckCollisionWithObjects() || CheckCollisionWithBorders())
            {
                engine.PrevScene();
            }
        }

        private bool CheckCollisionWithBorders()
        {
            var point = _player.HeadPosition;
            if(point.X < 0 || point.X > _gameFieldWidth)
            {
                return true;
            }
            if(point.Y < 0 || point.Y > _gameFieldHeight)
            {
                return true;
            }
            return false;
        }

        private bool CheckCollisionWithObjects()
        {
            var point = _player.HeadPosition;
            foreach(var obj in _objects)
            {
                if(obj is Food f){
                    if (f.Position.Equals(point))
                    {
                        Random r = new Random();
                        Point p;
                        do {
                            int x = r.Next(_gameFieldWidth);
                            x = x - x % 16;
                            int y = r.Next(_gameFieldHeight);
                            y = y - y % 16;
                            p = new Point(x, y);
                        } while (_player.CheckCollision(p));
                        f.Position = p;
                        _player.AddPart();
                    }
                }
            }
            return false;
        }
    }
}

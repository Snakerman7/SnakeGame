using NConsoleGraphics;
using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public class MainScene : Scene
    {
        private int _gameFieldWidth;
        private int _gameFieldHeight;
        private bool _isInitialize = false;
        private Snake _player;
        private GUI _gui;
        private List<GameObject> _objects = new List<GameObject>();

        public MainScene()
        {
            _player = new Snake();
            _gui = new GUI();
        }

        public virtual void AddObject(GameObject obj)
        {
            _objects.Add(obj);
        }

        public override void Render(ConsoleGraphics graphics)
        {
            if (!_isInitialize)
            {
                _gameFieldHeight = graphics.ClientHeight - (graphics.ClientHeight % 16) - 35;
                _gameFieldWidth = graphics.ClientWidth - graphics.ClientWidth % 16;
                _gui.Position = new Point(0, _gameFieldHeight);
            }
            graphics.FillRectangle(0xff155c12, 0, 0, _gameFieldWidth, _gameFieldHeight);
            foreach (var obj in _objects)
            {
                obj.Render(graphics);
            }
            _player.Render(graphics);
            _gui.Render(graphics);
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
            var point = _player.Position;
            if (point.X < 0 || point.X >= _gameFieldWidth)
            {
                return true;
            }
            if (point.Y < 0 || point.Y >= _gameFieldHeight)
            {
                return true;
            }
            return false;
        }

        private bool CheckSpaceForNewFood(Point p)
        {
            foreach (var obj in _objects)
            {
                if (obj.Position.Equals(p))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckCollisionWithObjects()
        {
            var point = _player.Position;
            foreach (var obj in _objects)
            {
                if (obj is Food f)
                {
                    if (f.Position.Equals(point))
                    {
                        Random r = new Random();
                        Point p;
                        do
                        {
                            int x = r.Next(_gameFieldWidth);
                            x = x - x % 16;
                            int y = r.Next(_gameFieldHeight);
                            y = y - y % 16;
                            p = new Point(x, y);
                        } while (_player.CheckCollision(p) && CheckSpaceForNewFood(p));
                        f.Position = p;
                        _player.AddPart();
                        _gui.Scores++;
                    }
                }
            }
            return false;
        }

    }
}

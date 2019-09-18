using NConsoleGraphics;
using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public class MainScene : Scene
    {
        private const int SCORES_FOR_WIN = 500;
        private readonly int _gameFieldWidth;
        private readonly int _gameFieldHeight;
        private readonly Snake _player;
        private readonly GUI _gui;
        private readonly List<GameObject> _objects = new List<GameObject>();
        private readonly Random _numberGenerator = new Random();

        public MainScene(int width, int heigth)
        {
            _player = new Snake();
            _gameFieldHeight = heigth - (heigth % 16) - 32;
            _gameFieldWidth = width - width % 16;
            _gui = new GUI(new Point(0, _gameFieldHeight));
        }

        public virtual void AddObject(GameObject obj)
        {
            _objects.Add(obj);
        }

        public void AddObjectToRandomPosition(GameObject obj)
        {
            obj.Position = GetFreePoint();
            AddObject(obj);
        }

        public override void Render(ConsoleGraphics graphics)
        {
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
            if (_player.ItselfCollision || CheckCollisionWithObjects() || CheckCollisionWithBorders())
            {
                EndGameScene scene = new EndGameScene("You lose", _gui.Scores);
                engine.ChangeScene(scene);
            }
            if (_gui.Scores == SCORES_FOR_WIN)
            {
                EndGameScene scene = new EndGameScene("You win", _gui.Scores);
                engine.ChangeScene(scene);
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

        private bool CheckPoint(Point p)
        {
            foreach (var obj in _objects)
            {
                if (obj.Position.Equals(p))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckCollisionWithObjects()
        {
            var point = _player.Position;
            foreach (var obj in _objects)
            {
                switch (obj)
                {
                    case Food f:
                        if (f.Position.Equals(point))
                        {
                            Point p = GetFreePoint();
                            f.Position = p;
                            _player.AddPart();
                            _gui.Scores++;
                        }
                        break;
                    case Tree s:
                        if (s.Position.Equals(point))
                            return true;
                        break;
                }
            }
            return false;
        }

        private Point GetFreePoint()
        {
            Point p;
            do
            {
                int x = _numberGenerator.Next(_gameFieldWidth);
                x -= x % 16;
                int y = _numberGenerator.Next(_gameFieldHeight);
                y -= y % 16;
                p = new Point(x, y);
            } while (_player.CheckCollision(p) || CheckPoint(p));
            return p;
        }
    }
}

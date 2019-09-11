﻿using NConsoleGraphics;
using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public class MainScene : Scene
    {
        private int _gameFieldWidth;
        private int _gameFieldHeight;
        private Snake _player;
        private GUI _gui;
        private List<GameObject> _objects = new List<GameObject>();
        private Random _numberGenerator = new Random();

        public MainScene(int width, int heigth)
        {
            _player = new Snake();
            _gui = new GUI();
            _gameFieldHeight = heigth - (heigth % 16) - 35;
            _gameFieldWidth = width - width % 16;
            _gui.Position = new Point(0, _gameFieldHeight);
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

        private bool CheckPoint(Point p)
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
                    case Stone s:
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
                x = x - x % 16;
                int y = _numberGenerator.Next(_gameFieldHeight);
                y = y - y % 16;
                p = new Point(x, y);
            } while (_player.CheckCollision(p) && CheckPoint(p));
            return p;
        }
    }
}
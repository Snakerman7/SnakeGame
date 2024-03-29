﻿using NConsoleGraphics;
using System;
using System.Collections.Generic;
using SnakeGame.Objects;
using SnakeGame.Engine;
using SnakeGame.Common;
using SnakeGame.Utils;

namespace SnakeGame.Scenes
{
    public class MainScene : Scene
    {
        private const int SCORES_FOR_WIN = 500;
        private readonly Size _gameFieldSize;
        private readonly Snake _player;
        private readonly GUI _gui;
        private readonly List<GameObject> _objects = new List<GameObject>();
        private readonly Random _numberGenerator = new Random();

        public MainScene(int width, int heigth)
        {
            _player = new Snake();
            _gameFieldSize = new Size(heigth - (heigth % 16) - 32, width - width % 16);
            _gui = new GUI(new Point(0, _gameFieldSize.Height));
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
            graphics.FillRectangle(ResourcesManager.ColorResources.MainSceneBackgroundColor, 0, 0, _gameFieldSize.Width, _gameFieldSize.Height);
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
                EndGameScene scene = new EndGameScene(ResourcesManager.StringResources.LoseText, _gui.Scores);
                engine.ChangeScene(scene);
            }
            if (_gui.Scores == SCORES_FOR_WIN)
            {
                EndGameScene scene = new EndGameScene(ResourcesManager.StringResources.WinText, _gui.Scores);
                engine.ChangeScene(scene);
            }
        }

        private bool CheckCollisionWithBorders()
        {
            var point = _player.Position;
            if (point.X < 0 || point.X >= _gameFieldSize.Width)
            {
                return true;
            }
            if (point.Y < 0 || point.Y >= _gameFieldSize.Height)
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
                int x = _numberGenerator.Next(_gameFieldSize.Width);
                x -= x % 16;
                int y = _numberGenerator.Next(_gameFieldSize.Height);
                y -= y % 16;
                p = new Point(x, y);
            } while (_player.CheckCollision(p) || CheckPoint(p));
            return p;
        }
    }
}

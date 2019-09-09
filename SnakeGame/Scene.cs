﻿using NConsoleGraphics;

namespace SnakeGame
{
    public abstract class Scene : IGameObject
    {
        protected bool _isActive = false;

        public void Start()
        {
            _isActive = true;
        }

        public void Stop()
        {
            _isActive = false;
        }

        public abstract void Render(ConsoleGraphics graphics);

        public abstract void Update(GameEngine engine);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace SnakeGame
{
    enum MenuItemType
    {
        StartNewGame,
        Quit
    }

    class MainMenuScene : Scene
    {
        private int _width;
        private int _height;

        public MainMenuScene(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawString($"New Game", "Arial", 0xff000000, 100, 100);
        }

        public override void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.RETURN))
            {
                GameScene scene = new GameScene(_width, _height);
                scene.AddObject(new Food() { Position = new Point(160, 160) });
                engine.NextScene(scene);
            }
        }
    }
}

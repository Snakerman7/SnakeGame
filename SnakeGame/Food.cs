using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace SnakeGame
{
    public class Food : IGameObject
    {
        public Point Position { get; set; }
        private ConsoleImage _image;

        public void Render(ConsoleGraphics graphics)
        {
            if(_image == null)
            {
                _image = graphics.LoadImage("images/snake.png");
            }
            graphics.DrawImagePart(_image, 32, 48, 16, 16, Position.X, Position.Y);
        }

        public void Update(GameEngine engine)
        {
            
        }
    }
}

using NConsoleGraphics;
using System;
using System.Drawing.Text;

namespace SnakeGame
{
    class MenuItem : IRenderObject
    {
        private readonly string _text;
        public bool IsSelected { get; set; }
        public MenuItemType Type { get; }
        public Point Position { get; set; }

        public MenuItem(MenuItemType type, string text)
        {
            Type = type;
            _text = text;
        }

        public void Render(ConsoleGraphics graphics)
        {
            if (IsSelected)
            {
                graphics.DrawString(_text, "Broadway", 0xff000000, Position.X, Position.Y, 18);
            }
            else
            {
                graphics.DrawString(_text, "Broadway", 0xffaaaaaa, Position.X, Position.Y);
            }
        }

        public void Update(GameEngine engine)
        {
            
        }
    }
}

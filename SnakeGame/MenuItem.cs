using NConsoleGraphics;
using System;
using System.Drawing.Text;

namespace SnakeGame
{
    class MenuItem : GameObject
    {
        private MenuItemType _type;
        private string _text;
        public bool IsSelected { get; set; }

        public MenuItemType Type
        {
            get => _type;
        }

        public MenuItem(MenuItemType type, string text)
        {
            _type = type;
            _text = text;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            if (IsSelected)
            {
                graphics.DrawString(_text, "Broadway", 0xff000000, Position.X, Position.Y);
            }
            else
            {
                graphics.DrawString(_text, "Broadway", 0xffaaaaaa, Position.X, Position.Y);
            }
        }

        public override void Update(GameEngine engine)
        {
            throw new NotImplementedException();
        }
    }
}

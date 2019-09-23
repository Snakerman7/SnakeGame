using NConsoleGraphics;
using SnakeGame.Scenes;
using SnakeGame.Engine;
using SnakeGame.Common;
using SnakeGame.Utils;

namespace SnakeGame.Objects
{
    class MenuItem : IRenderObject
    {
        private readonly string _text;
        public bool IsSelected { get; set; }
        public MenuItemType Type { get; }
        public Point Position { get; }

        public MenuItem(MenuItemType type, string text, Point position)
        {
            Type = type;
            _text = text;
            Position = position;
        }

        public void Render(ConsoleGraphics graphics)
        {
            if (IsSelected)
            {
                graphics.DrawString(_text, ResourcesManager.StringResources.FontName, 0xff000000, Position.X, Position.Y, 18);
            }
            else
            {
                graphics.DrawString(_text, ResourcesManager.StringResources.FontName, 0xffaaaaaa, Position.X, Position.Y);
            }
        }

        public void Update(GameEngine engine)
        {
            
        }
    }
}

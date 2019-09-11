using System;
using GenericCollections;
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
        private List<MenuItem> _items = new List<MenuItem>();
        private int _selectedItem;
        private bool _isKeyDown_Down;
        private bool _isKeyUp_Down;

        public MainMenuScene()
        {
            _items.Add(new MenuItem(MenuItemType.StartNewGame, "Start New Game") { IsSelected = true, Position = new Point(50, 50) });
            _items.Add(new MenuItem(MenuItemType.Quit, "Quit") { Position = new Point(50, 100) });
            _selectedItem = 0;
        }

        public void AddMenuItem(MenuItem item)
        {
            _items.Add(item);
        }

        public override void Render(ConsoleGraphics graphics)
        {
            foreach (var item in _items)
            {
                item.Render(graphics);
            }
        }

        public override void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.RETURN))
            {
                MenuItemType type = _items[_selectedItem].Type;
                switch (type)
                {
                    case MenuItemType.StartNewGame:
                        MainScene scene = new MainScene();
                        scene.AddObject(new Food() { Position = new Point(160, 160) });
                        scene.AddObject(new Food() { Position = new Point(176, 160) });
                        engine.NextScene(scene);
                        break;
                    case MenuItemType.Quit:
                        Environment.Exit(0);
                        break;
                }

            }
            if (!_isKeyDown_Down && Input.IsKeyDown(Keys.DOWN))
            {
                MoveDown();
            }
            else if (!_isKeyUp_Down && Input.IsKeyDown(Keys.UP))
            {
                MoveUp();
            }

            _isKeyDown_Down = Input.IsKeyDown(Keys.DOWN);
            _isKeyUp_Down = Input.IsKeyDown(Keys.UP);
        }

        private void MoveDown()
        {
            _items[_selectedItem++].IsSelected = false;
            if (_selectedItem == _items.Count)
            {
                _selectedItem = 0;
            }
            _items[_selectedItem].IsSelected = true;
        }

        private void MoveUp()
        {
            _items[_selectedItem--].IsSelected = false;
            if (_selectedItem == -1)
            {
                _selectedItem = _items.Count - 1;
            }
            _items[_selectedItem].IsSelected = true;
        }
    }
}

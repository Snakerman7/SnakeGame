using System;
using GenericCollections;
using NConsoleGraphics;

namespace SnakeGame
{
    enum MenuItemType
    {
        StartNewGame,
        BestScores,
        Quit,
        EasyLevel,
        HardLevel
    }

    class MenuScene : Scene
    {
        private List<MenuItem> _items = new List<MenuItem>();
        private int _width;
        private int _height;
        private int _selectedItem;
        private bool _isKeyDown_Down;
        private bool _isKeyUp_Down;

        public MenuScene(int width, int height)
        {
            _selectedItem = 0;
            _width = width;
            _height = height;
        }

        public void AddMenuItems(List<MenuItem> items)
        {
            foreach (var item in items)
            {
                _items.Add(item);
            }
        }

        public override void Render(ConsoleGraphics graphics)
        {
            foreach (var item in _items)
            {
                item.Render(graphics);
            }
            graphics.DrawString("Up or Down for navigate, Enter to choose", "Broadway", 0xFF000000, 30, _height - 30, 8);
        }

        public override void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.RETURN))
            {
                MenuItemType type = _items[_selectedItem].Type;
                switch (type)
                {
                    case MenuItemType.StartNewGame:
                        MenuScene chooseLevelMenu = new MenuScene(_width, _height);
                        chooseLevelMenu.AddMenuItems(MenuScene.GetChooseLevelItems());
                        engine.NextScene(chooseLevelMenu);
                        break;
                    case MenuItemType.BestScores:

                        break;
                    case MenuItemType.Quit:
                        Environment.Exit(Environment.ExitCode);
                        break;
                    case MenuItemType.EasyLevel:
                        MainScene scene1 = new MainScene(_width, _height);
                        scene1.AddObjectToRandomPosition(new Food());
                        engine.ChangeScene(scene1);
                        break;
                    case MenuItemType.HardLevel:
                        MainScene scene2 = new MainScene(_width, _height);
                        scene2.AddObjectToRandomPosition(new Food());
                        for (int i = 0; i < 10; i++)
                        {
                            scene2.AddObjectToRandomPosition(new Stone());
                        }
                        engine.ChangeScene(scene2);
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

        public static List<MenuItem> GetMainMenuItems()
        {
            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem(MenuItemType.StartNewGame, "Start New Game") { IsSelected = true, Position = new Point(50, 50) });
            items.Add(new MenuItem(MenuItemType.BestScores, "Best Scores") { Position = new Point(50, 100) });
            items.Add(new MenuItem(MenuItemType.Quit, "Quit") { Position = new Point(50, 150) });
            return items;
        }

        public static List<MenuItem> GetChooseLevelItems()
        {
            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem(MenuItemType.EasyLevel, "Easy Level") { IsSelected = true, Position = new Point(50, 50) });
            items.Add(new MenuItem(MenuItemType.HardLevel, "Hard Level") { Position = new Point(50, 100) });
            return items;
        }
    }
}

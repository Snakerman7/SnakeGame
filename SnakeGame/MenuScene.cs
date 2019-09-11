﻿using System;
using GenericCollections;
using NConsoleGraphics;

namespace SnakeGame
{
    enum MenuItemType
    {
        StartNewGame,
        BestScores,
        Exit,
        EasyLevel,
        HardLevel
    }

    class MenuScene : Scene
    {
        private List<MenuItem> _items = new List<MenuItem>();
        private int _width;
        private int _height;
        private int _selectedItem;
        private string _helpText;

        private static bool _isKeyDown_Down;
        private static bool _isKeyUp_Down;
        private static bool _isKeyReturn_Down;

        public MenuScene(int width, int height, string helpText = "Up or Down for navigate, Enter to choose")
        {
            _selectedItem = 0;
            _width = width;
            _height = height;
            _helpText = helpText;
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
            graphics.DrawString(_helpText, "Broadway", 0xFF000000, 30, _height - 30, 8);
        }

        public override void Update(GameEngine engine)
        {
            if (!_isKeyReturn_Down && Input.IsKeyDown(Keys.RETURN))
            {
                MenuItemType type = _items[_selectedItem].Type;
                switch (type)
                {
                    case MenuItemType.StartNewGame:
                        MenuScene chooseLevelMenu = new MenuScene(_width, _height, "Up or Down for navigate, Enter to choose, Esc for come back");
                        chooseLevelMenu.AddMenuItems(MenuScene.GetChooseLevelItems());
                        engine.NextScene(chooseLevelMenu);
                        break;
                    case MenuItemType.BestScores:
                        BestScoresScene bestScoresScene = new BestScoresScene(BestScoreManager.GetInstance().GetScores());
                        engine.NextScene(bestScoresScene);
                        break;
                    case MenuItemType.Quit:
                        Environment.Exit(Environment.ExitCode);
                        break;
                    case MenuItemType.EasyLevel:
                        MainScene easyLevelScene = new MainScene(_width, _height);
                        easyLevelScene.AddObjectToRandomPosition(new Food());
                        engine.ChangeScene(easyLevelScene);
                        break;
                    case MenuItemType.HardLevel:
                        MainScene hardLevelScene = new MainScene(_width, _height);
                        hardLevelScene.AddObjectToRandomPosition(new Food());
                        for (int i = 0; i < 10; i++)
                        {
                            hardLevelScene.AddObjectToRandomPosition(new Stone());
                        }
                        engine.ChangeScene(hardLevelScene);
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
            if (Input.IsKeyDown(Keys.ESCAPE))
            {
                engine.PrevScene();
            }

            _isKeyDown_Down = Input.IsKeyDown(Keys.DOWN);
            _isKeyUp_Down = Input.IsKeyDown(Keys.UP);
            _isKeyReturn_Down = Input.IsKeyDown(Keys.RETURN);
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
            items.Add(new MenuItem(MenuItemType.Exit, "Exit") { Position = new Point(50, 150) });
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

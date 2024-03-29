﻿using System;
using GenericCollections;
using NConsoleGraphics;
using SnakeGame.Objects;
using SnakeGame.Engine;
using SnakeGame.Common;
using SnakeGame.Utils;

namespace SnakeGame.Scenes
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
        private readonly List<MenuItem> _items = new List<MenuItem>();
        private readonly int _width;
        private readonly int _height;
        private readonly string _helpText;
        private int _selectedItem;
        private bool _isKeyDown_Down;
        private bool _isKeyUp_Down;
        private bool _isKeyReturn_Down = true;

        public MenuScene(int width, int height, string helpText = ResourcesManager.StringResources.MainMenuHelpText)
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
            graphics.DrawString(_helpText, ResourcesManager.StringResources.FontName, ResourcesManager.ColorResources.TextColor, 30, _height - 30, 8);
        }

        public override void Update(GameEngine engine)
        {
            if (!_isKeyReturn_Down && Input.IsKeyDown(Keys.RETURN))
            {
                MenuItemType type = _items[_selectedItem].Type;
                switch (type)
                {
                    case MenuItemType.StartNewGame:
                        MenuScene chooseLevelMenu = new MenuScene(_width, _height, ResourcesManager.StringResources.ChooseLevelMenuHelpText);
                        chooseLevelMenu.AddMenuItems(MenuScene.GetChooseLevelItems());
                        engine.NextScene(chooseLevelMenu);
                        break;
                    case MenuItemType.BestScores:
                        BestScoresScene bestScoresScene = new BestScoresScene(BestScoreManager.GetScores());
                        engine.NextScene(bestScoresScene);
                        break;
                    case MenuItemType.Exit:
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
                        for (int i = 0; i < 25; i++)
                        {
                            hardLevelScene.AddObjectToRandomPosition(new Tree());
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
            List<MenuItem> items = new List<MenuItem>
            {
                new MenuItem(MenuItemType.StartNewGame, ResourcesManager.StringResources.MenuStartGameText, new Point(50, 50)) { IsSelected = true },
                new MenuItem(MenuItemType.BestScores, ResourcesManager.StringResources.MenuBestScoresText, new Point(50, 100)),
                new MenuItem(MenuItemType.Exit, ResourcesManager.StringResources.MenuExitText, new Point(50, 150))
            };
            return items;
        }

        public static List<MenuItem> GetChooseLevelItems()
        {
            List<MenuItem> items = new List<MenuItem>
            {
                new MenuItem(MenuItemType.EasyLevel, ResourcesManager.StringResources.MenuEasyLevelText, new Point(50, 50)) { IsSelected = true },
                new MenuItem(MenuItemType.HardLevel, ResourcesManager.StringResources.MenuHardLevelText, new Point(50, 100))
            };
            return items;
        }
    }
}

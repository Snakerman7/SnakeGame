using NConsoleGraphics;
using System;
using SnakeGame.Scenes;
using SnakeGame.Engine;
using SnakeGame.Utils;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 74;
            Console.WindowHeight = 30;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();

            GameEngine engine = new GameEngine(graphics);
            ResourcesManager.ImageResources.LoadImages(graphics);
            MenuScene scene = new MenuScene(graphics.ClientWidth, graphics.ClientHeight);
            scene.AddMenuItems(MenuScene.GetMainMenuItems());
            engine.ChangeScene(scene);

            engine.Start();
        }
    }
}

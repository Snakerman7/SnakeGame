using NConsoleGraphics;
using System;

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
            ResourcesManager.GetInstance().LoadResources(graphics);
            MenuScene scene = new MenuScene(graphics.ClientWidth, graphics.ClientHeight);
            scene.AddMenuItems(MenuScene.GetMainMenuItems());
            engine.ChangeScene(scene);

            engine.Start();
        }
    }
}

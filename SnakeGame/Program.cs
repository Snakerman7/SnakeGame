using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 100;
            Console.WindowHeight = 35;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();

            GameEngine engine = new GameEngine(graphics);
            //GameScene scene = new GameScene(graphics.ClientWidth, graphics.ClientHeight);
            MainMenuScene scene = new MainMenuScene(graphics.ClientWidth, graphics.ClientHeight);
            //scene.AddObject(new Food() { Position = new Point(160, 160) });
            engine.ChangeScene(scene);
            engine.Start();
            
        }
    }
}

using GenericCollections;
using NConsoleGraphics;
using System.Threading;

namespace SnakeGame
{
    public class GameEngine
    {
        private readonly ConsoleGraphics _graphics;
        private Scene _curScene;
        private readonly Stack<Scene> _prevScenes = new Stack<Scene>();

        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
        }

        public void NextScene(Scene nextScene)
        {
            if (_curScene != null)
            {
                _curScene.Stop();
                _prevScenes.Puch(_curScene);
            }
            _curScene = nextScene;
            _curScene.Start();
        }

        public void PrevScene()
        {
            if (_prevScenes.Count > 0)
            {
                _curScene.Stop();
                _curScene = _prevScenes.Pop();
                _curScene.Start();
            }
        }

        public void ChangeScene(Scene newScene)
        {
            _curScene = newScene;
            _curScene.Start();
        }

        public void StopCurrentScene()
        {
            _curScene.Stop();
        }

        public void Start()
        {

            while (true)
            {
                // Game Loop
                _curScene.Update(this);

                // clearing screen before painting new frame
                _graphics.FillRectangle(ResourcesManager.MenuBackgroundColor, 0, 0, _graphics.ClientWidth, _graphics.ClientHeight);
                _curScene.Render(_graphics);

                // double buffering technique is used
                _graphics.FlipPages();

                Thread.Sleep(80);
            }
        }
    }
}

using NConsoleGraphics;

namespace SnakeGame
{
    public class EndGameScene : Scene
    {
        private readonly string _text;
        private readonly int _scores;

        public EndGameScene(string text, int scores)
        {
            _text = text;
            _scores = scores;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawString(_text, ResourcesManager.FontName, ResourcesManager.TextColor, 50, 150, 20);
            graphics.DrawString(ResourcesManager.BuildEndGameScoreText(_scores), ResourcesManager.FontName, ResourcesManager.TextColor, 50, 250);
            graphics.DrawString(ResourcesManager.EndGameSceneHelpText, ResourcesManager.FontName, ResourcesManager.TextColor, 30, graphics.ClientHeight - 30, 8);
        }

        public override void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.RETURN))
            {
                BestScoreManager.AddScores(_scores);
                engine.PrevScene();
            }
        }
    }
}

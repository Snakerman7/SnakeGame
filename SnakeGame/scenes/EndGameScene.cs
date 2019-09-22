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
            graphics.DrawString(_text, ResourcesManager.StringResources.FontName, ResourcesManager.ColorResources.TextColor, 50, 150, 20);
            graphics.DrawString(ResourcesManager.StringResources.BuildEndGameScoreText(_scores), ResourcesManager.StringResources.FontName, ResourcesManager.ColorResources.TextColor, 50, 250);
            graphics.DrawString(ResourcesManager.StringResources.EndGameSceneHelpText, ResourcesManager.StringResources.FontName, ResourcesManager.ColorResources.TextColor, 30, graphics.ClientHeight - 30, 8);
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

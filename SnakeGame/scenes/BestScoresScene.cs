using NConsoleGraphics;

namespace SnakeGame
{
    public class BestScoresScene : Scene
    {
        private readonly int[] _bestScores;

        public BestScoresScene(int[] scores)
        {
            _bestScores = scores;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < _bestScores.Length; i++)
            {
                graphics.DrawString(ResourcesManager.BuildBestScoreItemText(i + 1, _bestScores[i]), ResourcesManager.FontName, ResourcesManager.TextColor, 50, i * 50);
            }
            graphics.DrawString(ResourcesManager.BestScoreSceneHelpText, ResourcesManager.FontName, ResourcesManager.TextColor, 30, graphics.ClientHeight - 30, 8);
        }

        public override void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.ESCAPE))
            {
                engine.PrevScene();
            }
        }
    }
}

using NConsoleGraphics;
using SnakeGame.Engine;
using SnakeGame.Utils;

namespace SnakeGame.Scenes
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
                graphics.DrawString(ResourcesManager.StringResources.BuildBestScoreItemText(i + 1, _bestScores[i]), ResourcesManager.StringResources.FontName, ResourcesManager.ColorResources.TextColor, 50, i * 50);
            }
            graphics.DrawString(ResourcesManager.StringResources.BestScoreSceneHelpText, ResourcesManager.StringResources.FontName, ResourcesManager.ColorResources.TextColor, 30, graphics.ClientHeight - 30, 8);
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

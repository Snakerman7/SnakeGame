using NConsoleGraphics;

namespace SnakeGame
{
    public class BestScoresScene : Scene
    {
        private int[] _bestScores;

        public BestScoresScene(int[] scores)
        {
            _bestScores = scores;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < _bestScores.Length; i++)
            {
                graphics.DrawString($"{i + 1} place   :   {_bestScores[i]}", "Broadway", 0xff000000, 50, i * 50);
            }
            graphics.DrawString("Press Esc for come back to main menu", "Broadway", 0xFF000000, 30, graphics.ClientHeight - 30, 8);
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

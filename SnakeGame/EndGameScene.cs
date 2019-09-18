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
            graphics.DrawString(_text, "Broadway", 0xff000000, 50, 150, 20);
            graphics.DrawString($"Your scores: {_scores}", "Broadway", 0xff000000, 50, 250);
            graphics.DrawString("Press Enter for back to main menu", "Broadway", 0xFF000000, 30, graphics.ClientHeight - 30, 8);
        }

        public override void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.RETURN))
            {
                BestScoreManager.GetInstance().AddScores(_scores);
                engine.PrevScene();
            }
        }
    }
}

using NConsoleGraphics;

namespace SnakeGame
{
    public static class ResourcesManager
    {
        #region fonts

        public const string FontName = "Broadway";

        #endregion

        #region color resources

        public const uint TextColor = 0xff000000;
        public const uint MenuBackgroundColor = 0xffffffff;
        public const uint MainSceneBackgroundColor = 0xff155c12;

        #endregion

        #region string resources

        public const string GUIHelpText = "Up, Down, Left, Right for control snake";
        public const string BestScoreSceneHelpText = "Press Esc for come back to main menu";
        public const string EndGameSceneHelpText = "Press Enter for back to main menu";
        public const string MainMenuHelpText = "Up or Down for navigate, Enter to choose";
        public const string ChooseLevelMenuHelpText = "Up or Down for navigate, Enter to choose, Esc for come back";
        public const string MenuStartGameText = "Start New Game";
        public const string MenuBestScoresText = "Best Scores";
        public const string MenuExitText = "Exit";
        public const string MenuEasyLevelText = "Easy Level";
        public const string MenuHardLevelText = "Hard Level";
        public const string LoseText = "You lose";
        public const string WinText = "You win";

        private const string BestScoreItemText = "{0} place   :   {1}";
        private const string EndGameScoreText = "Your scores: {0}";
        private const string GUIScoreText = "Scores: {0}";

        public static string BuildEndGameScoreText(int scores)
        {
            return string.Format(EndGameScoreText, scores);
        }

        public static string BuildBestScoreItemText(int place, int scores)
        {
            return string.Format(BestScoreItemText, place, scores);
        }

        public static string BuildGUIScoreText(int score)
        {
            return string.Format(GUIScoreText, score);
        }

        #endregion

        #region image resources

        public static ConsoleImage SnakeImage { get; private set; }
        public static ConsoleImage TreeImage { get; private set; }

        public static void LoadResources(ConsoleGraphics graphics)
        {
            SnakeImage = graphics.LoadImage("images/snake.png");
            TreeImage = graphics.LoadImage("images/tree.png");
        }

        #endregion
    }
}

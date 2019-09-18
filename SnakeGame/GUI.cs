using NConsoleGraphics;

namespace SnakeGame
{
    public class GUI : Scene
    {
        public Point Position { get; }
        public int Scores { get; set; }

        public GUI(Point position)
        {
            Position = position;
            Scores = 0;
        }

        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawString(ResourcesManager.BuildGUIScoreText(Scores), ResourcesManager.FontName, ResourcesManager.TextColor, Position.X + 20, Position.Y + 5);
            graphics.DrawString(ResourcesManager.GUIHelpText, ResourcesManager.FontName, ResourcesManager.TextColor, Position.X + 250, Position.Y + 10, 8);
        }

        public override void Update(GameEngine engine)
        {

        }
    }
}

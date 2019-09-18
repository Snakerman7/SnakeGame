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
            graphics.DrawString($"Scores: {Scores}", "Broadway", 0xff000000, Position.X + 20, Position.Y + 5);
            graphics.DrawString("Up, Down, Left, Right for control snake", "Broadway", 0xff000000, Position.X + 250, Position.Y + 10, 8);
        }

        public override void Update(GameEngine engine)
        {

        }
    }
}

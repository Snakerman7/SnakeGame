using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Common
{
    struct Size
    {
        public int Height { get; }
        public int Width { get; }

        public Size(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}

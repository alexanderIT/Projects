using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Common
{
    public class WindowsSettings
    {
        public const int WIN_HEIGHT = 50;
        public const int WIN_WIDTH = 70;

        public static void Initialize()
        {
            Console.Title = ("Space Battle");
            Console.BufferHeight = Console.WindowHeight = WIN_HEIGHT;
            Console.BufferWidth = Console.WindowWidth = WIN_WIDTH;
            Console.Clear();
            Console.CursorVisible = false;
        }
    }
}

using System;
using System.Drawing;
using Cosmos.System;

namespace PBOS.System.Core.Desktop
{
    public static class MouseUtils
    {
        public static bool LeftMouseDown { get; set; }

        public static bool IsHovering(Rectangle otherRect)
        {
            return otherRect.Contains((int)MouseManager.X, (int)MouseManager.Y);
        }
    }
}
using System;
using GrapeGL.Graphics;
using PBOS.System.Core.Desktop.Components;
using PBOS.System.Core.Desktop.Processing;

namespace PBOS.System.Core.Desktop
{
    public static class WindowDrawing
    {
        public const int TopSize = 30;

        public static void DrawTop(Process proc)
        {
            DesktopEnv.MainDisplay.DrawFilledRectangle(proc.Window.X, proc.Window.Y, (ushort)proc.Window.Width, TopSize, 0, CatppuccinMocha.Base);
            DesktopEnv.MainDisplay.DrawString(proc.Window.X + 8, proc.Window.Y + 24 + 4, proc.Window.Title, DesktopEnv.Bold, CatppuccinMocha.Text, true);
            DrawCloseButton(proc);
        }

        private static void DrawCloseButton(Process proc)
        {
            Button btn = new Button(proc.Window.X + proc.Window.Width - 25, proc.Window.Y + 5, Color.Red, CatppuccinMocha.Text, "X", DesktopEnv.Bold, () =>
            {
                ProcessManager.Kill(proc);
            });
            btn.Display();
        }

        public static void DrawFill(Color col, Process proc)
        {
            DesktopEnv.MainDisplay.DrawFilledRectangle(proc.Window.X, proc.Window.Y + TopSize, (ushort)proc.Window.Width, (ushort)(proc.Window.Height - TopSize), 16, col);
        }

        public static void DrawWindow(Color fill, Process proc)
        {
            DrawTop(proc);
            DrawFill(fill, proc);
        }
    }
}
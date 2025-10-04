using System;
using System.Drawing;
using PBOS.System.Core.Desktop.Components;
using PBOS.System.Core.Desktop.Processing;

namespace PBOS.System.Core.Desktop
{
    public static class WindowDrawing
    {
        public const int TopSize = 30;

        public static void DrawTop(Process proc)
        {
            DesktopEnv.MainCanvas.DrawFilledRectangle(CatppuccinMocha.Base, proc.Window.X, proc.Window.Y, proc.Window.Width, TopSize);
            DesktopEnv.Bold.DrawToSurface(DesktopEnv.Surface, 24, proc.Window.X + 8, proc.Window.Y + 24 + 4, proc.Window.Title, CatppuccinMocha.Text);
            DrawCloseButton(proc);
        }

        private static void DrawCloseButton(Process proc)
        {
            Button btn = new Button(proc.Window.X + proc.Window.Width - 25, proc.Window.Y + 5, Color.Red, CatppuccinMocha.Text, "X", DesktopEnv.Bold, 16, () =>
            {
                ProcessManager.Kill(proc);
            });
            btn.Display();
        }

        public static void DrawFill(Color col, Process proc)
        {
            DesktopEnv.MainCanvas.DrawFilledRectangle(col, proc.Window.X, proc.Window.Y + TopSize, proc.Window.Width, proc.Window.Height - TopSize);
        }

        public static void DrawWindow(Color fill, Process proc)
        {
            DrawTop(proc);
            DrawFill(fill, proc);
        }
    }
}
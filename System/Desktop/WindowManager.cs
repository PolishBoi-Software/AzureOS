using System;
using System.Drawing;
using Cosmos.System;
using PBOS.System.Core.Desktop.Processing;

namespace PBOS.System.Core.Desktop
{
    public static class WindowManager
    {
        private static int OldX;
        private static int OldY;
        private static Process Grabbing;
        private static Process Resizing;
        private static int ResizeZoneOffset = 25;

        public static void ResizeWindows()
        {
            if (Resizing != null)
            {
                Resizing.Window.Width = Math.Max(250, (int)MouseManager.X - Resizing.Window.X);
                Resizing.Window.Height = Math.Max(300, (int)MouseManager.Y - Resizing.Window.Y);
            }
            else if (MouseManager.MouseState == MouseState.Left)
            {
                foreach (var proc in ProcessManager.Processes)
                {
                    if (!proc.Window.Resizeable) continue;

                    Rectangle rect = new Rectangle(proc.Window.X + proc.Window.Width - ResizeZoneOffset, proc.Window.Y + proc.Window.Height - ResizeZoneOffset, ResizeZoneOffset, ResizeZoneOffset);

                    if (MouseUtils.IsHovering(rect))
                    {
                        Resizing = proc;
                    }
                }
            }

            if (MouseManager.MouseState == MouseState.None)
            {
                Resizing = null;
            }
        }

        public static void MoveWindows()
        {
            if (Grabbing != null)
            {
                Grabbing.Window.X = Math.Max(0, Math.Min((int)DesktopEnv.MainCanvas.Mode.Width, (int)MouseManager.X - OldX));
                Grabbing.Window.Y = Math.Max(0, Math.Min((int)DesktopEnv.MainCanvas.Mode.Height, (int)MouseManager.Y - OldY));
            }
            else if (MouseManager.MouseState == MouseState.Left)
            {
                foreach (var proc in ProcessManager.Processes)
                {
                    if (!proc.Window.Moveable) continue;

                    Rectangle rect = new Rectangle(proc.Window.X, proc.Window.Y, proc.Window.Width, WindowDrawing.TopSize);

                    if (MouseUtils.IsHovering(rect))
                    {
                        OldX = (int)MouseManager.X - proc.Window.X;
                        OldY = (int)MouseManager.Y - proc.Window.Y;
                        Grabbing = proc;
                    }
                }
            }

            if (MouseManager.MouseState == MouseState.None)
            {
                Grabbing = null;
            }
        }
    }
}
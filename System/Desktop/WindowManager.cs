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

        public static void MoveWindows()
        {
            if (Grabbing != null)
            {
                Grabbing.Window.X = (int)MouseManager.X - OldX;
                Grabbing.Window.Y = (int)MouseManager.Y - OldY;
            }
            else if (MouseManager.MouseState == MouseState.Left)
            {
                for (int i = ProcessManager.Processes.Count - 1; i >= 0; i--)
                {
                    Process proc = ProcessManager.Processes[i];
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
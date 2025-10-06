using System;
using PBOS.System.Core.Desktop.Components;
using PBOS.System.Core.Desktop.Processing;

namespace PBOS.System.Core.Desktop.Apps
{
    public class TaskMgrApp : Process
    {
        public override void OnExit()
        {

        }

        public override void Run()
        {
            int itemY = 20;
            WindowDrawing.DrawWindow(CatppuccinMocha.Mantle, this);
            foreach (var proc in ProcessManager.Processes)
            {
                Button btn = new Button(Window.X + 10, Window.Y + WindowDrawing.TopSize + itemY + 10, CatppuccinMocha.Base, CatppuccinMocha.Text, proc.Name, DesktopEnv.Regular, () =>
                {
                    ProcessManager.Kill(proc);
                });
                btn.Width = Window.Width - 20;
                btn.Display();
                itemY += 30;
            }
        }

        public override void Start()
        {
            
        }
    }
}
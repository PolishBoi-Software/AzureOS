using System;
using PBOS.System.Core.Desktop.Processing;

namespace PBOS.System.Core.Desktop.Apps
{
    public class TestApp : Process
    {
        public override void OnExit()
        {
            
        }

        public override void Run()
        {
            WindowDrawing.DrawWindow(CatppuccinMocha.Mantle, this);
        }

        public override void Start()
        {
            
        }
    }
}
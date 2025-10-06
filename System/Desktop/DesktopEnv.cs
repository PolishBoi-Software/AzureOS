using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PBOS.System.Core.Desktop.Components;
using Cosmos.Core.Memory;
using Cosmos.System;
using PBOS.System.Core.Desktop.Processing;
using PBOS.System.Core.Desktop.Apps;
using GrapeGL.Graphics.Fonts;
using GrapeGL.Hardware.GPU;
using GrapeGL.Graphics;

namespace PBOS.System.Core.Desktop
{
    public static class DesktopEnv
    {
        public static Display MainDisplay { get; set; } = null;
        public static bool FinishedLoading = false;
        public static Canvas Cursor { get; set; }
        public static Canvas Wallpaper { get; set; }
        public static AcfFontFace Bold { get; set; }
        public static AcfFontFace Regular { get; set; }
        private static int LastHeap = 0;
        public static bool DoGui = false;
        private static Taskbar TBar;

        public static void Init()
        {
            DoGui = true;
            MainDisplay = Display.GetDisplay(1920, 1080);
            LoadingScreen.Init(MainDisplay);
            if (!FinishedLoading)
            {
                LoadingScreen.SetStatusMessage("Loading cursor...");
                Cursor = Image.FromPNG(File.ReadAllBytes(@"1:\cursor.png"));
                LoadingScreen.SetStatusMessage("Loading wallpaper...");
                Wallpaper = Image.FromPNG(File.ReadAllBytes(@"1:\wallpaper.png"));
                LoadingScreen.SetStatusMessage("Loading bold font...");
                Bold = new AcfFontFace(new MemoryStream(File.ReadAllBytes(@"1:\interbold.acf")));
                LoadingScreen.SetStatusMessage("Loading regular font...");
                Regular = new AcfFontFace(new MemoryStream(File.ReadAllBytes(@"1:\interregular.acf")));
                LoadingScreen.SetStatusMessage("Finished");
                Thread.Sleep(500);
            }
            MouseManager.ScreenWidth = MainDisplay.Width;
            MouseManager.ScreenHeight = MainDisplay.Height;
            MainDisplay.Clear();
            FinishedLoading = true;
            TBar = new Taskbar();

            TBar.Menu.AddItem("Task Manager", () =>
            {
                ProcessManager.Start(new TaskMgrApp(), new WindowData("Task Manager", 200, 200, 600, 800, true), "taskmgr");
            });

            TBar.Menu.AddItem("Shutdown", () =>
            {
                Kernel.Shutdown();
            });

            TBar.Menu.AddItem("Reboot", () =>
            {
                Kernel.Shutdown(true);
            });
        }

        public static void Update()
        {
            MainDisplay.DrawImage(0, 0, Wallpaper, false);
            ProcessManager.Update();
            WindowManager.ResizeWindows();
            WindowManager.MoveWindows();
            TBar.Display();
            MainDisplay.DrawImage((int)MouseManager.X, (int)MouseManager.Y, Cursor);
            MainDisplay.Update();
            if (LastHeap % 20 == 0) Heap.Collect();
            LastHeap++;
        }
    }
}
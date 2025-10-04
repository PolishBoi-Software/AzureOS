using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PBOS.System.Core.Desktop.Components;
using Cosmos.Core.Memory;
using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosTTF;

namespace PBOS.System.Core.Desktop
{
    public static class DesktopEnv
    {
        public static Canvas MainCanvas { get; set; } = null;
        public static bool FinishedLoading = false;
        public static Bitmap Cursor { get; set; }
        public static Bitmap Wallpaper { get; set; }
        public static TTFFont Bold { get; set; }
        public static TTFFont Regular { get; set; }
        public static CGSSurface Surface { get; set; }
        private static int LastHeap = 0;
        public static bool DoGui = false;
        private static Taskbar TBar;

        public static void Init()
        {
            DoGui = true;
            MainCanvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
            Surface = new CGSSurface(MainCanvas);
            LoadingScreen.Init(MainCanvas);
            if (!FinishedLoading)
            {
                LoadingScreen.SetStatusMessage("Loading cursor...");
                Cursor = new Bitmap(File.ReadAllBytes(@"1:\cursor.bmp"));
                LoadingScreen.SetStatusMessage("Loading wallpaper...");
                Wallpaper = new Bitmap(File.ReadAllBytes(@"1:\wallpaper.bmp"));
                LoadingScreen.SetStatusMessage("Loading bold font...");
                Bold = new TTFFont(File.ReadAllBytes(@"1:\interbold.ttf"));
                LoadingScreen.SetStatusMessage("Loading regular font...");
                Regular = new TTFFont(File.ReadAllBytes(@"1:\interregular.ttf"));
                LoadingScreen.SetStatusMessage("Finished");
                Thread.Sleep(500);
            }
            MouseManager.ScreenWidth = MainCanvas.Mode.Width;
            MouseManager.ScreenHeight = MainCanvas.Mode.Height;
            MainCanvas.Clear();
            FinishedLoading = true;
            TBar = new Taskbar();

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
            MainCanvas.DrawImage(Wallpaper, 0, 0);
            TBar.Display();
            MainCanvas.DrawImageAlpha(Cursor, (int)MouseManager.X, (int)MouseManager.Y);
            MainCanvas.Display();
            if (LastHeap % 20 == 0) Heap.Collect();
            LastHeap++;
        }
    }
}
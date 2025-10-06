using System;
using System.Drawing;
using System.IO;
using System.Threading;
using PBOS.System.Core;
using PBOS.System.Terminal;
using PBOS.System.VFSUtils;
using Cosmos.Core.Memory;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using CosmosUsers;
using Sys = Cosmos.System;
using Cosmos.System.ExtendedASCII;
using System.Text;
using PBOS.System.Core.Desktop;
using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;

namespace PBOS
{
    public class Kernel : Sys.Kernel
    {
        public static CosmosVFS FileSystem { get; set; }
        public static User CurrentUser { get; set; }
        public static Canvas Logo { get; set; }

        protected override void BeforeRun()
        {
            Encoding.RegisterProvider(CosmosEncodingProvider.Instance);
            Console.OutputEncoding = CosmosEncodingProvider.Instance.GetEncoding(437);
            Console.InputEncoding = CosmosEncodingProvider.Instance.GetEncoding(437);
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.USStandardLayout());
            FileSystem = new CosmosVFS();
            VFSManager.RegisterVFS(FileSystem);
            UserManager.LoadUsers();
            Logo = Image.FromPNG(File.ReadAllBytes(@"1:\logo.png"));
            
            DiskUtils.FormatDisk(0, true, true);
            CommandManager.RegisterAll();
            LoadingScreen.fnt = new AcfFontFace(new MemoryStream(File.ReadAllBytes(@"1:\cascadiacode.acf")));
            Shell.AskUser();
            Shell.Start();
        }

        public static void Shutdown(bool reboot = false)
        {
            if (DesktopEnv.MainDisplay == null)
            {
                Console.Clear();
                Console.WriteLine("Goodbye!");
            }
            Sys.PCSpeaker.Beep(Sys.Notes.D5, Sys.Durations.Quarter);
            Sys.PCSpeaker.Beep(Sys.Notes.C5, Sys.Durations.Sixteenth);
            Sys.PCSpeaker.Beep(Sys.Notes.D5, Sys.Durations.Sixteenth);
            Sys.PCSpeaker.Beep(Sys.Notes.A5, Sys.Durations.Eighth);
            Sys.PCSpeaker.Beep(Sys.Notes.D5, Sys.Durations.Quarter);
            Sys.PCSpeaker.Beep(Sys.Notes.C5, Sys.Durations.Eighth);
            Sys.PCSpeaker.Beep(Sys.Notes.C4, Sys.Durations.Eighth);
            Sys.PCSpeaker.Beep(Sys.Notes.C3, Sys.Durations.Eighth);
            if (reboot)
                Sys.Power.Reboot();
            else
                Sys.Power.Shutdown();
        }

        protected override void Run()
        {
            if (!DesktopEnv.DoGui)
            {
                Shell.PrintPrompt();
                var input = Console.ReadLine();
                Shell.RunCommand(input);
            }
            else
            {
                if (DesktopEnv.FinishedLoading)
                    DesktopEnv.Update();
            }
        }
    }
}

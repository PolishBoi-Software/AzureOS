using System;
using System.Drawing;
using System.IO;
using System.Threading;
using AzureOS.System.Core;
using AzureOS.System.Terminal;
using AzureOS.System.VFSUtils;
using Cosmos.Core.Memory;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using CosmosUsers;
using CosmosTTF;
using Sys = Cosmos.System;
using Cosmos.System.ExtendedASCII;
using System.Text;

namespace AzureOS
{
    public class Kernel : Sys.Kernel
    {
        public static CosmosVFS FileSystem { get; set; }
        public static PCScreenFont PSFFont { get; set; }
        public static User CurrentUser { get; set; }

        protected override void BeforeRun()
        {
            Encoding.RegisterProvider(CosmosEncodingProvider.Instance);
            Console.OutputEncoding = CosmosEncodingProvider.Instance.GetEncoding(437);
            Console.InputEncoding = CosmosEncodingProvider.Instance.GetEncoding(437);
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.USStandardLayout());
            Console.SetWindowSize(90, 30);
            FileSystem = new CosmosVFS();
            VFSManager.RegisterVFS(FileSystem);
            UserManager.LoadUsers();
            PSFFont = PCScreenFont.LoadFont(File.ReadAllBytes(@"1:\zap-light16.psf"));
            VGAScreen.SetFont(PSFFont.CreateVGAFont(), PSFFont.Height);
            DiskUtils.FormatDisk(0, true, true);
            CommandManager.RegisterAll();
            Shell.AskUser();
            Shell.Start();
        }

        public static void Shutdown(bool reboot = false)
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
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
            Shell.PrintPrompt();
            var input = Console.ReadLine();
            Shell.RunCommand(input);
        }
    }
}

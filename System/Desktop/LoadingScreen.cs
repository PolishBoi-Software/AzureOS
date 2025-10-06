using System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Network.IPv4.TCP;
using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;
using GrapeGL.Hardware.GPU;

namespace PBOS.System.Core.Desktop
{
    public static class LoadingScreen
    {
        private static string StatusMessage = string.Empty;
        public static AcfFontFace fnt;
        private static Display Displ;
        public static void Init(Display canv)
        {
            Displ = canv;
        }

        public static void SetStatusMessage(string message)
        {
            StatusMessage = message;
            Update();
        }

        public static void Update()
        {
            Displ.Clear();
            int logoCenterX = (Displ.Width / 2) - (Kernel.Logo.Width / 2);
            int logoCenterY = (Displ.Height / 2) - (Kernel.Logo.Height / 2);
            Displ.DrawImage(logoCenterX, logoCenterY, Kernel.Logo);
            Displ.DrawString(0, Displ.Height - 500, StatusMessage, fnt, Color.White, true);
            Displ.Update();
        }
    }
}
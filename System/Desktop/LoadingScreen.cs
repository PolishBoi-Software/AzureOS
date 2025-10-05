using System;
using System.Drawing;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Network.IPv4.TCP;

namespace PBOS.System.Core.Desktop
{
    public static class LoadingScreen
    {
        private static string StatusMessage = string.Empty;
        private static Canvas Canv;
        public static void Init(Canvas canv)
        {
            Canv = canv;
        }

        public static void SetStatusMessage(string message)
        {
            StatusMessage = message;
            Update();
        }

        public static void Update()
        {
            Canv.Clear();
            int textCenterX = ((int)Canv.Mode.Width / 2) - (Kernel.PSFFont.Width * StatusMessage.Length / 2);
            int logoCenterX = ((int)Canv.Mode.Width / 2) - ((int)Kernel.Logo.Width / 2);
            int logoCenterY = ((int)Canv.Mode.Height / 2) - ((int)Kernel.Logo.Height / 2);
            Canv.DrawImageAlpha(Kernel.Logo, logoCenterX, logoCenterY);
            Canv.DrawString(StatusMessage, Kernel.PSFFont, Color.White, textCenterX, (int)Canv.Mode.Height - 100);
            Canv.Display();
        }
    }
}
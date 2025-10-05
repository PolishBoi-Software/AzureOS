using System;

namespace PBOS.System.Core.Desktop.Processing
{
    public struct WindowData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Title { get; set; }
        public bool Moveable { get; set; }
        public bool Resizeable { get; set; }

        public WindowData(string title, int x, int y, int w, int h, bool moveable = true, bool resizeable = true)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
            Moveable = moveable;
            Title = title;
            Resizeable = resizeable;
        }
    }
}
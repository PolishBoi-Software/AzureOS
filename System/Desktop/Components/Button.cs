using System;
using System.Drawing;
using PBOS.System.Utils;
using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosTTF;

namespace PBOS.System.Core.Desktop.Components
{
    public class Button : Component
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public int Width { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public string Text { get; set; }
        public TTFFont Font { get; set; }
        public int FontSize { get; set; }
        public Action OnClick { get; set; }
        private bool Hovered;

        public Button(int x, int y, Color bg, Color fg, string text, TTFFont font, int size, Action onClick)
        {
            X = x;
            Y = y;
            BackgroundColor = bg;
            TextColor = fg;
            Font = font;
            Text = text;
            FontSize = size;
            OnClick = onClick;
            Width = Font.CalculateWidth(Text, FontSize) + 10;
        }

        public override void Display()
        {
            Update();
            int centerX = X + (Width - (Width - 10)) / 2;
            DesktopEnv.MainCanvas.DrawFilledRectangle(Hovered ? ColorUtils.Darken(BackgroundColor, 10) : BackgroundColor, X, Y, Width, FontSize + 10);
            Font.DrawToSurface(DesktopEnv.Surface, FontSize, centerX, Y + FontSize, Text, TextColor);
        }

        public override void Update()
        {
            Rectangle rect = new Rectangle(X, Y, Width, FontSize + 10);
            MouseState state = MouseManager.MouseState;

            Hovered = MouseUtils.IsHovering(rect);

            if (Hovered)
            {
                if (MouseUtils.LeftMouseDown != (state == MouseState.Left))
                {
                    if (!MouseUtils.LeftMouseDown)
                    {
                        OnClick?.Invoke();
                    }
                    MouseUtils.LeftMouseDown = state == MouseState.Left;
                }   
            }
        }
    }
}
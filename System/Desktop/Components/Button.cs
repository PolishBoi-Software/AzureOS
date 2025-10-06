using System;
using PBOS.System.Utils;
using Cosmos.System;
using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;
using Rectangle = System.Drawing.Rectangle;

namespace PBOS.System.Core.Desktop.Components
{
    public class Button : Component
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public string Text { get; set; }
        public AcfFontFace Font { get; set; }
        public Action OnClick { get; set; }
        private bool Hovered;

        public Button(int x, int y, Color bg, Color fg, string text, AcfFontFace font, Action onClick)
        {
            X = x;
            Y = y;
            BackgroundColor = bg;
            TextColor = fg;
            Font = font;
            Text = text;
            OnClick = onClick;
            Width = Font.MeasureString(Text) + 10;
            Height = Font.GetHeight();
        }

        public override void Display()
        {
            Update();
            DesktopEnv.MainDisplay.DrawFilledRectangle(X, Y, (ushort)Width, (ushort)Height, 16, BackgroundColor);
            DesktopEnv.MainDisplay.DrawString(X, Y, Text, Font, TextColor, true);
        }

        public override void Update()
        {
            Rectangle rect = new Rectangle(X, Y, Width, Height);
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
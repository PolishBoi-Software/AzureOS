using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Cosmos.System;

namespace PBOS.System.Core.Desktop.Components
{
    public class Menu : Component
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public const int Height = 1000;
        public const int Width = 600;
        public bool Open { get; set; }
        public List<Button> Items { get; set; } = new List<Button>();

        public Menu()
        {
            X = 0;
            Y = Taskbar.Height + 10;
            Open = false;
        }

        public void AddItem(string text, Action onClick)
        {
            Button btn = new Button(X + 10, Y, CatppuccinMocha.Base, CatppuccinMocha.Text, text, DesktopEnv.Bold, () =>
            {
                Open = false;
                onClick?.Invoke();
            });
            Items.Add(btn);
        }

        public override void Display()
        {
            if (!Open) return;

            int itemY = 60;
            DesktopEnv.MainDisplay.DrawFilledRectangle(X, Y, Width, Height, 16, CatppuccinMocha.Crust);
            DesktopEnv.MainDisplay.DrawString(X + 10, Y + 10, $"Hello, {Kernel.CurrentUser.Name}!", DesktopEnv.Bold, CatppuccinMocha.Text);
            foreach (var item in Items)
            {
                item.Y = Y + itemY;
                item.Width = Width - 20;
                item.Display();
                itemY += 40;
            }
        }

        public override void Update()
        {
            
        }
    }
}
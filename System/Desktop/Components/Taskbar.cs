using System;

namespace PBOS.System.Core.Desktop.Components
{
    public class Taskbar : Component
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public const int Height = 40;
        public Menu Menu;
        private Button MenuBtn;

        public Taskbar()
        {
            X = 0;
            Y = 0;
            Menu = new Menu();
            MenuBtn = new Button(10, (Height / 2) - 10, CatppuccinMocha.Base, CatppuccinMocha.Text, "Menu", DesktopEnv.Bold, 20, () =>
            {
                Menu.Open = !Menu.Open;
            });
        }

        public override void Display()
        {
            DesktopEnv.MainCanvas.DrawFilledRectangle(CatppuccinMocha.Crust, X, Y, (int)DesktopEnv.MainCanvas.Mode.Width - X, Height);
            MenuBtn.Display();
            Menu.Display();
        }

        public override void Update()
        {
            
        }
    }
}
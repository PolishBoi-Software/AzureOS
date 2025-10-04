using System;
using PBOS.System.Core.Desktop;

namespace PBOS.System.Core.Commands
{
    public class GuiCmd : Command
    {
        public override string Name => "gui";

        public override string Description => "Enables graphical mode.";

        public override CommandResult Run(ParsedArgs args)
        {
            DesktopEnv.Init();
            return CommandResult.Success;
        }
    }
}
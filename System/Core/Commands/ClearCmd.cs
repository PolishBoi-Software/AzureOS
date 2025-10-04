using System;

namespace PBOS.System.Core.Commands
{
    public class ClearCmd : Command
    {
        public override string Name => "clear";

        public override string Description => "Clears the screen.";

        public override CommandResult Run(ParsedArgs args)
        {
            Console.Clear();
            return CommandResult.Success;
        }
    }
}
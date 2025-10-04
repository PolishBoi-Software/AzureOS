using System;

namespace PBOS.System.Core.Commands
{
    public class HelpCmd : Command
    {
        public override string Name => "help";

        public override string Description => "Displays all of the commands.";

        public override CommandResult Run(ParsedArgs args)
        {
            for (int i = 0; i < CommandManager.Commands.Count; i++)
            {
                Command command = CommandManager.Commands[i];
                Console.WriteLine($"{i + 1}. {command.Name} - {command.Description}");
            }
            
            return CommandResult.Success;
        }
    }
}
using System;

namespace AzureOS.System.Core.Commands
{
    public class EchoCmd : Command
    {
        public override string Name => "echo";

        public override string Description => "Displays a string of text.";

        public override CommandResult Run(ParsedArgs args)
        {
            string buff = "";
            foreach (var option in args.Options)
            {
                buff += $"{option} ";
            }
            Console.WriteLine(buff);
            return CommandResult.Success;
        }
    }
}
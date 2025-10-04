using System;
using System.IO;
using AzureOS.System.Terminal;
using AzureOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace AzureOS.System.Core.Commands
{
    public class DateTimeCmd : Command
    {
        public override string Name => "datetime";

        public override string Description => "Displays the current date and time.";

        public override CommandResult Run(ParsedArgs args)
        {
            string dateTimeStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Console.WriteLine(dateTimeStr);
            return CommandResult.Success;
        }
    }
}
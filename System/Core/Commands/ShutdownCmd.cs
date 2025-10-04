using System;
using System.IO;
using AzureOS.System.Terminal;
using AzureOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace AzureOS.System.Core.Commands
{
    public class ShutdownCmd : Command
    {
        public override string Name => "shutdown";

        public override string Description => "Turns off the computer.";

        public override CommandResult Run(ParsedArgs args)
        {
            Kernel.Shutdown();
            return CommandResult.Success;
        }
    }
}
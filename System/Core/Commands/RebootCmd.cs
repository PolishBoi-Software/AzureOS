using System;
using System.IO;
using AzureOS.System.Terminal;
using AzureOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace AzureOS.System.Core.Commands
{
    public class RebootCmd : Command
    {
        public override string Name => "reboot";

        public override string Description => "Reboots the computer.";

        public override CommandResult Run(ParsedArgs args)
        {
            Kernel.Shutdown(true);
            return CommandResult.Success;
        }
    }
}
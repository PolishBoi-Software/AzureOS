using System;
using System.IO;
using PBOS.System.Terminal;
using PBOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace PBOS.System.Core.Commands
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
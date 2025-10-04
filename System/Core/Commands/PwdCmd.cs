using System;
using PBOS.System.Terminal;
using PBOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace PBOS.System.Core.Commands
{
    public class PwdCmd : Command
    {
        public override string Name => "pwd";

        public override string Description => "Displays the current working directory.";

        public override CommandResult Run(ParsedArgs args)
        {
            Console.WriteLine(DirUtils.GetCurrentDirectory());
            return CommandResult.Success;
        }
    }
}
using System;
using System.IO;
using AzureOS.System.Terminal;
using AzureOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace AzureOS.System.Core.Commands
{
    public class CdCmd : Command
    {
        public override string Name => "cd";

        public override string Description => "Changes the current working directory.";

        public override CommandResult Run(ParsedArgs args)
        {
            if (args.Options.Count == 0)
                return CommandResult.Error;

            try
            {
                DirUtils.ChangeCurrentDirectory(args.Options[0]);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LogType.Error);
                return CommandResult.Error;
            }
            
            return CommandResult.Success;
        }
    }
}
using System;
using System.IO;
using AzureOS.System.Terminal;
using AzureOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace AzureOS.System.Core.Commands
{
    public class MkdirCmd : Command
    {
        public override string Name => "mkdir";

        public override string Description => "Creates a new directory.";

        public override CommandResult Run(ParsedArgs args)
        {
            if (args.Options.Count == 0)
                return CommandResult.Error;

            string dirP = Path.Combine(DirUtils.GetCurrentDirectory(), args.Options[0]);

            if (!Directory.Exists(dirP))
            {
                try
                {
                    Directory.CreateDirectory(dirP);
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.ToString(), LogType.Error);
                    return CommandResult.Error;
                }
            }

            return CommandResult.Success;
        }
    }
}
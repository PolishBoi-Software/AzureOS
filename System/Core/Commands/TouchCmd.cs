using System;
using System.IO;
using AzureOS.System.Terminal;
using AzureOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace AzureOS.System.Core.Commands
{
    public class TouchCmd : Command
    {
        public override string Name => "touch";

        public override string Description => "Creates a new file.";

        public override CommandResult Run(ParsedArgs args)
        {
            if (args.Options.Count == 0)
                return CommandResult.Error;

            string fileP = Path.Combine(DirUtils.GetCurrentDirectory(), args.Options[0]);

            if (!File.Exists(fileP))
            {
                try
                {
                    File.Create(fileP).Close();
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
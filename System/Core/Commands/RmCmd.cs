using System;
using System.IO;
using PBOS.System.Terminal;
using PBOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace PBOS.System.Core.Commands
{
    public class RmCmd : Command
    {
        public override string Name => "rm";

        public override string Description => "Deletes a specified file.";

        public override CommandResult Run(ParsedArgs args)
        {
            if (args.Options.Count == 0)
                return CommandResult.Error;

            try
            {
                if (File.Exists(Path.Combine(DirUtils.GetCurrentDirectory(), args.Options[0])))
                {
                    File.Delete(Path.Combine(DirUtils.GetCurrentDirectory(), args.Options[0]));
                    return CommandResult.Success;   
                }
                Logger.Log($"Directory {args.Options[0]} not found!", LogType.Error);
                return CommandResult.Error;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LogType.Error);
                return CommandResult.Error;
            }
        }
    }
}
using System;
using System.IO;
using PBOS.System.Terminal;
using PBOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace PBOS.System.Core.Commands
{
    public class RmdirCmd : Command
    {
        public override string Name => "rmdir";

        public override string Description => "Deletes the specified directory.";

        public override CommandResult Run(ParsedArgs args)
        {
            if (args.Options.Count == 0)
                return CommandResult.Error;

            try
            {
                if (Directory.Exists(Path.Combine(DirUtils.GetCurrentDirectory(), args.Options[0])))
                {
                    Directory.Delete(Path.Combine(DirUtils.GetCurrentDirectory(), args.Options[0]), args.HasFlag("recursive"));
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
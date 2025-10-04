using System;
using System.IO;
using AzureOS.System.Terminal;
using AzureOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace AzureOS.System.Core.Commands
{
    public class CatCmd : Command
    {
        public override string Name => "cat";

        public override string Description => "Displays a file's contents.";

        public override CommandResult Run(ParsedArgs args)
        {
            if (args.Options.Count == 0)
                return CommandResult.Error;

            if (!File.Exists(Path.Combine(DirUtils.GetCurrentDirectory(), args.Options[0])))
            {
                Logger.Log($"File {args.Options[0]} not found!", LogType.Error);
                return CommandResult.Error;
            }

            string contents = File.ReadAllText(Path.Combine(DirUtils.GetCurrentDirectory(), args.Options[0]));
            Console.WriteLine(contents);
            
            return CommandResult.Success;
        }
    }
}
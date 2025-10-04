using System;
using System.IO;
using AzureOS.System.Terminal;
using AzureOS.System.VFSUtils;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace AzureOS.System.Core.Commands
{
    public class LsCmd : Command
    {
        public override string Name => "ls";

        public override string Description => "Lists all files and directories.";

        public override CommandResult Run(ParsedArgs args)
        {
            string dirP = string.Empty;
            if (args.Options.Count == 0)
            {
                dirP = DirUtils.GetCurrentDirectory();
            }
            else
            {
                if (args.HasFlag("all"))
                    dirP = DirUtils.GetRootPath();
                else
                    dirP = Path.Combine(DirUtils.GetCurrentDirectory(), args.Options[0]);
            }

            if (!Directory.Exists(dirP)) return CommandResult.Error;

            try
            {
                var dirs = Directory.GetDirectories(dirP);
                var files = Directory.GetFiles(dirP);

                foreach (var dir in dirs)
                {
                    Console.WriteLine($"[DIR] {dir}");
                }

                foreach (var file in files)
                {
                    Console.WriteLine($"      {file}");
                }

                Console.WriteLine();
                Console.WriteLine($"{dirs.Length} dir(s)");
                Console.WriteLine($"{files.Length} file(s)");

                return CommandResult.Success;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString(), LogType.Error);
                return CommandResult.Error;
            }
        }
    }
}
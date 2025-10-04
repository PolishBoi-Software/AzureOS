using System;
using PBOS.System.Terminal;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;

namespace PBOS.System.Core.Commands
{
    public class InfoCmd : Command
    {
        public override string Name => "info";

        public override string Description => "Displays system informaton.";

        public override CommandResult Run(ParsedArgs args)
        {
            Console.WriteLine($"PBOS {Information.Version}");
            Console.WriteLine($"CPU: {CPU.GetCPUBrandString()}");
            Console.WriteLine($"RAM: {GCImplementation.GetUsedRAM() / (1024 * 1024)} MB / {GCImplementation.GetAvailableRAM()} MB");
            Console.WriteLine($"Storage: {VFSManager.GetAvailableFreeSpace(@"0:\") / (1024 * 1024)} MB free of {VFSManager.GetTotalFreeSpace(@"0:\") / (1024 * 1024)} MB");
            if (args.HasFlag("disks"))
            {
                Console.WriteLine("Disks:");
                var disks = VFSManager.GetDisks();
                for (int i = 0; i < disks.Count; i++)
                {
                    Console.WriteLine($"    Disk {i + 1}:");
                    Console.WriteLine($"        Size: {disks[i].Size} bytes");
                    Console.WriteLine($"        Partitions:");
                    var partitions = disks[i].Partitions;
                    for (int p = 0; p < partitions.Count; p++)
                    {
                        Console.WriteLine($"            Partition {p + 1}:");
                        Console.WriteLine($"                Root path: {partitions[p].RootPath}");
                    }
                }   
            }
            return CommandResult.Success;
        }
    }
}
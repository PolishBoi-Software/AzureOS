using System;
using PBOS.System.Terminal;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.FAT;
using Cosmos.System.FileSystem.VFS;

namespace PBOS.System.VFSUtils
{
    public static class DiskUtils
    {
        public static void FormatDisk(int index, bool quick = true, bool reboot = false)
        {
            Disk disk = VFSManager.GetDisks()[index];
            
            if (disk.Partitions.Count == 0)
            {
                disk.CreatePartition((int)disk.Size / (1024 * 1024));
                disk.FormatPartition(index, "FAT32", quick);

                if (reboot) Cosmos.System.Power.Reboot();
            }
            else
            {
                if (Information.Debug)
                    Logger.Log($"Disk {index} doesn't require formatting.", LogType.Debug);
            }
        }
    }
}
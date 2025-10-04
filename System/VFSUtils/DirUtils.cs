using System;
using System.IO;

namespace PBOS.System.VFSUtils
{
    public static class DirUtils
    {
        private static string CurrentDirectory = @"0:\";
        public static string GetCurrentDirectory() => CurrentDirectory;
        public static string GetRootPath() => @"0:\";
        public static void ChangeCurrentDirectory(string newPath)
        {
            DirectoryInfo info = new DirectoryInfo(CurrentDirectory);

            if (newPath == CurrentDirectory || newPath == "." || newPath == GetRootPath() || string.IsNullOrEmpty(newPath))
                return;

            if (newPath == "..")
                CurrentDirectory = GetCurrentDirectoryParent();
            else if (Directory.Exists(Path.Combine(CurrentDirectory, newPath)))
                CurrentDirectory = Path.Combine(CurrentDirectory, newPath);
            else
                throw new DirectoryNotFoundException($"Directory {newPath} doesn't exist");
        }

        public static string GetCurrentDirectoryParent()
        {
            DirectoryInfo info = new DirectoryInfo(CurrentDirectory);

            return info.Parent != null ? info.Parent.FullName : GetRootPath(); 
        }
    }
}
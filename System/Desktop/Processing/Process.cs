using System;

namespace PBOS.System.Core.Desktop.Processing
{
    public abstract class Process
    {
        public WindowData Window;
        public string Name { get; set; }
        public abstract void Start();
        public abstract void Run();
        public abstract void OnExit();
    }
}
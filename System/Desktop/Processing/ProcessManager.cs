using System;
using System.Collections.Generic;
using Cosmos.HAL;

namespace PBOS.System.Core.Desktop.Processing
{
    public static class ProcessManager
    {
        public static List<Process> Processes { get; set; } = new List<Process>();

        public static void Start(Process baseProc, WindowData data, string name)
        {
            Process newProc = baseProc;
            newProc.Name = name;
            newProc.Window = data;
            Start(newProc);
        }

        public static void Start(Process proc)
        {
            Processes.Add(proc);
            proc.Start();
        }

        public static void Update()
        {
            for (int i = Processes.Count - 1; i >= 0; i--)
            {
                Process proc = Processes[i];
                proc.Run();
            }
        }

        private static Process GetProcess(Process proc)
        {
            foreach (var process in Processes)
            {
                if (process == proc)
                    return process;
            }
            return null;
        }

        public static void Kill(Process proc)
        {
            if (GetProcess(proc) == null)
                return;

            proc.OnExit();
            Processes.Remove(proc);
        }
    }
}
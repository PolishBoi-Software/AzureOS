using System;
using System.Collections.Generic;

namespace PBOS.System.Core
{
    public class ParsedArgs
    {
        public string CommandName { get; set; }
        public List<string> Options { get; set; }
        public List<string> Flags { get; set; }

        public ParsedArgs()
        {
            CommandName = string.Empty;
            Flags = new List<string>();
            Options = new List<string>();
        }

        public bool HasFlag(string flag)
        {
            foreach (string f in Flags)
            {
                if (f == flag)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
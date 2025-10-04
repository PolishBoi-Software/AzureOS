using System;

namespace PBOS.System.Core
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract CommandResult Run(ParsedArgs args);
    }
}
using System;
using System.Collections.Generic;
using AzureOS.System.Core.Commands;
using AzureOS.System.Terminal;

namespace AzureOS.System.Core
{
    public static class CommandManager
    {
        public static List<Command> Commands { get; set; } = new List<Command>();

        public static void Register(Command command)
        {
            Commands.Add(command);
        }

        public static Command GetCommand(string name)
        {
            foreach (var cmd in Commands)
            {
                if (cmd.Name == name)
                {
                    return cmd;
                }
            }
            return null;
        }

        public static Command GetClosestCommand(string name)
        {
            foreach (var command in Commands)
            {
                if (command.Name.StartsWith(name))
                {
                    return command;
                }
            }
            return null;
        }

        public static CommandResult Run(ParsedArgs parsed)
        {
            Command cmd = GetCommand(parsed.CommandName);
            if (cmd == null) return CommandResult.NotFound;

            return cmd.Run(parsed);
        }

        public static void RegisterAll()
        {
            Register(new EchoCmd());
            Register(new HelpCmd());
            Register(new ClearCmd());
            Register(new InfoCmd());
            Register(new PwdCmd());
            Register(new CdCmd());
            Register(new LsCmd());
            Register(new RmdirCmd());
            Register(new MkdirCmd());
            Register(new TouchCmd());
            Register(new RebootCmd());
            Register(new ShutdownCmd());
            Register(new RmCmd());
            Register(new DateTimeCmd());
            Register(new CatCmd());
        }
    }
}
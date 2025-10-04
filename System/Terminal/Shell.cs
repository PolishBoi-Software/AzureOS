using System;
using AzureOS.System.Core;
using AzureOS.System.VFSUtils;
using CosmosUsers;

namespace AzureOS.System.Terminal
{
    public static class Shell
    {
        public static void Start()
        {
            Cosmos.System.PCSpeaker.Beep(Cosmos.System.Notes.A5, Cosmos.System.Durations.Eighth);
            Cosmos.System.PCSpeaker.Beep(Cosmos.System.Notes.E5, Cosmos.System.Durations.Eighth);
            Cosmos.System.PCSpeaker.Beep(Cosmos.System.Notes.A5, Cosmos.System.Durations.Eighth);
            Cosmos.System.PCSpeaker.Beep(Cosmos.System.Notes.B5, Cosmos.System.Durations.Quarter);
            Cosmos.System.PCSpeaker.Beep(Cosmos.System.Notes.A5, Cosmos.System.Durations.Quarter);
            Console.WriteLine($"Welcome to AzureOS {Information.Version}!");
        }

        public static void PrintPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{Kernel.CurrentUser.Name}");
            Console.ResetColor();
            Console.Write("~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(DirUtils.GetCurrentDirectory());
            Console.ResetColor();
            Console.Write("-> ");
        }

        public static void RunCommand(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                var parsed = ArgParser.Parse(input);
                var result = CommandManager.Run(parsed);
                switch (result)
                {
                    case CommandResult.Success:
                        if (Information.Debug)
                            Logger.Log($"Command {parsed.CommandName} ran successfully.", LogType.Debug);

                        break;

                    case CommandResult.Error:
                        Logger.Log($"Command {parsed.CommandName} didn't run successfully.", LogType.Error);
                        break;

                    case CommandResult.NotFound:
                        Logger.Log($"Command '{parsed.CommandName}' not found!", LogType.Error);
                        var cmd = CommandManager.GetClosestCommand(parsed.CommandName);
                        if (cmd != null)
                            Logger.Log($"Perhaps you meant '{cmd.Name}'?", LogType.Info);
                        break;
                }
            }
        }

        public static void AskUser()
        {
            bool usernameEntered = false;
            string uname = string.Empty;
            
            for (int i = 0; i < UserManager.Users.Count; i++)
            {
                var user = UserManager.Users[i];
                Console.WriteLine($"{i + 1}. {user.Name}");
            }

            while (true)
            {
                if (!usernameEntered)
                {
                    Console.Write("Username: ");
                    uname = Console.ReadLine().Trim();
                    if (!UserManager.Exists(uname))
                    {
                        Logger.Log($"User {uname} not found!", LogType.Error);
                        continue;
                    }
                }
                Console.Write("Password: ");
                var passwd = Console.ReadLine();
                var user = UserManager.AuthUser(uname, passwd);
                if (user == null)
                {
                    Logger.Log("Invalid password.", LogType.Error);
                    continue;
                }
                else
                {
                    Kernel.CurrentUser = user;
                    break;
                }
            }
        }
    }
}
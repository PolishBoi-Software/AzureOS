using System;
using System.Collections.Generic;

namespace PBOS.System.Terminal
{
    public static class Logger
    {
        public static void Log(string message, LogType type)
        {
            Console.ForegroundColor = type switch
            {
                LogType.OK => ConsoleColor.Red,

                LogType.Error => ConsoleColor.Red,

                LogType.Warning => ConsoleColor.Yellow,

                LogType.Info => ConsoleColor.Cyan,

                LogType.Debug => ConsoleColor.Blue,
            };

            string typeId = type switch
            {
                LogType.OK => "[ OKAY ]",

                LogType.Error => "[ FAIL ]",

                LogType.Warning => "[ WARN ]",

                LogType.Info => "[ INFO ]",

                LogType.Debug => "[ DEBG ]"
            };

            Console.Write($"{typeId} > ");
            Console.ResetColor();
            Console.WriteLine(message);
        }
    }
}
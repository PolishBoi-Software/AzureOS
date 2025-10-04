using System;

namespace PBOS.System.Terminal
{
    public static class TermUtils
    {
        private static string CenterMessage(string msg)
        {
			int padding = (Console.WindowWidth - msg.Length) / 2;
			string centeredText = msg.PadLeft(padding + msg.Length).PadRight(Console.WindowWidth);
			return centeredText;
        }

        public static void WriteCenter(string msg)
        {
            string[] lines = msg.Split('\n');

            foreach (var line in lines)
                Console.WriteLine(CenterMessage(line));
        }
    }
}
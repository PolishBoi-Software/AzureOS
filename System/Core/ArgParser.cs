using System;
using System.Collections.Generic;
using System.Text;

namespace AzureOS.System.Core
{
    public static class ArgParser
    {
        private static string[] ParseQuotes(string input)
        {
            List<string> list = new List<string>();
            int i = 0;
            while (i < input.Length)
            {
                while (i < input.Length && char.IsWhiteSpace(input[i]))
                {
                    i++;
                }
                if (i >= input.Length)
                {
                    break;
                }
                if (input[i] == '"')
                {
                    i++;
                    int start = i;
                    while (i < input.Length && input[i] != '"')
                    {
                        i++;
                    }
                    list.Add(input.Substring(start, i - start));
                    if (i < input.Length && input[i] == '"')
                    {
                        i++;
                    }
                }
                else
                {
                    int start = i;
                    while (i < input.Length && !char.IsWhiteSpace(input[i]))
                    {
                        i++;
                    }
                    list.Add(input.Substring(start, i - start));
                }
            }
            return list.ToArray();
        }

        public static ParsedArgs Parse(string input)
        {
            string[] parsed = ParseQuotes(input);
            ParsedArgs output = new ParsedArgs();
            if (string.IsNullOrEmpty(input)) return output;
            output.CommandName = parsed[0].ToLower();

            for (int i = 1; i < parsed.Length; i++)
            {
                if (parsed[i].StartsWith("--"))
                {
                    output.Flags.Add(parsed[i].Substring(2));
                }
                else
                {
                    output.Options.Add(parsed[i]);
                }
            }
            
            return output;
        }
    }
}
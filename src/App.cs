using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JsonConfig;

namespace fk
{
    public class App
    {
        IEnumerable<string> History => File.ReadAllLines(Config.User.bash_history_location);

        string LatestHistory => History.LastOrDefault();

        readonly string[] ProgramNameHomonyms = Config.User.programNameHomonyms;

        string[] Commands => Config.User.Commands;

        internal void Run()
        {
            var command = GetBestMachedCommand(LatestHistory);

            if (command!=null)
            {
                RunCommand(command);
            }
        }

        public Command ProjectToCommand(string input)
        {

            var commandParts = input.Split(' ').ToList();

            var program = commandParts.Count > 0 ? commandParts[0] : string.Empty;
            var action = commandParts.Count > 1 ? commandParts[1] : string.Empty;
            var arguments = commandParts.Count > 2
                ? string.Join(" ", commandParts.GetRange(2, commandParts.Count - 2).ToList())
                : string.Empty;

            return new Command(program, action, arguments);
        }

        public Command GetBestMachedCommand(string input)
        {
            var command = ProjectToCommand(input);

            var isValidProgram = ProgramNameHomonyms.Any(x => command.Program.StartsWith(x));
            if (!isValidProgram)
            {
                Console.Write($"Hey genius, I am not able to find a match for '{command.Action}' ");
                return null;
            }

            var actionRecommendations = Commands
                .Select(x => new ActionDistance
                {
                    Action = x,
                    Distance = Fastenshtein.Levenshtein.Distance(x, command.Action??command.Program)
                }).OrderBy(x => x.Distance)
                .Select(x => x.Action);

            var bestMatchedAction = actionRecommendations.FirstOrDefault();

            return new Command(command.Program, bestMatchedAction, command.Arguments);
        }

        private static void RunCommand(Command command)
        {
            Console.WriteLine($"Executing [{command}]");
            var startInfo = new ProcessStartInfo("cmd.exe")
            {
                Arguments = "/C " + command,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var p = Process.Start(startInfo);
            var processOutput = p.StandardOutput.ReadToEnd();
            var processError = p.StandardError.ReadToEnd();
            p.WaitForExit();
            Console.WriteLine(processOutput);
            Console.WriteLine(processError);
        }
    }
}
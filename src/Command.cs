using System.Collections.Generic;
using System.Linq;

namespace fk
{
    public sealed class Command
    {
        public Command(string program, string action, string arguments)
        {
            Program = program;
            Action = action;
            Arguments = arguments;
        }

        public string Program { get; }
        public string Action { get; }
        public string Arguments { get; }
        public override string ToString()
        {
            return Program + " " + Action + " " + Arguments;
        }
    }
}
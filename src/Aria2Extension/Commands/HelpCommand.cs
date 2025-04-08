using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Aria2Extension.Commands
{
    internal partial class HelpCommand: InvokableCommand
    {
        public HelpCommand()
        {
            Icon = new IconInfo("\uE897");
            Name = "Help";
        }

        public override ICommandResult Invoke()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/k aria2c --help", // Use /k to keep the shell open
                UseShellExecute = true,
                CreateNoWindow = false
            };

            using var process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            return CommandResult.KeepOpen();
        }
    }
}

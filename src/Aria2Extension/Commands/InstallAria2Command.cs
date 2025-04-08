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
    internal partial class InstallAria2Command : InvokableCommand
    {
        public InstallAria2Command()
        {
            Icon = new IconInfo("\uE896");
            Name = "Install Aria2";
        }

        public override ICommandResult Invoke()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/k winget install aria2.aria2",
                UseShellExecute = true,
                CreateNoWindow = false
            };

            using var process = new Process(); 
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            return CommandResult.GoHome();
        }
    }
}

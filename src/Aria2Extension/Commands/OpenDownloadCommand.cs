using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aria2Extension.Pages;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Aria2Extension.Commands
{
    internal partial class OpenDownloadCommand:InvokableCommand
    {
        public OpenDownloadCommand()
        {
            Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
            Name = "Open Download";
        }

        public override ICommandResult Invoke()
        {
            var goToPageArgs = new GoToPageArgs
            {
                PageId = "DownloadFormPage"
            };

            CommandResult.KeepOpen();
            return CommandResult.GoToPage(goToPageArgs);
        }
    }
}

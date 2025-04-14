// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Aria2Extension.Commands;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System.Diagnostics;

namespace Aria2Extension.Pages;

internal sealed partial class Aria2ExtensionPage : ListPage
{
    public Aria2ExtensionPage()
    {
        // Retrieve the version number from the package manifest
        var version = Windows.ApplicationModel.Package.Current.Id.Version;
        var versionString = $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";

        Icon = new IconInfo("\uEBD3");
        Title = $"Aria2 v{versionString}";
        Name = "Open";
    }

    public override IListItem[] GetItems()
    {
        if (!IsAria2Installed())
        {
            return
            [
                new ListItem(new InstallAria2Command()) { Title = "Install Aria2" },
            ];
        }
        else
        {
            return
            [
                new ListItem(new DownloadFormPage()) { Title = "Download" },
                new ListItem(new HelpCommand()) { Title = "Help" }
            ];
        }
    }

    internal static bool IsAria2Installed()
    {
        try
        {
            using var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "aria2c",
                Arguments = "--version",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            process.Start();
            process.WaitForExit();
            return process.ExitCode == 0;
        }
        catch
        {
            return false;
        }
    }
}

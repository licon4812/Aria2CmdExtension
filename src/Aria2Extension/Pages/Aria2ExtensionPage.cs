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
        Icon = new IconInfo("\uEBD3");
        Title = "Aria2";
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

    internal bool IsAria2Installed()
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "winget",
            Arguments = "list aria2.aria2",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        var output = process.StandardOutput.ReadToEnd();
        var error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        // Check if the output contains "aria2.aria2"
        return output.Contains("aria2.aria2");
    }
}

// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System.Diagnostics;
using Aria2Extension.Commands;
using Aria2Extension.Pages;

namespace Aria2Extension;

public partial class Aria2ExtensionCommandsProvider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public Aria2ExtensionCommandsProvider()
    {
        DisplayName = "Aria2";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        if (!IsAria2Installed())
        {
            _commands = [
                new CommandItem(new Aria2ExtensionPage()) { Title = "Install Aria2" },
            ];
        }
        else
        {
            _commands = [
                new CommandItem(new DownloadFormPage()) { Title = $"{DisplayName}: Download" },
            ];

        }
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
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

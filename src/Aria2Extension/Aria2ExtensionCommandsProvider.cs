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
        // Include the version number in the DisplayName
        DisplayName = "Aria2";
        Icon = new IconInfo("\uEBD3");

        _commands = [
            new CommandItem(new Aria2ExtensionPage()) { Title = "Aria2", Subtitle = "Download files using Aria2" }
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }
}

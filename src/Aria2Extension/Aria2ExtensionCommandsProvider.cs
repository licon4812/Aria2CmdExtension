// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Aria2Extension;

public partial class Aria2ExtensionCommandsProvider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public Aria2ExtensionCommandsProvider()
    {
        DisplayName = "Aria2";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        _commands = [
            new CommandItem(new Aria2ExtensionPage()) { Title = DisplayName },
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }

}

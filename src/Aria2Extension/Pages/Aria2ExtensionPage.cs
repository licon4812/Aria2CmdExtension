// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Aria2Extension.Commands;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Aria2Extension.Pages;

internal sealed partial class Aria2ExtensionPage : ListPage
{
    public Aria2ExtensionPage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        Title = "Aria2";
        Name = "Open";
    }

    public override IListItem[] GetItems()
    {
        return
        [
            new ListItem(new InstallAria2Command()) { Title = "Install Aria2" },
        ];
    }
}

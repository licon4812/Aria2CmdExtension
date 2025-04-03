// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Aria2Extension;

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
        return [
            new ListItem(new NoOpCommand()) { Title = "TODO: Implement your extension here" }
        ];
    }
}

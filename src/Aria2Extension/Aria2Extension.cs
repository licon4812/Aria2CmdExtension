// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.CommandPalette.Extensions;

namespace Aria2Extension;

[Guid("0437f44c-1c35-4caf-b94a-d0faf465abc9")]
public sealed partial class Aria2Extension(ManualResetEvent extensionDisposedEvent) : IExtension, IDisposable
{
    private readonly Aria2ExtensionCommandsProvider _provider = new();

    public object? GetProvider(ProviderType providerType)
    {
        return providerType switch
        {
            ProviderType.Commands => _provider,
            _ => null,
        };
    }

    public void Dispose() => extensionDisposedEvent.Set();
}

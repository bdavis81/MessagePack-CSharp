// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Reflection;
using Microsoft;

namespace MessagePack.Generator.Tests;

internal static class TestUtilities
{
    /// <summary>
    /// Fetches the static instance of the named resolver, by its <see langword="public" /> <see langword="static"/> <c>Instance</c> property.
    /// </summary>
    /// <param name="assembly">The assembly to retrieve the resolver from.</param>
    /// <param name="name">The full name of the resolver.</param>
    /// <returns>The resolver.</returns>
    internal static IFormatterResolver GetResolverInstance(Assembly assembly, string name)
    {
        Type? resolverType = assembly.GetType(name);
        Requires.Argument(resolverType is not null, nameof(name), "No type with the given name found.");
        FieldInfo? instanceField = resolverType.GetField("Instance", BindingFlags.Static | BindingFlags.Public);
        Assert.NotNull(instanceField);
        object? instanceValue = instanceField.GetValue(null);
        Assert.NotNull(instanceValue);
        return (IFormatterResolver)instanceValue;
    }
}

/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;
using Xunit;

namespace Finos.Fdc3.AppDirectory.Tests;

public class IntentsTests
{
    [Fact]
    public void Intents_Properties_CanBeSetAndGet()
    {
        // Arrange
        var intents = new Intents();
        var listensFor = new Dictionary<string, IntentMetadata>
        {
            { "ViewChart", new IntentMetadata("ViewChart", "View Chart", new[] { "fdc3.instrument" }) },
            { "ViewContact", new IntentMetadata("ViewContact", "View Contact", new[] { "fdc3.contact" }) }
        };
        var raises = new Dictionary<string, IEnumerable<string>>
        {
            { "StartChat", new[] { "fdc3.contact", "fdc3.organization" } },
            { "ViewNews", new[] { "fdc3.instrument", "fdc3.organization" } }
        };

        // Act
        intents.ListensFor = listensFor;
        intents.Raises = raises;

        // Assert
        Assert.Equal(listensFor, intents.ListensFor);
        Assert.Equal(raises, intents.Raises);
    }

    [Fact]
    public void Intents_Properties_CanBeNull()
    {
        // Arrange & Act
        var intents = new Intents();

        // Assert
        Assert.Null(intents.ListensFor);
        Assert.Null(intents.Raises);
    }

    [Fact]
    public void Intents_Properties_CanBeEmpty()
    {
        // Arrange
        var intents = new Intents();
        var emptyListensFor = new Dictionary<string, IntentMetadata>();
        var emptyRaises = new Dictionary<string, IEnumerable<string>>();

        // Act
        intents.ListensFor = emptyListensFor;
        intents.Raises = emptyRaises;

        // Assert
        Assert.Empty(intents.ListensFor);
        Assert.Empty(intents.Raises);
    }
}

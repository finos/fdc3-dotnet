/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using System.Collections.Generic;
using Xunit;

namespace Finos.Fdc3.AppDirectory.Tests;

public class IntentMetadataTests
{
    [Fact]
    public void IntentMetadata_Constructor_SetsProperties()
    {
        // Arrange
        var name = "ViewChart";
        var displayName = "View Chart";
        var contexts = new[] { "fdc3.instrument", "fdc3.position" };

        // Act
#pragma warning disable CS0618 // Type or member is obsolete
        var metadata = new IntentMetadata(name, displayName, contexts);

        // Assert
        Assert.Equal(name, metadata.Name);
        Assert.Equal(displayName, metadata.DisplayName);
#pragma warning restore CS0618 // Type or member is obsolete
        Assert.Equal(contexts, metadata.Contexts);
    }

    [Fact]
    public void IntentMetadata_Constructor_WithNullContexts_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new IntentMetadata("ViewChart", "View Chart", null!));
    }

    [Fact]
    public void IntentMetadata_Constructor_WithEmptyContexts_Succeeds()
    {
        // Arrange & Act
        var metadata = new IntentMetadata("ViewChart", "View Chart", Array.Empty<string>());

        // Assert
        Assert.NotNull(metadata.Contexts);
        Assert.Empty(metadata.Contexts);
    }
}

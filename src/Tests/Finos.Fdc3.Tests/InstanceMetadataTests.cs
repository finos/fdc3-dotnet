/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;
using Xunit;

namespace Finos.Fdc3.Tests;

public class InstanceMetadataTests
{
    [Fact]
    public void InstanceMetadata_Constructor_Empty()
    {
        // Act
        IInstanceMetadata instance = new InstanceMetadata();

        // Assert
        Assert.NotNull(instance);
        Assert.Empty(instance);
    }

    [Fact]
    public void InstanceMetadata_Constructor_WithDictionary()
    {
        // Arrange
        var metadata = new Dictionary<string, object>
        {
            { "windowId", "window123" },
            { "processId", 12345 }
        };

        // Act
        IInstanceMetadata instance = new InstanceMetadata(metadata);

        // Assert
        Assert.NotNull(instance);
        Assert.Equal(2, instance.Count);
        Assert.Equal("window123", instance["windowId"]);
        Assert.Equal(12345, instance["processId"]);
    }

    [Fact]
    public void InstanceMetadata_Constructor_WithNull()
    {
        // Act
        IInstanceMetadata instance = new InstanceMetadata(null);

        // Assert
        Assert.NotNull(instance);
        Assert.Empty(instance);
    }

    [Fact]
    public void InstanceMetadata_DictionaryInterface_Add()
    {
        // Arrange
        IInstanceMetadata instance = new InstanceMetadata();

        // Act
        instance["windowId"] = "window123";
        instance["processId"] = 12345;

        // Assert
        Assert.Equal(2, instance.Count);
        Assert.Equal("window123", instance["windowId"]);
        Assert.Equal(12345, instance["processId"]);
    }

    [Fact]
    public void InstanceMetadata_DictionaryInterface_Remove()
    {
        // Arrange
        var metadata = new Dictionary<string, object>
        {
            { "windowId", "window123" },
            { "processId", 12345 }
        };
        IInstanceMetadata instance = new InstanceMetadata(metadata);

        // Act
        instance.Remove("processId");

        // Assert
        Assert.Single(instance);
        Assert.True(instance.ContainsKey("windowId"));
        Assert.False(instance.ContainsKey("processId"));
    }

    [Fact]
    public void InstanceMetadata_PreservesTypes()
    {
        // Arrange
        var metadata = new Dictionary<string, object>
        {
            { "stringValue", "test" },
            { "intValue", 42 },
            { "doubleValue", 3.14 },
            { "boolValue", true }
        };

        // Act
        IInstanceMetadata instance = new InstanceMetadata(metadata);

        // Assert
        Assert.Equal("test", instance["stringValue"]);
        Assert.Equal(42, instance["intValue"]);
        Assert.Equal(3.14, instance["doubleValue"]);
        Assert.Equal(true, instance["boolValue"]);
    }

    [Fact]
    public void InstanceMetadata_ImplementsIDictionary()
    {
        // Arrange
        var instance = new InstanceMetadata();

        // Assert
        Assert.IsAssignableFrom<IDictionary<string, object>>(instance);
    }
}

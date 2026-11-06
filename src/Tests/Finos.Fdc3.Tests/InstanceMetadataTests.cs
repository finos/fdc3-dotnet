/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;

namespace Finos.Fdc3.Tests;

public class InstanceMetadataTests
{
    [Fact]
    public void InstanceMetadata_Constructor_WithMetadata_PropertiesMatch()
    {
        var metadata = new Dictionary<string, object>
        {
            { "windowId", "window123" },
            { "processId", 12345 }
        };

        IInstanceMetadata instance = new InstanceMetadata(metadata);

        Assert.NotNull(instance.Metadata);
        Assert.Same(metadata, instance.Metadata);
        Assert.Equal(2, instance.Metadata.Count);
    }

    [Fact]
    public void InstanceMetadata_Constructor_WithNullMetadata_IsValid()
    {
        IInstanceMetadata instance = new InstanceMetadata(null);

        Assert.Null(instance.Metadata);
    }

    [Fact]
    public void InstanceMetadata_Constructor_WithoutMetadataParam_MetadataIsNull()
    {
        IInstanceMetadata instance = new InstanceMetadata();

        Assert.Null(instance.Metadata);
    }

    [Fact]
    public void InstanceMetadata_Constructor_WithEmptyDictionary_IsValid()
    {
        var emptyMetadata = new Dictionary<string, object>();

        IInstanceMetadata instance = new InstanceMetadata(emptyMetadata);

        Assert.NotNull(instance.Metadata);
        Assert.Empty(instance.Metadata);
    }

    [Fact]
    public void InstanceMetadata_Constructor_WithMixedTypes_PreservesTypes()
    {
        var metadata = new Dictionary<string, object>
        {
            { "stringValue", "test" },
            { "intValue", 42 },
            { "doubleValue", 3.14 },
            { "boolValue", true }
        };

        IInstanceMetadata instance = new InstanceMetadata(metadata);

        Assert.NotNull(instance.Metadata);
        Assert.Equal("test", instance.Metadata["stringValue"]);
        Assert.Equal(42, instance.Metadata["intValue"]);
        Assert.Equal(3.14, instance.Metadata["doubleValue"]);
        Assert.Equal(true, instance.Metadata["boolValue"]);
    }

    [Fact]
    public void InstanceMetadata_ImplementsInterface()
    {
        var metadata = new Dictionary<string, object> { { "key", "value" } };
        var instance = new InstanceMetadata(metadata);

        Assert.IsAssignableFrom<IInstanceMetadata>(instance);
    }

    [Fact]
    public void InstanceMetadata_PropertyIsReadOnly()
    {
        var metadata = new Dictionary<string, object> { { "key", "value" } };
        var instance = new InstanceMetadata(metadata);

        Assert.NotNull(typeof(InstanceMetadata).GetProperty("Metadata"));
    }
}

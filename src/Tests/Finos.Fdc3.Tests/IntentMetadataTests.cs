/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

public class IntentMetadataTests
{
    [Fact]
    public void IntentMetadata_NullName_ArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS0612 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
        Assert.Throws<ArgumentNullException>(() => new IntentMetadata(null, "displayname"));
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void IntentMetadata_PropertiesMatchParamsFromCtor1()
    {
        IIntentMetadata metadata = new IntentMetadata("name");
        Assert.Same("name", metadata.Name);
#pragma warning disable CS0618 // Type or member is obsolete
        Assert.Null(metadata.DisplayName);
#pragma warning restore CS0618 // Type or member is obsolete
    }


    [Fact]
    public void IntentMetadata_PropertiesMatchParamsFromCtor2()
    {
#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0612 // Type or member is obsolete
        IIntentMetadata metadata = new IntentMetadata("name", "displayname");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
        Assert.Same("name", metadata.Name);
#pragma warning disable CS0618 // Type or member is obsolete
        Assert.Same("displayname", metadata.DisplayName);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
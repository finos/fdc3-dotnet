/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Xunit.Sdk;

namespace Finos.Fdc3.Tests;

public class ImplementationMetadataTests
{
    [Fact]
    public void ImplementationMetadata_NullFdc3Version_ArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new ImplementationMetadata(null, "provider", "providerversion", new OptionalDesktopAgentFeatures(), new AppMetadata("appid")));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void ImplementationMetadata_NullProvider_ArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new ImplementationMetadata("fdc3version", null, "providerversion", new OptionalDesktopAgentFeatures(), new AppMetadata("appid")));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void ImplementationMetadata_NullProviderVersion_ArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new ImplementationMetadata("fdc3version", "provider", null, new OptionalDesktopAgentFeatures(), new AppMetadata("appid")));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void ImplementationMetadata_NullOptionalFeatures_ArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new ImplementationMetadata("fdc3version", "provider", "providerversion", null, new AppMetadata("appid")));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void ImplementationMetadata_NullAppMetadata_ArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new ImplementationMetadata("fdc3version", "provider", "providerversion", new OptionalDesktopAgentFeatures(), null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void ImplementationMetadata_PropertiesMatchParams()
    {
        OptionalDesktopAgentFeatures features= new OptionalDesktopAgentFeatures();
        IAppMetadata appMetadata = new AppMetadata("appid");
        IImplementationMetadata metadata = new ImplementationMetadata("fdc3version", "provider", "providerversion", features, appMetadata);
        Assert.Same("fdc3version", metadata.Fdc3Version);
        Assert.Same("provider", metadata.Provider);
        Assert.Same("providerversion", metadata.ProviderVersion);
        Assert.Same(features, metadata.OptionalFeatures);
        Assert.Same(appMetadata, metadata.AppMetadata);
    }
}
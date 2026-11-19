/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests;

public class ContextWithMetadataTests
{
    [Fact]
    public void ContextWithMetadata_Constructor_PropertiesMatchParams()
    {
        var context = new Contact(new ContactID { Email = "test@example.com" }, "Test Contact");
        var appId = new AppIdentifier("myapp");
        var metadata = new ContextMetadata(appId, DateTime.UtcNow, Guid.NewGuid().ToString());

        IContextWithMetadata wrapper = new ContextWithMetadata(context, metadata);

        Assert.Same(context, wrapper.Context);
        Assert.Same(metadata, wrapper.Metadata);
    }

    [Fact]
    public void ContextWithMetadata_Constructor_WithNullContext_ThrowsArgumentNullException()
    {
        var appId = new AppIdentifier("myapp");
        var metadata = new ContextMetadata(appId, DateTime.UtcNow, Guid.NewGuid().ToString());

        var exception = Assert.Throws<ArgumentNullException>(() =>
            new ContextWithMetadata(null!, metadata)
        );

        Assert.Equal("context", exception.ParamName);
    }

    [Fact]
    public void ContextWithMetadata_Constructor_WithNullMetadata_ThrowsArgumentNullException()
    {
        var context = new Contact(new ContactID { Email = "test@example.com" }, "Test Contact");

        var exception = Assert.Throws<ArgumentNullException>(() =>
            new ContextWithMetadata(context, null!)
        );

        Assert.Equal("metadata", exception.ParamName);
    }

    [Fact]
    public void ContextWithMetadata_DifferentContexts_WorkCorrectly()
    {
        var contact = new Contact(new ContactID { Email = "contact@example.com" }, "Contact");
        var organization = new Organization(new OrganizationID { FDS_ID = "org456" }, "Organization");
        var appId = new AppIdentifier("myapp");
        var metadata1 = new ContextMetadata(appId, DateTime.UtcNow, Guid.NewGuid().ToString());
        var metadata2 = new ContextMetadata(appId, DateTime.UtcNow, Guid.NewGuid().ToString());

        var wrapper1 = new ContextWithMetadata(contact, metadata1);
        var wrapper2 = new ContextWithMetadata(organization, metadata2);

        Assert.IsType<Contact>(wrapper1.Context);
        Assert.IsType<Organization>(wrapper2.Context);
        Assert.NotEqual(wrapper1.Metadata.TraceId, wrapper2.Metadata.TraceId);
    }

    [Fact]
    public void ContextWithMetadata_ImplementsInterface()
    {
        var context = new Contact(new ContactID { Email = "test@example.com" }, "Test Contact");
        var appId = new AppIdentifier("myapp");
        var metadata = new ContextMetadata(appId, DateTime.UtcNow, Guid.NewGuid().ToString());

        var wrapper = new ContextWithMetadata(context, metadata);

        Assert.IsAssignableFrom<IContextWithMetadata>(wrapper);
    }

    [Fact]
    public void ContextWithMetadata_PropertiesAreReadOnly()
    {
        var context = new Contact(new ContactID { Email = "test@example.com" }, "Test Contact");
        var appId = new AppIdentifier("myapp");
        var metadata = new ContextMetadata(appId, DateTime.UtcNow, Guid.NewGuid().ToString());

        var wrapper = new ContextWithMetadata(context, metadata);

        Assert.NotNull(typeof(ContextWithMetadata).GetProperty("Context"));
        Assert.NotNull(typeof(ContextWithMetadata).GetProperty("Metadata"));
    }
}

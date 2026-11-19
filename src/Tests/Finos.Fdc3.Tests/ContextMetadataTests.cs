/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

public class ContextMetadataTests
{
    [Fact]
    public void ContextMetadata_RequiredParams_SourceMatchesParam()
    {
        IAppIdentifier identifier = new AppIdentifier("appid");
        DateTime timestamp = DateTime.UtcNow;
        string traceId = Guid.NewGuid().ToString();
        
        IContextMetadata metadata = new ContextMetadata(identifier, timestamp, traceId);
        Assert.Same(identifier, metadata.Source);
        Assert.Equal(timestamp, metadata.Timestamp);
        Assert.Equal(traceId, metadata.TraceId);
    }

    [Fact]
    public void ContextMetadata_PropartiesMatchParams()
    {
        IAppIdentifier identifier = new AppIdentifier("appid");
        DateTime timestamp = DateTime.UtcNow;
        string traceId = Guid.NewGuid().ToString();
        
        IContextMetadata metadata = new ContextMetadata(identifier, timestamp, traceId);
        Assert.Same(identifier, metadata.Source);
        Assert.Equal(timestamp, metadata.Timestamp);
        Assert.Equal(traceId, metadata.TraceId);
    }

    [Fact]
    public void ContextMetadata_WithOptionalSignature()
    {
        IAppIdentifier identifier = new AppIdentifier("appid");
        DateTime timestamp = DateTime.UtcNow;
        string traceId = Guid.NewGuid().ToString();
        IDetachedSignature signature = new DetachedSignature("protected", "sig");

        IContextMetadata metadata = new ContextMetadata(identifier, timestamp, traceId, signature: signature);

        Assert.NotNull(metadata.Signature);
        Assert.Same(signature, metadata.Signature);
        Assert.Null(metadata.AntiReplay);
        Assert.Null(metadata.Custom);
    }

    [Fact]
    public void ContextMetadata_WithOptionalAntiReplay()
    {
        IAppIdentifier identifier = new AppIdentifier("appid");
        DateTime timestamp = DateTime.UtcNow;
        string traceId = Guid.NewGuid().ToString();
        IAntiReplayClaims antiReplay = new AntiReplayClaims(1000, 2000, "jti123");

        IContextMetadata metadata = new ContextMetadata(identifier, timestamp, traceId, antiReplay: antiReplay);

        Assert.NotNull(metadata.AntiReplay);
        Assert.Same(antiReplay, metadata.AntiReplay);
        Assert.Null(metadata.Signature);
        Assert.Null(metadata.Custom);
    }

    [Fact]
    public void ContextMetadata_WithOptionalCustom()
    {
        IAppIdentifier identifier = new AppIdentifier("appid");
        DateTime timestamp = DateTime.UtcNow;
        string traceId = Guid.NewGuid().ToString();
        var custom = new Dictionary<string, object> { { "key", "value" } };

        IContextMetadata metadata = new ContextMetadata(identifier, timestamp, traceId, custom: custom);

        Assert.NotNull(metadata.Custom);
        Assert.Same(custom, metadata.Custom);
        Assert.Null(metadata.Signature);
        Assert.Null(metadata.AntiReplay);
    }

    [Fact]
    public void ContextMetadata_WithAllOptionalParameters()
    {
        IAppIdentifier identifier = new AppIdentifier("appid");
        DateTime timestamp = DateTime.UtcNow;
        string traceId = Guid.NewGuid().ToString();
        IDetachedSignature signature = new DetachedSignature("protected", "sig");
        IAntiReplayClaims antiReplay = new AntiReplayClaims(1000, 2000, "jti123");
        var custom = new Dictionary<string, object> { { "key", "value" } };

        IContextMetadata metadata = new ContextMetadata(identifier, timestamp, traceId, signature, antiReplay, custom);

        Assert.NotNull(metadata.Signature);
        Assert.NotNull(metadata.AntiReplay);
        Assert.NotNull(metadata.Custom);
        Assert.Same(signature, metadata.Signature);
        Assert.Same(antiReplay, metadata.AntiReplay);
        Assert.Same(custom, metadata.Custom);
    }

    [Fact]
    public void ContextMetadata_NullSource_ThrowsArgumentNullException()
    {
        DateTime timestamp = DateTime.UtcNow;
        string traceId = Guid.NewGuid().ToString();

        var exception = Assert.Throws<ArgumentNullException>(() =>
            new ContextMetadata(null!, timestamp, traceId)
        );

        Assert.Equal("source", exception.ParamName);
    }

    [Fact]
    public void ContextMetadata_NullTraceId_ThrowsArgumentNullException()
    {
        IAppIdentifier identifier = new AppIdentifier("appid");
        DateTime timestamp = DateTime.UtcNow;

        var exception = Assert.Throws<ArgumentNullException>(() =>
            new ContextMetadata(identifier, timestamp, null!)
        );

        Assert.Equal("traceId", exception.ParamName);
    }

    [Fact]
    public void ContextMetadata_AsIAppProvidableContextMetadata_TraceId()
    {
        IAppIdentifier identifier = new AppIdentifier("appid");
        DateTime timestamp = DateTime.UtcNow;
        string traceId = Guid.NewGuid().ToString();

        IContextMetadata metadata = new ContextMetadata(identifier, timestamp, traceId);
        IAppProvidableContextMetadata appProvidable = metadata;

        Assert.Equal(traceId, appProvidable.TraceId);
    }
}
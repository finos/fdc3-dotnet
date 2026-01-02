/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

public class ContextMetadataTests
{
    [Fact]
    public void ContextMetadata_NoParams_NullSource()
    {
        Assert.Null(new ContextMetadata().Source);
    }

    [Fact]
    public void ContextMetadata_PropartiesMatchParams()
    {
        IAppIdentifier identifier = new AppIdentifier("appid");
        IContextMetadata metadata = new ContextMetadata(identifier);
        Assert.Same(identifier, metadata.Source);
    }
}
/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

public class IntentResolutionTests
{
    [Fact]
    public void IntentResolution_NullSource_ArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new MockIntentResolution(null, "intent", "version"));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void IntentResolution_NullIntent_ArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new MockIntentResolution(new AppMetadata("appid"), null, "version"));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void IntentResolution_NullVersion_NullVersion()
    {
        Assert.Null(new MockIntentResolution(new AppMetadata("appid"), "intent").Version);
    }

    [Fact]
    public void IntentResolution_PropertiesMatchParams()
    {
        IAppMetadata appMetadata = new AppMetadata("appid");
        IntentResolution intentResolution = new MockIntentResolution(appMetadata, "intent", "version");
        Assert.Same(appMetadata, intentResolution.Source);
        Assert.Same("intent", intentResolution.Intent);
        Assert.Same("version", intentResolution.Version);
    }

    public class MockIntentResolution : IntentResolution
    {
        public MockIntentResolution(IAppMetadata source, string intent, string? version = null)
            : base(source, intent, version)
        {
        }

        public override Task<IIntentResult?> GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
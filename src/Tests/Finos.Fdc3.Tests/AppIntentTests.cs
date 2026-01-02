/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

public class AppIntentTests
{
    [Fact]
    public void AppIntent_NullIntent_ThrowsArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new AppIntent(null, new[] { new AppMetadata("appid") }));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void AppIntent_NullApps_ThrowsArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS0612 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
        Assert.Throws<ArgumentNullException>(() => new AppIntent(new IntentMetadata("name", "displayName"), null));
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void AppIntent_NonNullParams_PropertyMatchesParam()
    {
#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0612 // Type or member is obsolete
        IIntentMetadata metadata = new IntentMetadata("name", "displayName");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
        IAppMetadata[] apps = { new AppMetadata("appid") };

        IAppIntent appIntent = new AppIntent(metadata, apps);
        Assert.Same(metadata, appIntent.Intent);
        Assert.Same(apps, appIntent.Apps);
    }
}
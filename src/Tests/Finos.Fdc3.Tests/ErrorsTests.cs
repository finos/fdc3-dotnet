/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Xunit;

namespace Finos.Fdc3.Tests;

public class ErrorsTests
{
    [Fact]
    public void OpenError_Constants_HaveCorrectValues()
    {
        Assert.Equal("AppNotFound", OpenError.AppNotFound);
        Assert.Equal("ErrorOnLaunch", OpenError.ErrorOnLaunch);
        Assert.Equal("AppTimeout", OpenError.AppTimeout);
        Assert.Equal("ResolverUnavailable", OpenError.ResolverUnavailable);
        Assert.Equal("MalformedContext", OpenError.MalformedContext);
    }

    [Fact]
    public void ResolveError_Constants_HaveCorrectValues()
    {
        Assert.Equal("NoAppsFound", ResolveError.NoAppsFound);
        Assert.Equal("ResolverUnavailable", ResolveError.ResolverUnavailable);
        Assert.Equal("ResolverTimeout", ResolveError.ResolverTimeout);
        Assert.Equal("UserCancelledResolution", ResolveError.UserCancelledResolution);
        Assert.Equal("TargetAppUnavailable", ResolveError.TargetAppUnavailable);
        Assert.Equal("TargetInstanceUnavailable", ResolveError.TargetInstanceUnavailable);
        Assert.Equal("IntentDeliveryFailed", ResolveError.IntentDeliveryFailed);
        Assert.Equal("MalformedContext", ResolveError.MalformedContext);
    }

    [Fact]
    public void ResultError_Constants_HaveCorrectValues()
    {
        Assert.Equal("NoResultReturned", ResultError.NoResultReturned);
        Assert.Equal("IntentHandlerRejected", ResultError.IntentHandlerRejected);
    }

    [Fact]
    public void ChannelError_Constants_HaveCorrectValues()
    {
        Assert.Equal("NoChannelFound", ChannelError.NoChannelFound);
        Assert.Equal("AccessDenied", ChannelError.AccessDenied);
        Assert.Equal("CreationFailed", ChannelError.CreationFailed);
        Assert.Equal("MalformedContext", ChannelError.MalformedContext);
    }
}

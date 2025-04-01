/*
 * Morgan Stanley makes this available to you under the Apache License, 
 * Version 2.0 (the "License"). You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0.
 *
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Unless required by applicable law or agreed
 * to in writing, software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions
 * and limitations under the License.
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

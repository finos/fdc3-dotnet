/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests;

public class IChannelTests
{
    [Fact]
    public void AddContextListener_InvokesAddContextListenerWithNullContextType()
    {
        MockChannel channel = new MockChannel();
#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        channel.AddContextListener<IContext>(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS0618 // Type or member is obsolete
        Assert.True(channel.AddContextListenerInvoked);
    }

    private class MockChannel : IChannel
    {
        internal bool AddContextListenerInvoked = false;

        public string Id => throw new NotImplementedException();

        public ChannelType Type => throw new NotImplementedException();

        public IDisplayMetadata? DisplayMetadata => throw new NotImplementedException();

        public Task<IListener> AddContextListener<T>(string? contextType, ContextHandler<T> handler) where T : IContext
        {
            this.AddContextListenerInvoked = true;
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public Task Broadcast(IContext context)
        {
            throw new NotImplementedException();
        }

        public Task<IContext?> GetCurrentContext(string? contextType)
        {
            throw new NotImplementedException();
        }
    }
}
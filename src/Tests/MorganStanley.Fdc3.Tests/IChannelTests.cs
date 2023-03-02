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

using MorganStanley.Fdc3.Context;

namespace MorganStanley.Fdc3.Tests;

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

        public string Type => throw new NotImplementedException();

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
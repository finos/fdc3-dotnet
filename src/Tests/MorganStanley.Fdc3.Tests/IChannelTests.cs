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
        channel.AddContextListener<IContext>(null);
        Assert.True(channel.AddContextListenerInvoked);
    }

    private class MockChannel : IChannel
    {
        internal bool AddContextListenerInvoked = false;

        public string Id => throw new NotImplementedException();

        public string Type => throw new NotImplementedException();

        public IDisplayMetadata? DisplayMetadata => throw new NotImplementedException();

        public IListener AddContextListener<T>(string? contextType, ContextHandler<T> handler) where T : IContext
        {
            this.AddContextListenerInvoked = true;
            return null;
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
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

using Finos.Fdc3;
using Finos.Fdc3.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpfFdc3.Fdc3
{
    internal class DesktopAgent : IDesktopAgent
    {
        private readonly List<IChannel> _channels = new List<IChannel>();
        private IChannel? _currentChannel;

        public DesktopAgent()
        {
            _channels.Add(new Channel("global", ChannelType.App));
        }

        public Task<IListener> AddContextListener<T>(string? contextType, ContextHandler<T> handler) where T : IContext
        {
            return _currentChannel?.AddContextListener<T>(contextType, handler);
        }

        public Task<IListener> AddIntentListener<T>(string intent, IntentHandler<T> handler) where T : IContext
        {
            throw new NotImplementedException();
        }

        public Task Broadcast(IContext context)
        {
            if (_currentChannel != null)
            {
                return Task.Run(() => _currentChannel.Broadcast(context));
            }

            throw new Exception("Not joined to a channel");
        }

        public Task<IPrivateChannel> CreatePrivateChannel()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IAppIdentifier>> FindInstances(IAppIdentifier app)
        {
            throw new NotImplementedException();
        }

        public Task<IAppIntent> FindIntent(string intent, IContext? context = null, string? resultType = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IAppIntent>> FindIntentsByContext(IContext context, string? resultType = null)
        {
            throw new NotImplementedException();
        }

        public Task<IAppMetadata> GetAppMetadata(IAppIdentifier app)
        {
            throw new NotImplementedException();
        }

        public Task<IChannel?> GetCurrentChannel()
        {
            return Task.Run<IChannel?>(() => _currentChannel);
        }


        public Task<IImplementationMetadata> GetInfo()
        {
            return Task.Run<IImplementationMetadata>(() => new ImplementationMetadata(
                "2.0.0",
                "fdc3-dotnet",
                "1.0.0",
                new OptionalDesktopAgentFeatures() { OriginatingAppMetadata = false, UserChannelMembershipAPIs = false },
                new AppMetadata("appid")));
        }

        public Task<IChannel> GetOrCreateChannel(string channelId)
        {
            return Task.Run<IChannel>(() =>
            {
                IChannel channel = _channels.First<IChannel>(channel => channel.Id == channelId);
                if (channel == null)
                {
                    channel = new Channel(channelId, ChannelType.App);
                    _channels.Add(channel);
                }

                return channel;
            });
        }

        public Task<IEnumerable<IChannel>> GetUserChannels()
        {
            return Task.Run<IEnumerable<IChannel>>(() => _channels );
        }

        public Task JoinUserChannel(string channelId)
        {
            return Task.Run(() =>
            {
                IChannel channel = _channels.First<IChannel>(channel => channel.Id == channelId);
                if (channel != null)
                {
                    _currentChannel = channel;
                }
                else
                {
                    throw new Exception(ChannelError.NoChannelFound);
                }
            });
        }

        public Task LeaveCurrentChannel()
        {
            return Task.Run(() => _currentChannel = null);
        }

        public Task<IAppIdentifier> Open(IAppIdentifier app, IContext? context = null)
        {
            throw new NotImplementedException();
        }

        public Task<IIntentResolution> RaiseIntent(string intent, IContext context, IAppIdentifier? app = null)
        {
            throw new NotImplementedException();
        }

        public Task<IIntentResolution> RaiseIntentForContext(IContext context, IAppIdentifier? app = null)
        {
            throw new NotImplementedException();
        }
    }
}

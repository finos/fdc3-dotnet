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

using MorganStanley.Fdc3;
using MorganStanley.Fdc3.Context;
using Prism.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfFdc3.Fdc3
{
    public class Channel : IChannel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly Dictionary<string, IContext> _lastContexts = new Dictionary<string, IContext>();
        private IContext? _lastContext;

        public Channel(string id, string type)
        {
            this.Id = id;
            this.Type = type;
            _eventAggregator = new EventAggregator();
        }

        public string Id { get; }

        public string Type { get; }

        public IDisplayMetadata? DisplayMetadata => throw new System.NotImplementedException();

        public Task<IListener> AddContextListener<T>(string? contextType, ContextHandler<T> handler) where T : IContext
        {
            return Task.Run<IListener>(() => {
                return new Listener<T>(_eventAggregator, contextType, handler);
            });
        }

        public Task Broadcast(IContext context)
        {
            return Task.Run(() =>
            {
                _lastContexts[context.Type] = _lastContext = context;
                _eventAggregator.GetEvent<ContextEvent>().Publish(context);
            });
        }

        public Task<IContext?> GetCurrentContext(string? contextType)
        {
            return Task.Run<IContext?>(() => (contextType != null) ? _lastContexts[contextType] : _lastContext);
        }
    }
}

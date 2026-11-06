/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3;
using Finos.Fdc3.Context;
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

        public Channel(string id, ChannelType type)
        {
            this.Id = id;
            this.Type = type;
            _eventAggregator = new EventAggregator();
        }

        public string Id { get; }

        public ChannelType Type { get; }

        public IDisplayMetadata? DisplayMetadata => throw new System.NotImplementedException();

        public Task<IListener> AddContextListener<T>(string? contextType, ContextHandler<T> handler) where T : IContext
        {
            return Task.Run<IListener>(() => {
                return new Listener<T>(_eventAggregator, contextType, handler);
            });
        }

        public Task Broadcast(IContext context, IAppProvidableContextMetadata? metadata = null)
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

        public Task<IContextWithMetadata?> GetCurrentContextWithMetadata(string? contextType)
        {
            throw new System.NotImplementedException();
        }

        public Task ClearContext()
        {
            return Task.Run(() =>
            {
                _lastContexts.Clear();
                _lastContext = null;
            });
        }

        public Task<IListener> AddEventListener(string? eventType, Fdc3EventHandler handler)
        {
            throw new System.NotImplementedException();
        }
    }
}

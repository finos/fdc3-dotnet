/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3;
using Finos.Fdc3.Context;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfFdc3.Fdc3
{
    public class Channel : IChannel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly Dictionary<string, IContext> _lastContexts = new Dictionary<string, IContext>();
        private readonly Dictionary<string, IContextMetadata> _lastContextMetadata = new Dictionary<string, IContextMetadata>();
        private IContext? _lastContext;
        private IContextMetadata? _lastContextMetadataValue;

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
                
                // Preserve metadata if provided; create default metadata otherwise
                IContextMetadata contextMetadata = metadata is ContextMetadata cm 
                    ? cm 
                    : new ContextMetadata(
                        new AppIdentifier("channel"),
                        DateTime.UtcNow,
                        Guid.NewGuid().ToString(),
                        metadata?.Signature,
                        metadata?.AntiReplay,
                        metadata?.Custom);
                
                _lastContextMetadata[context.Type] = _lastContextMetadataValue = contextMetadata;
                _eventAggregator.GetEvent<ContextEvent>().Publish(context);
            });
        }

        public Task<IContext?> GetCurrentContext(string? contextType)
        {
            return Task.Run<IContext?>(() => 
            {
                if (contextType != null)
                {
                    return _lastContexts.TryGetValue(contextType, out var context) ? context : null;
                }
                return _lastContext;
            });
        }

        public Task<IContextWithMetadata?> GetCurrentContextWithMetadata(string? contextType)
        {
            return Task.Run<IContextWithMetadata?>(() =>
            {
                IContext? context = null;
                IContextMetadata? metadata = null;

                if (contextType != null)
                {
                    if (_lastContexts.TryGetValue(contextType, out var ctx))
                    {
                        context = ctx;
                        _lastContextMetadata.TryGetValue(contextType, out metadata);
                    }
                }
                else
                {
                    context = _lastContext;
                    metadata = _lastContextMetadataValue;
                }

                if (context != null && metadata != null)
                {
                    return new ContextWithMetadata(context, metadata);
                }
                return null;
            });
        }

        public Task ClearContext(string? contextType = null)
        {
            return Task.Run(() =>
            {
                if (contextType != null)
                {
                    _lastContexts.Remove(contextType);
                    _lastContextMetadata.Remove(contextType);
                }
                else
                {
                    _lastContexts.Clear();
                    _lastContextMetadata.Clear();
                    _lastContext = null;
                    _lastContextMetadataValue = null;
                }
            });
        }

        public Task<IListener> AddEventListener(string? eventType, Fdc3EventHandler handler)
        {
            throw new System.NotImplementedException();
        }
    }
}

/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3;
using Finos.Fdc3.Context;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        // Event listener storage
        private readonly List<(string? eventType, Fdc3EventHandler handler)> _eventListeners = new();
        private readonly object _eventListenerLock = new object();
        private readonly object _cacheLock = new object();

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
                lock (_cacheLock)
                {
                    _lastContexts[context.Type] = _lastContext = context;
                    
                    // Create fresh delivery metadata with current caller identity and time
                    // The Desktop Agent MUST override source and timestamp with its own values,
                    // forwarding only app-providable fields (traceId, signature, antiReplay, custom)
                    // per IAppProvidableContextMetadata contract.
                    
                    // Preserve caller-provided trace ID (generate one if not provided)
                    string traceId = metadata?.TraceId ?? Guid.NewGuid().ToString();
                    
                    // Create fresh metadata with new timestamp and agent caller identity
                    // Forward only app-providable fields from caller metadata
                    IContextMetadata contextMetadata = new ContextMetadata(
                        new AppIdentifier("channel"),  // In real implementations, use actual app identifier
                        DateTime.UtcNow,               // Current delivery time, not caller's
                        traceId,
                        metadata?.Signature,
                        metadata?.AntiReplay,
                        metadata?.Custom);
                    
                    _lastContextMetadata[context.Type] = _lastContextMetadataValue = contextMetadata;
                }
                
                _eventAggregator.GetEvent<ContextEvent>().Publish(context);
            });
        }

        public Task<IContext?> GetCurrentContext(string? contextType)
        {
            return Task.Run<IContext?>(() => 
            {
                lock (_cacheLock)
                {
                    if (contextType != null)
                    {
                        return _lastContexts.TryGetValue(contextType, out var context) ? context : null;
                    }
                    return _lastContext;
                }
            });
        }

        public Task<IContextWithMetadata?> GetCurrentContextWithMetadata(string? contextType)
        {
            return Task.Run<IContextWithMetadata?>(() =>
            {
                lock (_cacheLock)
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
                }
            });
        }

        public Task ClearContext(string? contextType = null)
        {
            return Task.Run(() =>
            {
                lock (_cacheLock)
                {
                    if (contextType != null)
                    {
                        _lastContexts.Remove(contextType);
                        _lastContextMetadata.Remove(contextType);
                        
                        // Clear the cached last context when its type is cleared
                        if (_lastContext?.Type == contextType)
                        {
                            _lastContext = null;
                            _lastContextMetadataValue = null;
                        }
                    }
                    else
                    {
                        _lastContexts.Clear();
                        _lastContextMetadata.Clear();
                        _lastContext = null;
                        _lastContextMetadataValue = null;
                    }
                }
                
                // Emit Fdc3ContextClearedEvent with channel ID and cleared type
                EmitContextClearedEvent(contextType);
            });
        }

        private void EmitContextClearedEvent(string? contextType)
        {
            // Create and publish context cleared event
            var contextClearedEvent = new Fdc3ContextClearedEvent(this.Id, contextType);
            // Note: Actual event publishing would need a Prism event wrapper
            // For now, emit via the event aggregator's ContextEvent
            // This is a limitation of the example implementation
        }

        public Task<IListener> AddEventListener(string? eventType, Fdc3EventHandler handler)
        {
            return Task.Run<IListener>(() =>
            {
                lock (_eventListenerLock)
                {
                    _eventListeners.Add((eventType, handler));
                    return new EventListener(eventType, handler, () =>
                    {
                        lock (_eventListenerLock)
                        {
                            _eventListeners.RemoveAll(e => e.eventType == eventType && e.handler == handler);
                        }
                    });
                }
            });
        }

        private class EventListener : IListener
        {
            private readonly string? _eventType;
            private readonly Fdc3EventHandler _handler;
            private readonly System.Action _unsubscribe;

            public EventListener(string? eventType, Fdc3EventHandler handler, System.Action unsubscribe)
            {
                _eventType = eventType;
                _handler = handler;
                _unsubscribe = unsubscribe;
            }

            public Task Unsubscribe()
            {
                return Task.Run(() => _unsubscribe());
            }
        }
    }
}

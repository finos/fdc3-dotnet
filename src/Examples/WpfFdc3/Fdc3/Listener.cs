/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Threading.Tasks;
using Finos.Fdc3;
using Finos.Fdc3.Context;
using Prism.Events;

namespace WpfFdc3.Fdc3
{
    internal class EventListener : IListener
    {
        internal EventListener(string? eventType, Fdc3EventHandler handler)
        {
            this.EventType = eventType;
            this.Handler = handler;
        }

        public string? EventType { get; }
        public Fdc3EventHandler Handler { get; }

        public Task Unsubscribe()
        {
            return Task.Run(() =>
            {
                throw new System.NotImplementedException();
            });
        }
    }

    internal class Listener<T> : IListener where T : IContext
    {
        private IEventAggregator _eventAggregator;
        private System.Action<IContext> _callback;

        internal Listener(IEventAggregator eventAggregator, string? contextType, ContextHandler<T> handler)
        {
            _eventAggregator = eventAggregator;
            _callback = context =>
            {
                if (contextType == context.Type)
                {
                    handler((T)context, null);
                }
            };

            _eventAggregator.GetEvent<ContextEvent>().Subscribe(_callback);
        }

        public Task Unsubscribe()
        {
            return Task.Run(() =>
            {
                _eventAggregator.GetEvent<ContextEvent>().Unsubscribe(_callback);
            });
        }
    }
}

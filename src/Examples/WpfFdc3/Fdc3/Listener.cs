﻿/*
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

namespace WpfFdc3.Fdc3
{
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

        public void Unsubscribe()
        {
            _eventAggregator.GetEvent<ContextEvent>().Unsubscribe(_callback);
        }
    }
}

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

using System;
using System.Threading.Tasks;

namespace Finos.Fdc3
{
    /// <summary>
    /// Object representing a private context channel, which is intended to support
    /// secure communication between applications, and extends the IChannel interface
    /// with event handlers which provide information on the connection state of both
    /// parties, ensuring that desktop agents do not need to queue or retain messages
    /// that are broadcast before a context listener is added and that applications
    /// are able to stop broadcasting messages when the other party has disconnected.
    ///
    /// It is intended that Desktop Agent implementations:
    ///  - SHOULD restrict external apps from listening or publishing on this channel.
    ///  - MUST prevent private channels from being retrieved via GetOrCreateChannel.
    ///  - MUST provide the `Id` value for the channel as required by the Channel interface.
    /// </summary>
    public interface IPrivateChannel : IChannel, IIntentResult
    {
        /// <summary>
        /// Adds an IListener that will be called each time that the remote app invokes
        /// AddContextListener on this channel.
        ///
        /// Desktop Agents MUST call this for each invocation of AddContextListener on this
        /// channel, including those that occurred before this handler was registered
        /// (to prevent race conditions).
        /// </summary>
        [Obsolete("Use AddEventListener")]
        IListener OnAddContextListener(Action<string?> handler);

        /// <summary>
        /// Adds an IListener that will be called whenever the remote app invokes
        /// IListener.Unsubscribe() on a context listener that it previously added.
        ///
        /// Desktop Agents MUST call this when Disconnect() is called by the other party, for
        /// each listener that they had added.
        /// </summary>
        [Obsolete("Use AddEventListener")]
        IListener OnUnsubscribe(Action<string?> handler);

        /// <summary>
        /// Adds an IListener that will be called when the remote app terminates, for example
        /// when its window is closed or because disconnect was called.This is in addition
        /// to calls that will be made to OnUnsubscribe listeners.
        /// </summary>
        [Obsolete("Use AddEventListener")]
        IListener OnDisconnect(Action handler);

        /// <summary>
        /// May be called to indicate that a participant will no longer interact with this channel.
        ///
        /// After this function has been called, Desktop Agents SHOULD prevent apps from broadcasting
        /// on this channel and MUST automatically call IListener.Unsubscribe() for each listener that
        /// they've added (causing any OnUnsubscribe handler added by the other party to be called)
        /// before triggering any OnDisconnect handler added by the other party.
        /// </summary>
        void Disconnect();


        /// <summary>
        /// Register a handler for events from the PrivateChannel.  Whenever the handler function is
        /// called it will be passed an event object with details related to the event.
        /// </summary>
        Task<IListener> AddEventListener(string? eventType, Fdc3EventHandler handler);
    }
}

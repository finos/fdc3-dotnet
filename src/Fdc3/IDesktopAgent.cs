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

using System.Collections.Generic;
using System.Threading.Tasks;

using MorganStanley.Fdc3.Context;

namespace MorganStanley.Fdc3
{
    /// <summary>
    /// A Desktop Agent is a desktop component (or aggregate of components) that serves as a
    /// launcher and message router(broker) for applications in its domain.
    ///
    /// A Desktop Agent can be connected to one or more App Directories and will use directories for application
    /// identity and discovery. Typically, a Desktop Agent will contain the proprietary logic of
    /// a given platform, handling functionality like explicit application interop workflows where
    /// security, consistency, and implementation requirements are proprietary.
    /// </summary>
    public interface IDesktopAgent
    {
        /// <summary>
        /// Launches an app by target, which can be optionally a string like a name, or an AppMetadata object.
        ///
        /// If a Context object is passed in, this object will be provided to the opened application via a contextListener.
        /// The Context argument is functionally equivalent to opening the target app with no context and broadcasting the context directly to it.
        /// </summary>
        Task Open(IAppMetadata app, IContext? context = null);

        /// <summary>
        /// Publishes context to other apps on the desktop.
        ///
        /// DesktopAgent implementations should ensure that context messages broadcast to a channel
        /// by an application joined to it should not be delivered back to that same application.
        /// </summary>
        void Broadcast(IContext context);

        /// <summary>
        /// Adds a listener for the broadcast of a specific type of context object.
        /// </summary>
        IListener AddContextListener<T>(string? contextType, ContextHandler<T> handler) where T : IContext;

        /// <summary>
        /// Find out more information about a particular intent by passing its name, and optionally its context.
        ///
        /// FindIntent is effectively granting programmatic access to the Desktop Agent's resolver.
        /// A Task resolving to the intent, its metadata and metadata about the apps that registered it is returned.
        /// This can be used to raise the intent against a specific app.
        /// </summary>
        Task<IAppIntent> FindIntent(string intent, IContext? context = null);

        /// <summary>
        /// Find all the available intents for a particular context.
        ///
        /// FindIntents is effectively granting programmatic access to the Desktop Agent's resolver.
        /// A Task resolving to all the intents, their metadata and metadata about the apps that registered it is returned,
        /// based on the context types the intents have registered.
        /// </summary>
        Task<IEnumerable<IAppIntent>> FindIntentsByContext(IContext context);

        /// <summary>
        /// Raises an intent to the desktop agent to resolve.
        /// </summary>
        Task<IIntentResolution> RaiseIntent(string intent, IContext context, IAppMetadata? app = null);

        /// <summary>
        /// Raises a context to the desktop agent to resolve with one of the possible Intents for that context.
        /// </summary>
        Task<IIntentResolution> RaiseIntentForContext(IContext context, IAppMetadata? app = null);

        /// <summary>
        /// Adds a listener for incoming Intents from the Agent.
        /// </summary>
        IListener AddIntentListener<T>(string intent, ContextHandler<T> handler) where T : IContext;

        /// <summary>
        /// Returns a channel with the given identity. Either stands up a new channel or returns an existing channel.
        ///
        /// It is up to applications to manage how to share knowledge of these custom channels across windows and to manage
        /// channel ownership and lifecycle.
        /// </summary>
        Task<IChannel> GetOrCreateChannel(string channelId);

        /// <summary>
        /// Retrieves a list of the System channels available for the app to join.
        /// </summary>
        Task<IEnumerable<IChannel>> GetSystemChannels();
        
        /// <summary>
        /// Joins the app to the specified channel. An app can only be joined to one channel at a time.
        /// Throws an exception if the channel is unavailable or the join request is denied.
        /// </summary>
        Task JoinChannel(string channelId);

        /// <summary>
        /// Returns the `Channel` object for the current channel membership.
        /// </summary>
        Task<IChannel?> GetCurrentChannel();
        
        /// <summary>
        /// Removes the app from any channel membership.
        ///
        /// Context broadcast and listening through the top-level `broadcast` and `addContextListener` will be
        /// in a no-op when the app is not on a channel.
        /// </summary>
        Task LeaveCurrentChannel();

        /// <summary>
        /// Retrieves information about the FDC3 Desktop Agent implementation, such as the implemented
        /// version of the FDC3 specification and the name of the implementation provider.
        /// </summary>
        IImplementationMetaData GetInfo();
    }

    public static class DesktopAgentExtensions
    {
        /// <summary>
        /// Launches an app by target, which can be optionally a string like a name, or an AppMetadata object.
        ///
        /// If a Context object is passed in, this object will be provided to the opened application via a contextListener.
        /// The Context argument is functionally equivalent to opening the target app with no context and broadcasting the context directly to it.
        /// </summary>
        public static Task Open(this IDesktopAgent desktopAgent, string app, IContext? context = null)
        {
            return desktopAgent.Open(AppMetadata.FromName(app), context);
        }

        public static IListener AddContextListener(this IDesktopAgent desktopAgent, string? contextType, ContextHandler<IContext> handler)
        {
            return desktopAgent.AddContextListener<IContext>(contextType, handler);
        }

        /// <summary>
        /// Raises an intent to the desktop agent to resolve.
        /// </summary>
        public static Task<IIntentResolution> RaiseIntent(this IDesktopAgent desktopAgent, string intent, IContext context, string? app = null)
        {
            return desktopAgent.RaiseIntent(intent, context, app != null ? new AppMetadata(app) : null);
        }

        /// <summary>
        /// Raises a context to the desktop agent to resolve with one of the possible Intents for that context.
        /// </summary>
        public static Task<IIntentResolution> RaiseIntentForContext(this IDesktopAgent desktopAgent, IContext context, string? app = null)
        {
            return desktopAgent.RaiseIntentForContext(context, app != null ? AppMetadata.FromName(app) : null);
        }
    }
}

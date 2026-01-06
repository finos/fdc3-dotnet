/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Finos.Fdc3.Context;

namespace Finos.Fdc3
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
        Task<IAppIdentifier> Open(IAppIdentifier app, IContext? context = null);

        /// <summary>
        /// Find out more information about a particular intent by passing its name, and optionally its context.
        ///
        /// FindIntent is effectively granting programmatic access to the Desktop Agent's resolver.
        /// A Task resolving to the intent, its metadata and metadata about the apps that registered it is returned.
        /// This can be used to raise the intent against a specific app.
        /// </summary>
        Task<IAppIntent> FindIntent(string intent, IContext? context = null, string? resultType = null);
        
        /// <summary>
        /// Find all the available intents for a particular context.
        ///
        /// FindIntents is effectively granting programmatic access to the Desktop Agent's resolver.
        /// A Task resolving to all the intents, their metadata and metadata about the apps that registered it is returned,
        /// based on the context types the intents have registered.
        /// </summary>
        Task<IEnumerable<IAppIntent>> FindIntentsByContext(IContext context, string? resultType = null);

        /// <summary>
        /// Find all available instances for a particular application.
        /// </summary>
        Task<IEnumerable<IAppIdentifier>> FindInstances(IAppIdentifier app);

        /// <summary>
        /// Publishes context to other apps on the desktop.
        ///
        /// DesktopAgent implementations should ensure that context messages broadcast to a channel
        /// by an application joined to it should not be delivered back to that same application.
        /// </summary>
        Task Broadcast(IContext context);

        /// <summary>
        /// Raises an intent to the desktop agent to resolve.
        /// </summary>
        Task<IIntentResolution> RaiseIntent(string intent, IContext context, IAppIdentifier? app = null);

        /// <summary>
        /// Raises a context to the desktop agent to resolve with one of the possible Intents for that context.
        /// </summary>
        Task<IIntentResolution> RaiseIntentForContext(IContext context, IAppIdentifier? app = null);

        /// <summary>
        /// Adds a listener for incoming Intents from the Agent.
        /// </summary>
        Task<IListener> AddIntentListener<T>(string intent, IntentHandler<T> handler) where T : IContext;

        /// <summary>
        /// Adds a listener for the broadcast of a specific type of context object.
        /// </summary>
        Task<IListener> AddContextListener<T>(string? contextType, ContextHandler<T> handler) where T : IContext;

        /// <summary>
        /// Register a handler for events from the DesktopAgent.  Whenever the handler function is
        /// called it will be passed an event object with details related to the event.
        /// </summary>
        Task<IListener> AddEventListener(string? eventType, Fdc3EventHandler handler);

        /// <summary>
        /// Retreives a list of the User channels available for the app to join.
        /// </summary>
        Task<IEnumerable<IChannel>> GetUserChannels();

        /// <summary>
        /// Optional function that joins the app to the specified User channel.  In most cases, applications SHOULD
        /// be joined to channels via UX provided to the application by the desktop agent, rather than calling this
        /// function directly
        /// </summary>
        Task JoinUserChannel(string channelId);

        /// <summary>
        /// Returns a channel with the given identity. Either stands up a new channel or returns an existing channel.
        ///
        /// It is up to applications to manage how to share knowledge of these custom channels across windows and to manage
        /// channel ownership and lifecycle.
        /// </summary>
        Task<IChannel> GetOrCreateChannel(string channelId);

        /// <summary>
        /// Returns a 'Channel' with an auto-generated identity that is intended for private communication between applications.
        /// </summary>
        Task<IPrivateChannel> CreatePrivateChannel();

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
        Task<IImplementationMetadata> GetInfo();

        /// <summary>
        /// Retreives the 'AppMetadata' for an 'AppIdentifier', which provides additional metadata (such as icons, a
        /// title and description) from the App Directory record for the application, that may be used for 
        /// display purposes.
        /// </summary>
        Task<IAppMetadata> GetAppMetadata(IAppIdentifier app);
    }

    public static class DesktopAgentExtensions
    {
    }
}

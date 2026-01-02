/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using System.Threading.Tasks;

using Finos.Fdc3.Context;

namespace Finos.Fdc3
{
    /// <summary>
    /// Object representing a context channel.
    /// </summary>
    public interface IChannel: IIntentResult
    {
        /// <summary>
        /// Constant that uniquely identifies this channel.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Uniquely defines each channel type.
        /// </summary>
        ChannelType Type { get; }

        /// <summary>
        /// Channels may be visualized and selectable by users. DisplayMetadata may be used to provide hints on how to see them.
        /// For app channels, displayMetadata would typically not be present
        /// </summary>
        IDisplayMetadata? DisplayMetadata { get; }

        /// <summary>
        ///  Broadcasts the given context on this channel. This is equivalent to joining the channel and then calling the
        /// top-level FDC3 `broadcast` function.
        ///
        /// Note that this function can be used without first joining the channel, allowing applications to broadcast on
        /// channels that they aren't a member of.
        ///
        /// Channel implementations should ensure that context messages broadcast by an application on a channel should
        /// not be delivered back to that same application if they are joined to the channel.
        /// </summary>
        Task Broadcast(IContext context);

        /// <summary>
        /// Returns the last context that was broadcast on this channel. All channels initially have no context, until a
        /// context is broadcast on the channel.If there is not yet any context on the channel, this method
        /// will return `null`.
        ///
        /// The context of a channel will be captured regardless of how the context is broadcasted on this channel - whether
        /// using the top-level FDC3 `broadcast` function, or using the channel-level broadcast function on this
        /// object.
        ///
        /// Optionally a contextType can be provided, in which case the current context of the matching type will
        /// be returned (if any). Desktop agent implementations may decide to record contexts by type, in which case it will
        /// be possible to get the most recent context of the type specified, but this is not guaranteed.
        /// </summary>
        Task<IContext?> GetCurrentContext(string? contextType);

        /// <summary>
        /// Adds a listener for incoming contexts of the specified context type whenever a broadcast happens on this channel.
        /// </summary>
        Task<IListener> AddContextListener<T>(string? contextType, ContextHandler<T> handler) where T : IContext;
    }

    public static class ChannelExtensions
    {
        /// <summary>
        /// Adds a listener for incoming contexts of the specified context type whenever a broadcast happens on this channel.
        /// </summary>
        [Obsolete("Use AddContextListener(null, handler)")]
        public static Task<IListener> AddContextListener<T>(this IChannel channel, ContextHandler<T> handler) where T : IContext
        {
            return channel.AddContextListener<T>(null, handler);
        }
    }
}

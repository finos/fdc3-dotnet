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

namespace Finos.Fdc3
{
    /// <summary>
    /// Interface representing the format of event objects that may be received via the FDC3 API's AddEventListener function.
    /// </summary>
    public interface IFdc3Event
    {
        public string Type { get; }
        public object? Details { get; }
    }

    public delegate void Fdc3EventHandler(IFdc3Event fdc3Event);

    /// <summary>
    /// Type representing the format of event objects that may be received via the FDC3 API's addEventListener function
    /// </summary>
    public class Fdc3Event : IFdc3Event
    {
        public string Type { get; }
        public object? Details { get; }

        public Fdc3Event(string type, object? details = null)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
            this.Details = details;
        }
    }

    /// <summary>
    /// Valid type strings for DesktopAgent interface events.
    /// </summary>
    public static class Fdc3EventType
    {
        public const string UserChannelChanged = "userChannelChanged";
    }

    /// <summary>
    /// Valid type strings for Private Channel events.
    /// </summary>
    public static class Fdc3PrivateChannelEventType
    {
        public const string AddContextListener = "addContextListener";
        public const string Unsubscribe = "unsubscribe";
        public const string Disconnect = "disconnect";
    }

    public interface IFdc3ChannelChangedEventDetails
    {
        string? CurrentChannelId { get; }
    }

    public class Fdc3ChannelChangedEventDetails : IFdc3ChannelChangedEventDetails
    {
        public string? CurrentChannelId { get; }

        public Fdc3ChannelChangedEventDetails(string? channelId)
        {
            this.CurrentChannelId = channelId;
        }
    }

    public class Fdc3ChannelChangedEvent : Fdc3Event
    {
        public Fdc3ChannelChangedEvent(string? channelId)
            : base(Fdc3EventType.UserChannelChanged, new Fdc3ChannelChangedEventDetails(channelId))
        {
        }
    }

    public interface IFdc3PrivateChannelEventDetails
    {
        string? ContextType { get; }
    }

    public class Fdc3PrivateChannelEventDetails : IFdc3PrivateChannelEventDetails
    {
        public string? ContextType { get; }

        public Fdc3PrivateChannelEventDetails(string? contextType)
        {
            this.ContextType = contextType;
        }
    }

    public class Fdc3PrivateChannelAddContextListenerEvent : Fdc3Event
    {
        public Fdc3PrivateChannelAddContextListenerEvent(string? contextType)
            : base(Fdc3PrivateChannelEventType.AddContextListener, new Fdc3PrivateChannelEventDetails(contextType))
        {
        }
    }

    public class Fdc3PrivateChannelUnsubscribeListenerEvent : Fdc3Event
    {
        public Fdc3PrivateChannelUnsubscribeListenerEvent(string? contextType)
                : base(Fdc3PrivateChannelEventType.Unsubscribe, new Fdc3PrivateChannelEventDetails(contextType))
        {
        }
    }

    public class Fdc3PrivateChanneDisconnectEvent : Fdc3Event
    {
        public Fdc3PrivateChanneDisconnectEvent()
            : base(Fdc3PrivateChannelEventType.Disconnect)
        {
        }
    }
}

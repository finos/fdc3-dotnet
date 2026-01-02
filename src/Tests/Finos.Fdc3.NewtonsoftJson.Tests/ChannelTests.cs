/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using Finos.Fdc3.NewtonsoftJson.Serialization;
using Newtonsoft.Json;

namespace Finos.Fdc3.NewtonsoftJson.Tests;

public class ChannelTests
{
    [Fact]
    public void Channel_SerializedJsonHasCamelCaseId()
    {
        IChannel channel = new MockChannel();
        string serializedChannel = JsonConvert.SerializeObject(channel, new Fdc3JsonSerializerSettings());
        Assert.Contains("\"id\":", serializedChannel);
    }

    [Fact]
    public void Channel_SerializedJsonHasCamelCaseEnumValue()
    {
        IChannel channel = new MockChannel(ChannelType.App);
        string serializedChannel = JsonConvert.SerializeObject(channel, new Fdc3JsonSerializerSettings());
        Assert.Contains("\"app\"", serializedChannel);

        channel = new MockChannel(ChannelType.User);
        serializedChannel = JsonConvert.SerializeObject(channel, new Fdc3JsonSerializerSettings());
        Assert.Contains("\"user\"", serializedChannel);

        channel = new MockChannel(ChannelType.Private);
        serializedChannel = JsonConvert.SerializeObject(channel, new Fdc3JsonSerializerSettings());
        Assert.Contains("\"private\"", serializedChannel);
    }

    [Fact]
    public void Channel_ParsedChannelTypeFromJson()
    {
        string json = "{\"id\":\"value\",\"type\":\"user\",\"displayMetadata\":{}}";
        IChannel? channel = JsonConvert.DeserializeObject<MockChannel>(json);
        Assert.Equal("value", channel?.Id);
        Assert.Equal(ChannelType.User, channel?.Type);

        json = "{\"id\":\"value\",\"type\":\"app\",\"displayMetadata\":{}}";
        channel = JsonConvert.DeserializeObject<MockChannel>(json);
        Assert.Equal(ChannelType.App, channel?.Type);
    }


    public class MockChannel : IChannel
    {
        public MockChannel()
        {
        }

        internal MockChannel(ChannelType channelType)
        {
            this.Type = channelType;
        }

        public string Id { get; set; } =  "value";

        public ChannelType Type { get; set; }

        public IDisplayMetadata? DisplayMetadata { get; set;  } = new DisplayMetadata();

        public Task<IListener> AddContextListener<T>(string? contextType, ContextHandler<T> handler) where T : IContext
        {
            throw new NotImplementedException();
        }

        public Task Broadcast(IContext context)
        {
            throw new NotImplementedException();
        }

        public Task<IContext?> GetCurrentContext(string? contextType)
        {
            throw new NotImplementedException();
        }
    }
}
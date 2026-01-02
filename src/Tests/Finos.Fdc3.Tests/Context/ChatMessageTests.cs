/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using System;

namespace Finos.Fdc3.Tests.Context;

public class ChatMessageTests
{
    [Fact]
    public void ChatMessage_PropertiesMatchParams()
    {
        dynamic chatRoomID = new { StreamId = "j75xqXy25NB0dacUI3FNBH", AnyOtherKey = "abcdef" };
        ChatRoom chatRoom = new ChatRoom(chatRoomID, "provider", "http://test.com", "name");
        ChatMessage message = new ChatMessage(chatRoom, new Message(new MessageText() { TextPlain = "textplain", TextMarkdown = "textmarkdown" }, null, "message"), null, "chatmessage");

        Assert.Equal(chatRoomID, message.ChatRoom.ID);
        Assert.Same("http://test.com", message.ChatRoom.Url);
        Assert.Same("name", message.ChatRoom.Name);
        Assert.Same(ContextTypes.ChatRoom, message.ChatRoom.Type);
        Assert.Same("textplain", message.Message.Text?.TextPlain);
        Assert.Same("textmarkdown", message.Message.Text?.TextMarkdown);
        Assert.Same(ContextTypes.Message, message.Message.Type);
        Assert.Same(ContextTypes.ChatMessage, message.Type);
    }
}
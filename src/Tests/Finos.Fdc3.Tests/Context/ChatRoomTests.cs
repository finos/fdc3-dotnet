/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using System;

namespace Finos.Fdc3.Tests.Context;

public class ChatRoomTests
{
    [Fact]
    public void ChatRoom_PropertiesMatchParams()
    {
        dynamic chatRoomID = new { StreamId = "j75xqXy25NB0dacUI3FNBH", AnyOtherKey = "abcdef" };
        ChatRoom chatRoom = new ChatRoom(chatRoomID, "provider", "http://test.com", "name");

        Assert.Equal(chatRoomID, chatRoom.ID);
        Assert.Same("http://test.com", chatRoom.Url);
        Assert.Same("name", chatRoom.Name);
        Assert.Same(ContextTypes.ChatRoom, chatRoom.Type);
    }
}
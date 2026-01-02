/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class ChatroomTests : ContextSchemaTest
{
    public ChatroomTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/chatRoom.schema.json")
    {
    }

    [Fact]
    public async Task ChatRoom_SerializedJsonMatchesSchema()
    {
        dynamic chatRoomID = new { StreamId = "j75xqXy25NB0dacUI3FNBH", AnyOtherKey = "abcdef" };
        ChatRoom chatRoom = new ChatRoom(chatRoomID, "provider", "http://test.com", "name");
        await this.ValidateSchema(chatRoom);
    }
}
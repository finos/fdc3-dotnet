/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class ChatMessageTests : ContextSchemaTest
{
    public ChatMessageTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/chatMessage.schema.json")
    {
    }

    [Fact]
    public async Task ChatMessage_SerializedJsonMatchesSchema()
    {
        dynamic chatRoomID = new { StreamId = "j75xqXy25NB0dacUI3FNBH", AnyOtherKey = "abcdef" };
        ChatRoom chatRoom = new ChatRoom(chatRoomID, "provider", "http://test.com", "name");
        ChatMessage message = new ChatMessage(chatRoom, new Message(new MessageText() { TextPlain = "plaintext", TextMarkdown = "textmarkdown" }, null, "message"), null, "chatmessage");

        await this.ValidateSchema(message);
    }
}
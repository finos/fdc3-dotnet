/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class ChatInitSettingsTests : ContextSchemaTest
{
    public ChatInitSettingsTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/chatInitSettings.schema.json")
    {
    }

    [Fact]
    public async Task ChatInitSettings_SerializedJsonMatchesSchema()
    {
        ChatInitSettings chatInitSettings = new ChatInitSettings(
            new ContactList(new Contact[] { new Contact(new ContactID() { Email = "email@test.com", FDS_ID = "fds_id" }) }),
            new Message(new MessageText() { TextPlain = "textplain", TextMarkdown = "textmarkdown" }),
            "chatName",
            new ChatInitSettingsOptions() { GroupRecipients = true, IsPublic = true, AllowHistoryBrowsing = true, AllowMessageCopy = true, AllowAddUser = true },
            null,
            "chatInitSettings"
           );

        await this.ValidateSchema(chatInitSettings);
    }
}
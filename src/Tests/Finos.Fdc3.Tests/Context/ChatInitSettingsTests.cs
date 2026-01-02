/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class ChatInitSettingsTests
{
    [Fact]
    public void ChatInitSettings_PropertiesMatchParams()
    {
        ChatInitSettingsOptions options = new ChatInitSettingsOptions() { GroupRecipients = true, IsPublic = true, AllowHistoryBrowsing = true, AllowMessageCopy = true, AllowAddUser = true };
        Message message = new Message(new MessageText() { TextPlain = "textplain", TextMarkdown = "textmarkdown" });
        ChatInitSettings chatInitSettings = new ChatInitSettings(
            new ContactList(new Contact[] { new Contact(new ContactID() { Email = "email@test.com", FDS_ID = "fds_id" }) }),
            message,
            "chatName",
            options,
            null,
            "chatInitSettings"
           );

        Assert.Same("email@test.com", chatInitSettings?.Members?.Contacts?.First<Contact>()?.ID?.Email);
        Assert.Same(options, chatInitSettings?.Options);
        Assert.Same(message, chatInitSettings?.Message);
        Assert.Same("chatName", chatInitSettings?.ChatName);
        Assert.Same("chatInitSettings", chatInitSettings?.Name);
        Assert.Same(ContextTypes.ChatInitSettings, chatInitSettings?.Type);
    }
}
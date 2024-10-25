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
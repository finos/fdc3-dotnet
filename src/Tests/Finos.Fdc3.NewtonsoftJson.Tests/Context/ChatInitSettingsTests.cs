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
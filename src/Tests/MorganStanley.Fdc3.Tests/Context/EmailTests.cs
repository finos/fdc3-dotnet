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

using MorganStanley.Fdc3.Context;

namespace MorganStanley.Fdc3.Tests;

public class EmailTests : ContextSchemaTest
{
    public EmailTests()
        : base("https://fdc3.finos.org/schemas/2.0/email.schema.json")
    {
    }

    [Fact]
    public async void Email_Contact_SerializedJsonMatchesSchema()
    {
        Email email = new Email(new Contact(new ContactID() { Email = "email", FdsId = "fdsid" }), "subject", "body", null, "email");
        await this.ValidateSchema(email);
    }

    [Fact]
    public async void Email_ContactList_SerializedJsonMatchesSchema()
    {
        Email email = new Email(new ContactList(new Contact[] { new Contact(new ContactID() { Email = "email", FdsId = "fdsid" }) }), "subject", "body", null, "email");
        await this.ValidateSchema(email);
    }
}
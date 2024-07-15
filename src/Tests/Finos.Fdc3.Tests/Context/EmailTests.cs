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

public class EmailTests
{
    [Fact]
    public void Email_Contact_PropertiesMatchParams()
    {
        Email email = new Email(new Contact(new ContactID() { Email = "email@test.com", FDS_ID = "fdsid" }), "subject", "body", null, "email");

        Assert.Same("email@test.com", (email?.Recipients as Contact)?.ID?.Email);
        Assert.Same("email", email?.Name);
        Assert.Same(ContextTypes.Email, email?.Type);
    }

    [Fact]
    public void Email_ContactList_PropertiesMatchParams()
    {
        Email email = new Email(new ContactList(new Contact[] { new Contact(new ContactID() { Email = "email@test.com", FDS_ID = "fdsid" }) }), "subject", "body", null, "email");

        Assert.Same("email@test.com", (email?.Recipients as ContactList)?.Contacts?.First<Contact>()?.ID?.Email);
        Assert.Same("email", email?.Name);
        Assert.Same(ContextTypes.Email, email?.Type);
    }
}
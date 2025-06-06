﻿/*
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

public class ContactListTests : ContextSchemaTest
{
    public ContactListTests()
        : base("https://fdc3.finos.org/schemas/2.1/context/contactList.schema.json")
    {
    }

    [Fact]
    public async Task ContactList_SerializedJsonMatchesSchema()
    {
        ContactList contactList = new ContactList(new Contact[] { new Contact(new ContactID { Email = "email@email.com", FDS_ID = "fds_id" }, "contact") }, "contactList");
        await this.ValidateSchema(contactList);
    }
}
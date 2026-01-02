/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class ContactListTests : ContextSchemaTest
{
    public ContactListTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/contactList.schema.json")
    {
    }

    [Fact]
    public async Task ContactList_SerializedJsonMatchesSchema()
    {
        ContactList contactList = new ContactList(new Contact[] { new Contact(new ContactID { Email = "email@email.com", FDS_ID = "fds_id" }, "contact") }, "contactList");
        await this.ValidateSchema(contactList);
    }
}
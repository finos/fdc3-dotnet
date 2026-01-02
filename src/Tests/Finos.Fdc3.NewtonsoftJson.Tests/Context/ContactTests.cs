/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;
public class ContactTests : ContextSchemaTest
{
    public ContactTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/contact.schema.json")
    {
    }

    [Fact]
    public async Task Contact_SerializedJsonMatchesSchema()
    {
        Contact contact = new Contact(new ContactID { Email = "email@test.com", FDS_ID = "fds_id" }, "contact");
        await this.ValidateSchema(contact);
    }
}
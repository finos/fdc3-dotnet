/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using System.Reflection;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class EmailTests : ContextSchemaTest
{
    public EmailTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/email.schema.json")
    {
    }

    [Fact]
    public async Task Email_Contact_SerializedJsonMatchesSchema()
    {
        Email email = new Email(new Contact(new ContactID() { Email = "email@test.com", FDS_ID = "fds_id" }), "subject", "body", null, "email");
        string test = await this.ValidateSchema(email);
    }

    [Fact]
    public void Email_Contact_DeserializedJsonMatchesProperties()
    {
        Email? email = this.Deserialize<Email>("Finos.Fdc3.NewtonsoftJson.Tests.Context.Examples.email-contact.json");
        Assert.NotNull(email);
        Contact? contact = email?.Recipients as Contact;
        Assert.Equal("email@test.com", contact?.ID?.Email);
        Assert.Equal("fds_id", contact?.ID?.FDS_ID);
        Assert.Equal("subject", email?.Subject);
        Assert.Equal("body", email?.TextBody);
        Assert.Equal("email", email?.Name);
    }

    [Fact]
    public async Task Email_ContactList_SerializedJsonMatchesSchema()
    {
        Email email = new Email(new ContactList(new Contact[] { new Contact(new ContactID() { Email = "email@test.com", FDS_ID = "fds_id" }) }), "subject", "body", null, "email");
        await this.ValidateSchema(email);
    }

    [Fact]
    public void Email_ContactList_DeserializedJsonMatchesProperties()
    {
        Email? email = this.Deserialize<Email>("Finos.Fdc3.NewtonsoftJson.Tests.Context.Examples.email-contactList.json");
        Assert.NotNull(email);
        ContactList? contactList = email?.Recipients as ContactList;
        Contact? contact = contactList?.Contacts?.First<Contact>();
        Assert.Equal("email@test.com", contact?.ID?.Email);
        Assert.Equal("fds_id", contact?.ID?.FDS_ID);
        Assert.Equal("subject", email?.Subject);
        Assert.Equal("body", email?.TextBody);
        Assert.Equal("email", email?.Name);
    }
}
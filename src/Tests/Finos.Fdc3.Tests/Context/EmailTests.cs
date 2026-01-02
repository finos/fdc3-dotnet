/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class EmailTests
{
    [Fact]
    public void Email_Contact_PropertiesMatchParams()
    {
        Email email = new Email(new Contact(new ContactID() { Email = "email@test.com", FDS_ID = "fds_id" }), "subject", "body", null, "email");

        Assert.Same("email@test.com", (email?.Recipients as Contact)?.ID?.Email);
        Assert.Same("email", email?.Name);
        Assert.Same(ContextTypes.Email, email?.Type);
    }

    [Fact]
    public void Email_ContactList_PropertiesMatchParams()
    {
        Email email = new Email(new ContactList(new Contact[] { new Contact(new ContactID() { Email = "email@test.com", FDS_ID = "fds_id" }) }), "subject", "body", null, "email");

        Assert.Same("email@test.com", (email?.Recipients as ContactList)?.Contacts?.First<Contact>()?.ID?.Email);
        Assert.Same("email", email?.Name);
        Assert.Same(ContextTypes.Email, email?.Type);
    }
}
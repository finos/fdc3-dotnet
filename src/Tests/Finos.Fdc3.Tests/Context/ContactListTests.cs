/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class ContactListTests
{
    [Fact]
    public void ContactList_PropertiesMatchParams()
    {
        ContactList contactList = new ContactList(new Contact[] { new Contact(new ContactID { Email = "email@test.com", FDS_ID = "fds_id" }, "contact") }, "contactList");

        Assert.Same("email@test.com", contactList?.Contacts?.First<Contact>()?.ID?.Email);
        Assert.Same("contactList", contactList?.Name);
        Assert.Same(ContextTypes.ContactList, contactList?.Type);
    }
}
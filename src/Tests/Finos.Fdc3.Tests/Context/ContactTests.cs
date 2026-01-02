/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;
public class ContactTests
{
    [Fact]
    public void Contact_PropertiesMatchParams()
    {
        Contact contact = new Contact(new ContactID { Email = "email@test.com", FDS_ID = "fds_id" }, "contact");

        Assert.Same("email@test.com", contact?.ID?.Email);
        Assert.Same("contact", contact?.Name);
        Assert.Same(ContextTypes.Contact, contact?.Type);
    }
}
/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using System;

namespace Finos.Fdc3.Tests.Context;

public class TransactionResultTests
{
    [Fact]
    public void TransactionResult_PropertiesMatchParams()
    {
        Contact contact = new Contact(new ContactID { Email = "email@test.com", FDS_ID = "fds_id" }, "contact");
        TransactionResult result = new TransactionResult("Created", contact, "message");

        Assert.Same("Created", result.Status);
        Assert.Equal(contact, result.Context);
        Assert.Same("message", result.Message);
        Assert.Same(ContextTypes.TransactionResult, result.Type) ;
    }
}
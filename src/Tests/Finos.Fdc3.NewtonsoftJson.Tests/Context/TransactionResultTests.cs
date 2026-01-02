/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class TransactionResultTests : ContextSchemaTest
{
    public TransactionResultTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/transactionResult.schema.json")
    {
    }

    [Fact]
    public async Task TransactionResult_SerializedJsonMatchesSchema()
    {
        TransactionResult transactionResult = new TransactionResult("Created", new Contact(new ContactID { Email = "email@test.com", FDS_ID = "fds_id" }, "contact"), "message");
        await this.ValidateSchema(transactionResult);
    }
}
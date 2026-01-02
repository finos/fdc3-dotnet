/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class CurrencyTests : ContextSchemaTest
{
    public CurrencyTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/currency.schema.json")
    {
    }

    [Fact]
    public async Task Currency_SerializedJsonMatchesSchema()
    {
        Currency currency = new Currency(new CurrencyID() { CURRENCY_ISOCODE = "AAA" }, "currency");

        await this.ValidateSchema(currency);
    }
}
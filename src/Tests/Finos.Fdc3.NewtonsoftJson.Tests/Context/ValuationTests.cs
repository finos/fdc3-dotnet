/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class ValuationTests : ContextSchemaTest
{
    public ValuationTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/valuation.schema.json")
    {
    }

    [Fact]
    public async Task Valuation_SerializedJsonMatchesSchema()
    {
        var valuation = new Valuation("AAA", 1, 1, DateTime.Now.ToString("o"), DateTime.Now.ToString("o"), null, "valuation");

        await ValidateSchema(valuation);
    }
}
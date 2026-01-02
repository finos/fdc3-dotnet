/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class CountryTests : ContextSchemaTest
{
    public CountryTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/country.schema.json")
    {
    }

    [Fact]
    public async Task Country_SerializedJsonMatchesSchema()
    {
        Country country = new Country(new CountryID() { ISOALPHA2 = "isoalpha2", ISOALPHA3 = "isoalpha3" }, "country");

        await this.ValidateSchema(country);
    }
}
/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class PortfolioTests : ContextSchemaTest
{
    public PortfolioTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/portfolio.schema.json")
    {
    }

    [Fact]
    public async Task Portfolio_SerializedJsonMatchesSchema()
    {
        Portfolio portfolio = new Portfolio(
            new Position[] { new Position(0, new Instrument(new InstrumentID() { Ticker = "ticker" })) },
            null,
            "portfolio");

        await this.ValidateSchema(portfolio);
    }
}
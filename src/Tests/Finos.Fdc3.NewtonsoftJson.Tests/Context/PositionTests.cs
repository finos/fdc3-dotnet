/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class PositionTests : ContextSchemaTest
{
    public PositionTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/position.schema.json")
    {
    }

    [Fact]
    public async Task Position_SerializedJsonMatchesSchema()
    {
        Position position = new Position(0, new Instrument(new InstrumentID() { Ticker = "ticker" }), null, "position");

        await this.ValidateSchema(position);
    }
}
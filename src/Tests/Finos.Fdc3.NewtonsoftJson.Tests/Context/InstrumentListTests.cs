/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class InstrumentListTests : ContextSchemaTest
{
    public InstrumentListTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/instrumentList.schema.json")
    {
    }

    [Fact]
    public async Task InstrumentList_SerializedJsonMatchesSchema()
    {
        InstrumentList instrumentList = new InstrumentList(new Instrument[]
            {
            new Instrument(
                new InstrumentID
                {
                    Ticker = "TICKER"
                }, "Instrument")
               }, "InstrumentList");

        await this.ValidateSchema(instrumentList);
    }
}
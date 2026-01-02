/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class InstrumentTests : ContextSchemaTest
{
    public InstrumentTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/instrument.schema.json")
    {
    }

    [Fact]
    public async Task Instrument_SerializedJsonMatchesSchema()
    {
        Instrument instrument = new Instrument(
            new InstrumentID
            {
                BBG = "BBG",
                CUSIP = "CUSIP",
                FDS_ID = "FDS_ID",
                FIGI = "FIGI",
                ISIN = "ISIN",
                PERMID = "PERMID",
                RIC = "RIC",
                SEDOL = "SEDOL",
                Ticker = "TICKER"
            }, "Instrument")
        {
            Market = new MarketSource
            {
                BBG = "BBG",
                COUNTRY_ISOALPHA2 = "COUNTRY_ISOALPHA2",
                MIC = "MIC",
                Name = "Name"
            }
        };

        await this.ValidateSchema(instrument);
    }
}
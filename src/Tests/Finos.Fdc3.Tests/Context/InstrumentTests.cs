/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class InstrumentTests
{
    [Fact]
    public void Instrument_PropertiesMatchParams()
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

        Assert.Same("BBG", instrument?.ID?.BBG);
        Assert.Same("CUSIP", instrument?.ID?.CUSIP);
        Assert.Same("FDS_ID", instrument?.ID?.FDS_ID);
        Assert.Same("FIGI", instrument?.ID?.FIGI);
        Assert.Same("ISIN", instrument?.ID?.ISIN);
        Assert.Same("PERMID", instrument?.ID?.PERMID);
        Assert.Same("RIC", instrument?.ID?.RIC);
        Assert.Same("SEDOL", instrument?.ID?.SEDOL);
        Assert.Same("TICKER", instrument?.ID?.Ticker);
        Assert.Same("Instrument", instrument?.Name);
        Assert.Same("BBG", instrument?.Market?.BBG);
        Assert.Same("COUNTRY_ISOALPHA2", instrument?.Market?.COUNTRY_ISOALPHA2);
        Assert.Same("MIC", instrument?.Market?.MIC);
        Assert.Same("Name", instrument?.Market?.Name);
        Assert.Same(ContextTypes.Instrument, instrument?.Type);
    }
}
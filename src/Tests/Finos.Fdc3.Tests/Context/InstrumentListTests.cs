/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class InstrumentListTests
{
    [Fact]
    public void InstrumentList_PropertiesMatchParams()
    {
        InstrumentList instrumentList = new InstrumentList(new Instrument[]
            {
            new Instrument(
                new InstrumentID
                {
                    Ticker = "TICKER"
                }, "Instrument")
               }, "InstrumentList");

        Assert.Same("TICKER", instrumentList?.Instruments?.First<Instrument>()?.ID?.Ticker);
        Assert.Same("InstrumentList", instrumentList?.Name);
        Assert.Same(ContextTypes.InstrumentList, instrumentList?.Type);
    }
}
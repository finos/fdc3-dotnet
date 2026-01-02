/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class ChartTests
{
    [Fact]
    public void Chart_PropertiesMatchParams()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "TICKER" });
        TimeRange timeRange = new TimeRange(DateTime.Now.ToString("o"), DateTime.Now.ToString("o"));
        var otherConfig = new  [] { instrument };
        Chart chart = new Chart(new Instrument[] { instrument }, timeRange, otherConfig, ChartStyle.Line, null, "chart");

        Assert.Same("TICKER", chart?.Instruments?.First<Instrument>()?.ID?.Ticker);
        Assert.Same(timeRange, chart?.Range);
        Assert.Same(otherConfig, chart?.OtherConfig);
        Assert.Same(ChartStyle.Line, chart?.Style);
        Assert.Same("chart", chart?.Name);
        Assert.Same(ContextTypes.Chart, chart?.Type);
    }
}
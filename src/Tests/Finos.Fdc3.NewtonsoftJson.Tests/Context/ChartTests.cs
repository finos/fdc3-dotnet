/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class ChartTests : ContextSchemaTest
{
    public ChartTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/chart.schema.json")
    {
    }

    [Fact]
    public async Task Chart_SerializedJsonMatchesSchema()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "TICKER" });
        TimeRange timeRange = new TimeRange(DateTime.Now.ToString("o"), DateTime.Now.ToString("o"));
        IContext[] otherConfig = new[] { instrument };
        Chart chart = new Chart(new Instrument[] { instrument }, timeRange, otherConfig, ChartStyle.Line, null, "chart");
        await this.ValidateSchema(chart);
    }
}
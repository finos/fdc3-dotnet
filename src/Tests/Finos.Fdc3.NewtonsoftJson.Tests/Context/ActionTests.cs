/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class ActionTests : ContextSchemaTest
{
    public ActionTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/action.schema.json")
    {
    }

    [Fact]
    public async Task Action_SerializedJsonMatchesSchema()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "TICKER" });
        Fdc3.Context.Action action = new Fdc3.Context.Action("title", instrument, "ViewInstrument", new AppIdentifier("appid", "instanceid"));
        await this.ValidateSchema(action);
    }

    [Fact]
    public async Task Action_BroadcastAction_SerializedJsonMatchesSchema()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "EURUSD" });
        Fdc3.Context.Action action = new Fdc3.Context.Action(
            "Click to view Chart",
            instrument,
            null,
            null,
            ActionTypes.Broadcast,
            "Channel 1"
        );
        await this.ValidateSchema(action);
    }

    [Fact]
    public async Task Action_RaiseIntentAction_SerializedJsonMatchesSchema()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "EURUSD" });
        Fdc3.Context.Action action = new Fdc3.Context.Action(
            "Click to view Chart",
            instrument,
            "ViewChart",
            new AppIdentifier("MyChartViewingApp", "instance1"),
            ActionTypes.RaiseIntent
        );
        await this.ValidateSchema(action);
    }
}
/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class PositionTests
{
    [Fact]
    public void Position_PropertiesMatchParams()
    {
        Position position = new Position(1, new Instrument(new InstrumentID() { Ticker = "ticker" }), null, "position");
        Assert.Equal(1, position.Holding);
        Assert.Same("ticker", position.Instrument?.ID?.Ticker);
        Assert.Same("position", position.Name);
        Assert.Same(ContextTypes.Position, position.Type);
    }
}
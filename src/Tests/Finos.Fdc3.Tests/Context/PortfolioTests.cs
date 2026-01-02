/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class PortfolioTests
{
    [Fact]
    public void Portfolio_PropertiesMatchParams()
    {
        Portfolio portfolio = new Portfolio(
            new Position[] { new Position(0, new Instrument(new InstrumentID() { Ticker = "ticker" })) },
            null,
            "portfolio");

        Assert.Same("ticker", portfolio?.Positions?.First<Position>()?.Instrument?.ID?.Ticker);
        Assert.Same("portfolio", portfolio?.Name);
        Assert.Same(ContextTypes.Portfolio, portfolio?.Type);
    }
}
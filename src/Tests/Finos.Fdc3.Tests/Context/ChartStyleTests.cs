/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using Xunit;

namespace Finos.Fdc3.Tests.Context;

public class ChartStyleTests
{
    [Fact]
    public void ChartStyle_Constants_HaveCorrectValues()
    {
        Assert.Equal("bar", ChartStyle.Bar);
        Assert.Equal("candle", ChartStyle.Candle);
        Assert.Equal("custom", ChartStyle.Custom);
        Assert.Equal("heatmap", ChartStyle.Heatmap);
        Assert.Equal("histogram", ChartStyle.Histogram);
        Assert.Equal("line", ChartStyle.Line);
        Assert.Equal("mountain", ChartStyle.Mountain);
        Assert.Equal("pie", ChartStyle.Pie);
        Assert.Equal("scatter", ChartStyle.Scatter);
        Assert.Equal("stacked-bar", ChartStyle.StackedBar);
    }
}

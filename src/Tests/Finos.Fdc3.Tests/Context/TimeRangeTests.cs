/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class TimeRangeTests
{
    [Fact]
    public void TimeRange_PropertiesMatchParams()
    {
        string startTime = DateTime.Now.ToString("o");
        string endTime = DateTime.Now.ToString("o");

        TimeRange timeRange = new TimeRange(
            startTime,
            endTime,
            null,
            "timerange");

        Assert.Same(startTime, timeRange.StartTime);
        Assert.Same(endTime, timeRange.EndTime);
        Assert.Same("timerange", timeRange.Name);
        Assert.Same(ContextTypes.TimeRange, timeRange.Type);
    }
}
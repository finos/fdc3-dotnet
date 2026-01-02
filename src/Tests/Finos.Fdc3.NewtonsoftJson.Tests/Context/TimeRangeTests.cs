/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class TimeRangeTests : ContextSchemaTest
{
    public TimeRangeTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/timerange.schema.json")
    {
    }

    [Fact]
    public async Task TimeRange_SerializedJsonMatchesSchema()
    {
        TimeRange timeRange = new TimeRange(
            DateTime.Now.ToString("o"),
            DateTime.Now.ToString("o"),
            null,
            "timerange");

        await this.ValidateSchema(timeRange);
    }
}
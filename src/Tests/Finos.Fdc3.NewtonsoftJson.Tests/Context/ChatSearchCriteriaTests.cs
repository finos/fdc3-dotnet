/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class ChatSearchCriteriaTests : ContextSchemaTest
{
    public ChatSearchCriteriaTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/chatSearchCriteria.schema.json")
    {
    }

    [Fact]
    public async Task ChatSearchCriteria_SerializedJsonMatchesSchema()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "TICKER" });
        ChatSearchCriteria criteria = new ChatSearchCriteria(new object[] { instrument, "searchterm" });
        string json = await this.ValidateSchema(criteria);
    }
}
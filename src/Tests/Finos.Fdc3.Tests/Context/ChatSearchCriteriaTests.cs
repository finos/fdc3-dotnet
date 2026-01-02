/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using System;

namespace Finos.Fdc3.Tests.Context;

public class ChatSearchCriteriaTests
{
    [Fact]
    public void ChatSearchCriteria_PropertiesMatchParams()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "TICKER" });
        ChatSearchCriteria criteria = new ChatSearchCriteria(new object[] { instrument, "searchterm" });

        Assert.Equal(instrument, criteria.Criteria.Cast<object>().First());
        Assert.Same("searchterm", criteria.Criteria.Cast<object>().Last());
        Assert.Same(ContextTypes.ChatSearchCriteria, criteria.Type);
    }
}
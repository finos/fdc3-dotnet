/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class CurrencyTests
{
    [Fact]
    public void Currency_PropertiesMatchParams()
    {
        Currency currency = new Currency(new CurrencyID() { CURRENCY_ISOCODE = "AAA" }, "currency");

        Assert.Same("AAA", currency?.ID?.CURRENCY_ISOCODE);
        Assert.Same("currency", currency?.Name);
        Assert.Same(ContextTypes.Currency, currency?.Type);
    }
}
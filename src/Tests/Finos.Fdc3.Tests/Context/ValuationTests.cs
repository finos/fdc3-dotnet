/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class ValuationTests
{
    [Fact]
    public void Valuation_PropertiesMatchParams()
    {
        string expiryTime = DateTime.Now.ToString("o");
        string valuationTime = DateTime.Now.ToString("o");
        var valuation = new Valuation("AAA", 1, 2, expiryTime, valuationTime, null, "valuation");
        Assert.Same("AAA", valuation.CURRENCY_ISOCODE);
        Assert.Equal(1, valuation.Price);
        Assert.Equal(2, valuation.Value);
        Assert.Same(expiryTime, valuation.ExpiryTime);
        Assert.Same(valuationTime, valuation.ValuationTime);
        Assert.Same("valuation", valuation.Name);
        Assert.Same(ContextTypes.Valuation, valuation.Type);
    }
}
/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class CountryTests
{
    [Fact]
    public void Country_PropertiesMatchParams()
    {
        Country country = new Country(new CountryID() { ISOALPHA2 = "isoalpha2", ISOALPHA3 = "isoalpha3" }, "country");

        Assert.Same("isoalpha2", country?.ID?.ISOALPHA2);
        Assert.Same("country", country?.Name);
        Assert.Same(ContextTypes.Country, country?.Type);
    }
}
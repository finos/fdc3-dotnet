/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Country : Context<CountryID>, IContext
    {
        public Country(CountryID? id = null, string? name = null)
            : base(ContextTypes.Country, id, name)
        {
        }

        object? IContext<object>.ID => base.ID;
    }

    public class CountryID
    {
        public string? ISOALPHA2 { get; set; }
        public string? ISOALPHA3 { get; set; }
    }
}

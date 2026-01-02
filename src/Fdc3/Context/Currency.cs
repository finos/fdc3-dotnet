/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Currency : Context<CurrencyID>, IContext
    {
        public Currency(CurrencyID? id = null, string? name = null)
            : base(ContextTypes.Currency, id, name)
        {
        }

        object? IContext<object>.ID => base.ID;
    }

    public class CurrencyID
    {
        public string? CURRENCY_ISOCODE { get; set; }
    }
}

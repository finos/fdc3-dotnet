/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Valuation : Context, IContext
    {
        public Valuation(string currencyCode, float? price = null, float? value = null, string? expiryTime = null, string? valuationTime = null, object? id = null, string? name = null)
            : base(ContextTypes.Valuation, id, name)
        {
            this.CURRENCY_ISOCODE = currencyCode;
            this.Price = price;
            this.Value = value;
            this.ExpiryTime = expiryTime;
            this.ValuationTime = valuationTime;
        }

        public string CURRENCY_ISOCODE { get; set; }
        public string? ExpiryTime { get; set; }
        public float? Price { get; set; }
        public string? ValuationTime { get; set; }
        public float? Value { get; set; }
    }
}

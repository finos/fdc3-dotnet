/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Instrument : Context<InstrumentID>, IContext
    {
        public Instrument(InstrumentID? id = null, string? name = null)
            : base(ContextTypes.Instrument, id, name)
        {
        }

        public MarketSource? Market { get; set; }

        object? IContext<object>.ID => base.ID;
    }

    public class InstrumentID
    {
        public string? BBG { get; set; }
        public string? CUSIP { get; set; }
        public string? FDS_ID { get; set; }
        public string? FIGI { get; set; }
        public string? ISIN { get; set; }
        public string? PERMID { get; set; }
        public string? RIC { get; set; }
        public string? SEDOL { get; set; }
        public string? Ticker { get; set; }
    }

    public class MarketSource
    {
        public string? BBG { get; set; }
        public string? COUNTRY_ISOALPHA2 { get; set; }
        public string? MIC { get; set; }
        public string? Name { get; set; }
    }
}

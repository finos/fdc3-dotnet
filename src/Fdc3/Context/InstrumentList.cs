/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;
using System.Linq;

namespace Finos.Fdc3.Context
{
    public class InstrumentList : Context
    {
        public InstrumentList(IEnumerable<Instrument>? instruments = null, string? name = null, object? id = null)
            : base(ContextTypes.InstrumentList, id, name)
        {
            this.Instruments = instruments ?? Enumerable.Empty<Instrument>();
        }

        public IEnumerable<Instrument> Instruments { get; }
    }
}

/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;

namespace Finos.Fdc3.Context
{
    public class Chart : Context, IContext
    {
        public Chart(Instrument[] instruments, TimeRange? range = null, IEnumerable<IContext>? otherConfig = null, string? style = null, object? id = null, string? name = null)
            : base(ContextTypes.Chart, id, name)
        {
            this.Instruments = instruments;
            this.Range = range;
            this.OtherConfig = otherConfig;
            this.Style = style;
        }

        public Instrument[] Instruments { get; set; }
        public TimeRange? Range { get; set; }
        public IEnumerable<IContext>? OtherConfig { get; set; }
        public string? Style { get; set; }

        object? IContext<object>.ID => base.ID;
    }
}

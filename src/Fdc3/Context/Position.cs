/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Position : Context
    {
        public Position(double holding, Instrument instrument, object? id = null, string? name = null)
            : base(ContextTypes.Position, id, name)
        {
            this.Holding = holding;
            this.Instrument = instrument;
        }

        public double Holding { get; set; }

        public Instrument Instrument { get; set; }
    }
}

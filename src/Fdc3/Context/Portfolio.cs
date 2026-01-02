/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;

namespace Finos.Fdc3.Context
{
    public class Portfolio : Context
    {
        public Portfolio(IEnumerable<Position> positions, object? id = null, string? name = null)
            : base(ContextTypes.Portfolio, id, name)
        {
            this.Positions = positions;
        }

        public IEnumerable<Position> Positions { get; set; }
    }
}

/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Nothing : Context, IContext
    {
        public Nothing() : base(ContextTypes.Nothing)
        {
        }
    }
}

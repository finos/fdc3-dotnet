/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3
{
    public delegate void ContextHandler<T>(T context, IContextMetadata? metadata = null) where T : IContext;
}

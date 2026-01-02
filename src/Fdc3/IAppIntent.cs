/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;

namespace Finos.Fdc3
{
    /// <summary>
    /// An interface that relates an intent to apps
    /// </summary>
    public interface IAppIntent
    {
        IIntentMetadata Intent { get; }

        IEnumerable<IAppMetadata> Apps { get; }
    }
}

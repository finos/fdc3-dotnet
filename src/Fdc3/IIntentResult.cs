/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3
{
#pragma warning disable CA1040
    /// <summary>
    /// Intents can return results that are either context data objects or a reference to a Channel.
    /// </summary>
    public interface IIntentResult {
        // Marker interface
    }
#pragma warning restore CA1040
}

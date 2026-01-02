/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;

namespace Finos.Fdc3
{
    /// <summary>
    /// Describes an Intent within the platform.
    /// </summary>
    public interface IIntentMetadata
    {
        /// <summary>
        /// The unique name of the intent that can be invoked by the raiseIntent call.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A friendly display name for the intent that should be used to render UI elements.
        /// </summary>
        [Obsolete("Use the intent name for display as display name may vary for each application  as it is defined in the app's AppD record.")]
        string? DisplayName { get; }
    }
}

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
    public class IntentMetadata : IIntentMetadata
    {
        public IntentMetadata(string name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }


        [Obsolete("Use the intent name for display as display name may vary for each application as it is defined in the app's AppD record.")]
        public IntentMetadata(string name, string? displayName = null) : this(name)
        {
            this.DisplayName = displayName;
        }

        /// <summary>
        /// The unique name of the intent that can be invoked by the raiseIntent call.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// A friendly display name for the intent that should be used to render UI elements.
        /// </summary>
        [Obsolete("Use the intent name for display as display name may vary for each application as it is defined in the app's AppD record.")]
        public string? DisplayName { get; }
    }
}

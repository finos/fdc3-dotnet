/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using System.Threading.Tasks;

namespace Finos.Fdc3
{
    /// <summary>
    /// Standard format for data returned upon resolving an intent.
    /// </summary>
    public abstract class IntentResolution : IIntentResolution
    {
        public IntentResolution(IAppMetadata source, string intent, string? version = null)
        {
            this.Source = source ?? throw new ArgumentNullException(nameof(source));
            this.Intent = intent ?? throw new ArgumentNullException(nameof(version));
            this.Version = version;
        }

        /// <summary>
        /// The application that resolved the intent.
        /// </summary>
        public IAppIdentifier Source { get; }

        /// <summary>
        /// The intent that was raised.
        /// </summary>
        public string Intent { get; }

        /// <summary>
        /// The version number of the Intents schema being used.
        /// </summary>
        public string? Version { get; }

        public abstract Task<IIntentResult?> GetResult();
    }
}

/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Threading.Tasks;

namespace Finos.Fdc3
{
    /// <summary>
    /// Standard format for data returned upon resolving an intent.
    /// </summary>
    public interface IIntentResolution
    {
        /// <summary>
        /// The application that resolved the intent.
        /// </summary>
        IAppIdentifier Source { get; }

        /// <summary>
        /// The intent that was raised.
        /// </summary>
        string Intent { get; }

        /// <summary>
        /// The version number of the Intents schema being used.
        /// </summary>
        string? Version { get; }

        Task<IIntentResult?> GetResult();
    }
}

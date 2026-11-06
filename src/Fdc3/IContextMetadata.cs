/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;

namespace Finos.Fdc3
{
    /// <summary>
    /// Metadata relating to a context or intent received through the
    /// AddContextListener and AddIntentListener functions.
    ///
    /// Includes delivery information provided by the Desktop Agent (source,
    /// timestamp, traceId) and optional metadata forwarded from the
    /// originating app (signature, antiReplay, custom).
    ///
    /// Introduced in FDC3 2.0 and enhanced in FDC3 3.0 with timestamp,
    /// traceId, and security metadata support.
    /// </summary>
    public interface IContextMetadata : IAppProvidableContextMetadata
    {
        /// <summary>
        /// The timestamp when the context was broadcast or the intent was raised.
        /// Set by the Desktop Agent to the current time.
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// The identifier of the app instance that originated the context or intent.
        /// This is always non-null in delivered ContextMetadata.
        /// </summary>
        IAppIdentifier Source { get; }

        /// <summary>
        /// A unique identifier for tracing the flow of context or intent messages
        /// across applications. Always present in delivered ContextMetadata:
        /// the Desktop Agent forwards a traceId provided by the originating app,
        /// or generates one (UUID) when the app did not supply it.
        /// </summary>
        new string TraceId { get; }
    }
}

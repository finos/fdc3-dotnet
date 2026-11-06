/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using System.Collections.Generic;

namespace Finos.Fdc3
{
    /// <summary>
    /// Concrete implementation of IContextMetadata for FDC3 3.0.
    ///
    /// Metadata relating to a context or intent received through the AddContextListener and AddIntentListener functions.
    /// </summary>
    public class ContextMetadata : IContextMetadata
    {
        public ContextMetadata(IAppIdentifier source, DateTime timestamp, string traceId,
            IDetachedSignature? signature = null, IAntiReplayClaims? antiReplay = null,
            Dictionary<string, object>? custom = null)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Timestamp = timestamp;
            TraceId = traceId ?? throw new ArgumentNullException(nameof(traceId));
            Signature = signature;
            AntiReplay = antiReplay;
            Custom = custom;
        }

        /// <summary>
        /// The timestamp when the context was broadcast or the intent was raised.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// The identifier of the app instance that originated the context or intent.
        /// </summary>
        public IAppIdentifier Source { get; }

        /// <summary>
        /// A unique identifier for tracing the flow of context or intent messages across applications.
        /// Always present in delivered ContextMetadata.
        /// </summary>
        public string TraceId { get; }

        /// <summary>
        /// Optional app-provided traceId from AppProvidableContextMetadata.
        /// </summary>
        string? IAppProvidableContextMetadata.TraceId => TraceId;

        /// <summary>
        /// A Detached JSON Web Signature (JWS) proving the authenticity and integrity of the context.
        /// </summary>
        public IDetachedSignature? Signature { get; }

        /// <summary>
        /// Anti-replay claims used with Signature to prevent message replay.
        /// </summary>
        public IAntiReplayClaims? AntiReplay { get; }

        /// <summary>
        /// Custom metadata fields.
        /// </summary>
        public Dictionary<string, object>? Custom { get; }
    }
}

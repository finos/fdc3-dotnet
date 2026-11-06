/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;

namespace Finos.Fdc3
{
    /// <summary>
    /// Metadata that may be provided by an App when calling broadcast, open or
    /// raiseIntent functions, to be passed on to receiving apps.
    ///
    /// The Desktop Agent MUST forward any provided fields to the receiving app's
    /// handler via ContextMetadata, while always overriding source and timestamp
    /// with its own values.
    /// </summary>
    public interface IAppProvidableContextMetadata
    {
        /// <summary>
        /// An optional, app-provided unique identifier for tracing the flow of
        /// context or intent messages across applications. The Desktop Agent MUST
        /// forward a traceId provided here unchanged, and MUST generate one when
        /// the app does not supply it, so that the delivered ContextMetadata
        /// always carries a traceId.
        /// </summary>
        string? TraceId { get; }

        /// <summary>
        /// A Detached JSON Web Signature (JWS) proving the authenticity and
        /// integrity of the context. MUST be accompanied by AntiReplay.
        /// See Security &amp; Identity documentation for details.
        /// </summary>
        IDetachedSignature? Signature { get; }

        /// <summary>
        /// Anti-replay claims used alongside Signature to prevent a signed
        /// message from being replayed. MUST be present when Signature is set.
        /// See Security &amp; Identity documentation for details.
        /// </summary>
        IAntiReplayClaims? AntiReplay { get; }

        /// <summary>
        /// Custom metadata. Allows use of metadata fields that have yet to be
        /// standardized.
        /// </summary>
        Dictionary<string, object>? Custom { get; }
    }
}

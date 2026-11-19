/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3
{
    /// <summary>
    /// Anti-replay claims that MUST accompany a signature to prevent a captured
    /// signed message from being resubmitted by an attacker.
    ///
    /// See the Security &amp; Identity documentation for details.
    /// </summary>
    public interface IAntiReplayClaims
    {
        /// <summary>
        /// Issued-at time as a Unix timestamp (seconds since epoch).
        /// </summary>
        long Iat { get; }

        /// <summary>
        /// Expiration time as a Unix timestamp (seconds since epoch).
        /// </summary>
        long Exp { get; }

        /// <summary>
        /// Unique identifier for this signed context instance (UUID).
        /// </summary>
        string Jti { get; }
    }
}

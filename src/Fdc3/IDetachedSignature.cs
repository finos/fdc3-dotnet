/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3
{
    /// <summary>
    /// A Detached JSON Web Signature (JWS) proving the authenticity and integrity
    /// of a signed context object. The signature is computed over the canonicalized
    /// JSON representation of { context, antiReplay } using the signing app's
    /// private key. Verification uses the public key retrieved from the JWKS URL
    /// embedded in the protected header.
    ///
    /// See the Security &amp; Identity documentation for details.
    /// </summary>
    public interface IDetachedSignature
    {
        /// <summary>
        /// The BASE64URL-encoded JWS protected header. When decoded, contains
        /// fields including: alg (signature algorithm), jku (JWKS URL for
        /// key verification), and kid (key identifier).
        /// </summary>
        string Protected { get; }

        /// <summary>
        /// The BASE64URL-encoded digital signature computed over the protected
        /// header and the canonicalized context payload (detached).
        /// </summary>
        string Signature { get; }
    }
}

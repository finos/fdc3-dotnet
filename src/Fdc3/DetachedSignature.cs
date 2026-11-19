/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3
{
    /// <summary>
    /// Concrete implementation of IDetachedSignature.
    /// </summary>
    public class DetachedSignature : IDetachedSignature
    {
        public string Protected { get; }
        public string Signature { get; }

        public DetachedSignature(string @protected, string signature)
        {
            Protected = @protected ?? throw new System.ArgumentNullException(nameof(@protected));
            Signature = signature ?? throw new System.ArgumentNullException(nameof(signature));
        }
    }
}

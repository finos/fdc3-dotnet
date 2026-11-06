/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3
{
    /// <summary>
    /// Concrete implementation of IAntiReplayClaims.
    /// </summary>
    public class AntiReplayClaims : IAntiReplayClaims
    {
        public long Iat { get; }
        public long Exp { get; }
        public string Jti { get; }

        public AntiReplayClaims(long iat, long exp, string jti)
        {
            Iat = iat;
            Exp = exp;
            Jti = jti ?? throw new System.ArgumentNullException(nameof(jti));
        }
    }
}

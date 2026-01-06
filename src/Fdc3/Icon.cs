/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;

namespace Finos.Fdc3
{
    public class Icon : IIcon
    {
        public Icon(string src, string? size = null, string? type = null)
        {
            this.Src = src ?? throw new ArgumentNullException(nameof(src)); ;
            this.Size = size;
            this.Type = type;
        }

        /// <summary>
        /// The icon url
        /// </summary>
        public string Src { get; }

        /// <summary>
        /// The icon dimensions, formatted as '{height}x{width}'
        /// </summary>
        public string? Size { get; }
        
        /// <summary>
        /// Icon media type. If not present, the Desktop Agent may use the src file extension.
        /// </summary>
        public string? Type { get; }
    }
}

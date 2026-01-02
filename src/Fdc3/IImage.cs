/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3
{
    public interface IImage
    {
        /// <summary>
        /// The icon url
        /// </summary>
        string Src { get; }
        
        /// <summary>
        /// The icon dimensions, formatted as '{height}x{width}'
        /// </summary>
        string? Size { get; }
        
        /// <summary>
        /// Icon media type.  If not present, the Desktop Agent may use the src file extension.
        /// </summary>
        string? Type { get; }


        /// <summary>
        /// Caption for the image
        /// </summary>
        string? Label { get; }
    }
}

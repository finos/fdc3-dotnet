/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;

namespace Finos.Fdc3
{
    /// <summary>
    /// App definition as provided by the application directory.
    /// </summary>
    public interface IAppMetadata : IAppIdentifier
    {
        /// <summary>
        /// The unique app name that can be used with the open and raiseIntent calls.
        /// </summary>
        string? Name { get; }

        /// <summary>
        /// The Version of the application.
        /// </summary>
        string? Version { get; }

        /// <summary>
        /// A more user-friendly application title that can be used to render UI elements.
        /// </summary>
        string? Title { get; }

        /// <summary>
        /// A tooltip for the application that can be used to render UI elements.
        /// </summary>
        string? Tooltip { get; }

        /// <summary>
        /// A longer, multi-paragraph description for the application that could include markup.
        /// </summary>
        string? Description { get; }

        /// <summary>
        /// A list of icon URLs for the application that can be used to render UI elements.
        /// </summary>
        IEnumerable<IIcon> Icons { get; }

        /// <summary>
        /// A list of image URLs for the application that can be used to render UI elements.
        /// </summary>
        IEnumerable<IImage> Screenshots { get; }

        /// <summary>
        /// The type of output returned for any intent specified during resolution. May express a particular context type,
        /// channel, or channel with specified type
        /// </summary>
        string? ResultType { get; }
    }
}

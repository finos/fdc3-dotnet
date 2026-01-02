/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Describes the application's use of context types on User Channels.
    /// This metadata is not currently used by the desktop agent, but is provided
    /// to help find apps that will interoperate with this app and to document API
    /// interactions for use by other app developers.
    /// </summary>
    public class UserChannels
    {
        /// <summary>
        /// Context type names that are broadcast by the application.
        /// </summary>
        public IEnumerable<string>? Broadcasts { get; set; }

        /// <summary>
        /// Context type names that the application listens for.
        /// </summary>
        public IEnumerable<string>? ListensFor { get; set; }
    }
}

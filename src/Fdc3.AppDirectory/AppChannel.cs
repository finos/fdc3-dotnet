/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using System.Collections.Generic;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Describes the application's use of App Channels.
    /// This metadata is not currently used by the desktop agent, but is provided
    /// to help find apps that will interoperate with this app and to document API
    /// interactions for use by other app developers.
    /// </summary>
    public class AppChannel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppChannel"/> class.
        /// </summary>
        /// <param name="id">The ID of the App Channel</param>
        /// <exception cref="ArgumentNullException">Exception if ID is null</exception>
        public AppChannel(string id)
        {
            ID = id ?? throw new ArgumentNullException(nameof(id));
        }
        /// <summary>
        /// The ID of the App Channel.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// A description of how the channel is used.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Context type names that are broadcast by the application on the channel.
        /// </summary>
        public IEnumerable<string>? Broadcasts { get; set; }

        /// <summary>
        /// Context type names that the application listens for on the channel.
        /// </summary>
        public IEnumerable<string>? ListensFor { get; set; }
    }
}

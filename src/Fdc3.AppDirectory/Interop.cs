/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Metadata that describes how the application uses FDC3 APIs. This metadata serves multiple purposes:
    /// <list type="bullet">
    /// <item>
    /// It supports intent resolution by a desktop agent, by declaring what intents an app listens for.
    /// </item>
    /// <item>
    /// It may be used, for example in an app catalog UI, to find apps that 'interoperate with' other apps.
    /// </item>
    /// <item>
    /// It provides a standard location to document how the app interacts with user channels, app channels,
    /// and intents, for use by other app developers and desktop assemblers.
    /// </item>
    /// </list>
    /// </summary>
    public class Interop
    {
        /// <summary>
        /// <see cref="Intens"/>
        /// </summary>
        public Intents? Intents { get; set; }

        /// <summary>
        /// <see cref="UserChannels"/>
        /// </summary>
        public UserChannels? UserChannels { get; set; }

        /// <summary>
        /// List of <see cref="AppChannel"/>
        /// </summary>
        public IEnumerable<AppChannel>? AppChannels { get; set; }
    }
}

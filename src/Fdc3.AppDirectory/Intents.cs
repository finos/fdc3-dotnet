/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Describes the app's interactions with intents.
    /// </summary>
    public class Intents
    {
        /// <summary>
        /// A mapping of Intents names that an app listens for via fdc3.addIntentListener() to their configuration.
        /// Used to support intent resolution by desktop agents.Replaces the intents element used in appD records 
        /// prior to FDC3 2.0.
        /// </summary>
        public Dictionary<string, IntentMetadata>? ListensFor { get; set; }

        /// <summary>
        /// A mapping of Intent names that an app raises (via fdc3.raiseIntent)
        /// to an array of context type names that it may be raised with.
        /// Use the intent name "any" to represent use of the
        /// fdc3.raiseIntentForContext and fdc3.findIntentForContext functions,
        /// which allow the user to select from intents available for a specified context type.
        /// This metadata is not currently used by the desktop agent, but is provided to
        /// help find apps that will interoperate with this app and to document API
        /// interactions for use by other app developers.
        /// </summary>
        public Dictionary<string, IEnumerable<string>>? Raises { get; set; }
    }
}

/*
 * Morgan Stanley makes this available to you under the Apache License,
 * Version 2.0 (the "License"). You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0.
 *
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Unless required by applicable law or agreed
 * to in writing, software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 */

using System.Collections.Generic;

namespace MorganStanley.Fdc3.AppDirectory
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

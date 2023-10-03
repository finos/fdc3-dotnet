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

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

using System;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// App virtualized via Citrix.
    /// </summary>
    public class CitrixAppDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CitrixAppDetails"/> class.
        /// </summary>
        /// <param name="alias">The alias</param>
        /// <param name="arguments">The arguments</param>
        /// <exception cref="ArgumentNullException">Exception if the alias is null</exception>
        public CitrixAppDetails(string alias, string? arguments)
        {
            Alias = alias ?? throw new ArgumentNullException(nameof(alias));
            Arguments = arguments;
        }

        /// <summary>
        /// The Citrix alias / name of the virtual app (passed to the Citrix SelfService qlaunch parameter).
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Arguments that must be passed on the command line to launch the app in the expected configuration.
        /// </summary>
        public string? Arguments { get; set; }
    }
}

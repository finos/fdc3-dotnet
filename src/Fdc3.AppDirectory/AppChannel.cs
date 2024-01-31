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
        /// <param name="name">The name</param>
        /// <exception cref="ArgumentNullException">Exception if name is null</exception>
        public AppChannel(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        /// <summary>
        /// The name of the App Channel.
        /// </summary>
        public string Name { get; set; }

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

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

namespace MorganStanley.Fdc3
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
        IEnumerable<string> Icons { get; }

        /// <summary>
        /// A list of image URLs for the application that can be used to render UI elements.
        /// </summary>
        IEnumerable<string> Images { get; }

        /// <summary>
        /// The type of output returned for any intent specified during resolution. May express a particular context type,
        /// channel, or channel with specified type
        /// </summary>
        string? ResultType { get; }
    }
}

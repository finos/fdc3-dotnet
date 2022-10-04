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
using System.Linq;

namespace MorganStanley.Fdc3
{
    /// <summary>
    /// App definition as provided by the application directory.
    /// </summary>
    
    public class AppMetadata : IAppMetadata
    {
        public AppMetadata(string name, string? appId = null, string? version = null, string? title = null,
            string? tooltip = null, string? description = null, IEnumerable<string>? icons = null, IEnumerable<string>? images = null)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.AppId = appId;
            this.Version = version;
            this.Title = title;
            this.Tooltip = tooltip;
            this.Description = description;
            this.Icons = icons ?? Enumerable.Empty<string>();
            this.Images = images ?? Enumerable.Empty<string>();
        }

        public static IAppMetadata FromName(string name)
        {
            return new AppMetadata(name);
        }

        /// <summary>
        /// The unique app name that can be used with the open and raiseIntent calls.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The unique application identifier located within a specific application directory instance. An example of an appId might be 'app@sub.root'.
        /// </summary>
        public string? AppId { get; }

        /// <summary>
        /// The Version of the application.
        /// </summary>
        public string? Version { get; }

        /// <summary>
        /// A more user-friendly application title that can be used to render UI elements.
        /// </summary>
        public string? Title { get; }

        /// <summary>
        /// A tooltip for the application that can be used to render UI elements.
        /// </summary>
        public string? Tooltip { get; }

        /// <summary>
        /// A longer, multi-paragraph description for the application that could include markup.
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// A list of icon URLs for the application that can be used to render UI elements.
        /// </summary>
        public IEnumerable<string> Icons { get; }

        /// <summary>
        /// A list of image URLs for the application that can be used to render UI elements.
        /// </summary>
        public IEnumerable<string> Images { get; }
    }
}

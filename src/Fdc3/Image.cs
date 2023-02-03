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

namespace MorganStanley.Fdc3
{
    public class Image : IImage
    {
        public Image(string src, string? size = null, string? type = null, string? label = null)
        {
            this.Src = src ?? throw new ArgumentNullException(nameof(src)); ;
            this.Size = size;
            this.Type = type;
            this.Label = label;
        }

        /// <summary>
        /// The icon url
        /// </summary>
        public string Src { get; }

        /// <summary>
        /// The icon dimensions, formatted as '{height}x{width}'
        /// </summary>
        public string? Size { get; }

        /// <summary>
        /// Icon media type.  If not present, the Desktop Agent may use the src file extension.
        /// </summary>
        public string? Type { get; }

        /// <summary>
        /// Caption for the image
        /// </summary>
        public string? Label { get; }
    }
}

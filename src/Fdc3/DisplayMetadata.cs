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

namespace MorganStanley.Fdc3
{
    /// <summary>
    /// A system channel will be global enough to have a presence across many apps.  This gives us some hints to render
    /// them in a standard way. It is assumed it may have other properties too, but if it has these, this is their meaning.
    /// </summary>
    public class DisplayMetadata : IDisplayMetadata
    {
        public DisplayMetadata(string? name = null, string? color = null, string? glyph = null)
        {
            this.Name = name;
            this.Color = color;
            this.Glyph = glyph;
        }

        /// <summary>
        /// A user-readable name for this channel, e.g: Red.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// The color that should be associated within this channel when displaying this channein in a UI, e.g: '0xFF0000'.
        /// </summary>
        public string? Color { get; }

        /// <summary>
        /// A URL of an image that can be used to display this channel.
        /// </summary>
        public string? Glyph { get; }
    }
}

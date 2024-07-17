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

namespace Finos.Fdc3
{
    /// <summary>
    /// Describes an Intent within the platform.
    /// </summary>
    public class IntentMetadata : IIntentMetadata
    {
        public IntentMetadata(string name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }


        [Obsolete]
        public IntentMetadata(string name, string? displayName = null) : this(name)
        {
            this.DisplayName = displayName;
        }

        /// <summary>
        /// The unique name of the intent that can be invoked by the raiseIntent call.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// A friendly display name for the intent that should be used to render UI elements.
        /// </summary>
        [Obsolete("Use the intent name for display as display name may vary for each application  as it is defined in the app's AppD record.")]
        public string? DisplayName { get; }
    }
}

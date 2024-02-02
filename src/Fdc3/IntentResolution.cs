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
using System.Threading.Tasks;

namespace Finos.Fdc3
{
    /// <summary>
    /// Standard format for data returned upon resolving an intent.
    /// </summary>
    public abstract class IntentResolution : IIntentResolution
    {
        public IntentResolution(IAppMetadata source, string intent, string? version = null)
        {
            this.Source = source ?? throw new ArgumentNullException(nameof(source));
            this.Intent = intent ?? throw new ArgumentNullException(nameof(version));
            this.Version = version;
        }

        /// <summary>
        /// The application that resolved the intent.
        /// </summary>
        public IAppIdentifier Source { get; }

        /// <summary>
        /// The intent that was raised.
        /// </summary>
        public string Intent { get; }

        /// <summary>
        /// The version number of the Intents schema being used.
        /// </summary>
        public string? Version { get; }

        public abstract Task<IIntentResult?> GetResult();
    }
}

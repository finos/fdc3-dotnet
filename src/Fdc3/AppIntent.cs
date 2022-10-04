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

namespace MorganStanley.Fdc3
{
    public class AppIntent : IAppIntent
    {
        /// <summary>
        /// An interface that relates an intent to apps
        /// </summary>
        public AppIntent(IIntentMetadata intent, IEnumerable<IAppMetadata> apps)
        {
            this.Intent = intent ?? throw new ArgumentNullException(nameof(intent));
            this.Apps = apps ?? throw new ArgumentNullException(nameof(apps));
        }

        public IIntentMetadata Intent { get; }

        public IEnumerable<IAppMetadata> Apps { get; }
    }
}

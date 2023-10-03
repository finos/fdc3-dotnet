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

namespace MorganStanley.Fdc3.AppDirectory
{
    /// <summary>
    /// Implementation of <see cref="IIntentMetadata"/>
    /// </summary>
    public class IntentMetadata : IIntentMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntentMetadata"/> class.
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="displayName">The displayName</param>
        /// <param name="contexts">The contexts</param>
        /// <exception cref="ArgumentNullException">Exception contexts is null</exception>
        public IntentMetadata(string name, string displayName, IEnumerable<string> contexts) 
        {
            Name = name;
            DisplayName = displayName;
            Contexts = contexts ?? throw new ArgumentNullException(nameof(contexts));
        }

        /// <summary>
        /// Definition of an intent that an app listens for
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An optional display name for the intent that may be used in UI instead of the name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A comma separated list of the types of contexts the intent offered by the application
        /// can process, where the first part of the context type is the namespace e.g."fdc3.contact,
        /// org.symphony.contact"
        /// </summary>
        public IEnumerable<string> Contexts { get; set; }

        /// <summary>
        /// An optional type for output returned by the application, if any, when resolving this intent.
        /// May indicate a context type by type name (e.g. "fdc3.instrument"), a channel (e.g. "channel")
        /// or a combination that indicates a channel that returns a particular
        /// context type (e.g. "channel<fdc3.instrument>").
        /// </summary>
        public string? ResultType { get; set; }

        /// <summary>
        /// Custom configuration for the intent that may be required for a particular desktop agent.
        /// </summary>
        public object? CustomConfig { get; set; }
    }
}

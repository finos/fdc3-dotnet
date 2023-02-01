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
    ///  Metadata relating to a context or intent and context received through the `AddContextListener` and `AddIntentListener` functions.
    ///  
    /// Introduced in FDC3 2.0 and may be refined by further changes outside the normal FDC3 versioning policy.
    /// </summary>
    public interface IContextMetadata
    {
        /// <summary>
        /// Identifier for the app instance that sent the context and/or intent.
        /// </summary>
        AppIdentifier? Source { get; }
    }
}

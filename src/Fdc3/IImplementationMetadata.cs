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
    /// Metadata relating to the FDC3 Desktop Agent implementation and its provider.
    /// </summary>
    public interface IImplementationMetadata
    {
        /// <summary>
        ///  The version number of the FDC3 specification that the implementation provides.
        ///  The string must be a numeric semver version, e.g. 1.2 or 1.2.1.
        /// </summary>
        string Fdc3Version { get; }

        /// <summary>
        /// The name of the provider of the FDC3 Desktop Agent Implementation (e.g. Finsemble, Glue42, OpenFin etc.).
        /// </summary>
        string Provider { get; }

        /// <summary>
        /// The version of the provider of the FDC3 Desktop Agent Implementation (e.g. 5.3.0).
        /// </summary>
        string ProviderVersion { get; }

        /// <summary>
        /// Metadata indicating whether the Desktop Agent implements optional features of the Desktop Agent API.
        /// </summary>
        OptionalDesktopAgentFeatures OptionalFeatures { get; }

        /// <summary>
        /// The calling application instance's own metadata according to the Desktop Agent
        /// </summary>
        IAppMetadata AppMetadata { get; }
    }

    public class OptionalDesktopAgentFeatures
    {
        /// <summary>
        /// Used to indicate whether the exposure of 'originating app metadata' for context and intent
        /// messages is supported by the Desktop Agent.
        /// </summary>
        public bool OriginatingAppMetadata { get; set; }
        
        /// <summary>
        /// Used to indicate whether the optional 'JoinUserChannel', 'GetCurrentChannel', and 'LeaveCurrentChannel'
        /// are implemented by the Desktop Agent.
        /// </summary>
        public bool UserChannelMembershipAPIs { get; set; }
    }
}

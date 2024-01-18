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

namespace Finos.Fdc3
{
    /// <summary>
    /// Identifies an application, or instance of an application, and is used to target FDC3 API calls,
    /// such as `fdc3.open` or `fdc3.raiseIntent` at specific applications or application instances.
    /// 
    /// Will always include at least an `AppId` property, which uniquely identifies a specific app.
    /// 
    /// If the `InstanceId` property is set, then the `AppIdentifier` object represents a specific instance
    /// of the application that may be addressed using that Id.
    /// </summary>
    public interface IAppIdentifier
    {
        /// <summary>
        /// The unique application identifier located within a specific application directory instance. An example of an appId might be 'app@sub.root'.
        /// </summary>
        string AppId { get; }

        /// <summary>
        /// An optional instance identifier, indicating that this object represents a specific instance of the application described.
        /// </summary>
        string? InstanceId { get; }
    }
}

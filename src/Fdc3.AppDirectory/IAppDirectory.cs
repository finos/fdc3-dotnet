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

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Interface definition for the AppDirectory.
    /// </summary>
    public interface IAppDirectory
    {
        /// <summary>
        /// Returns a list of all applications from the AppDirectory.
        /// </summary>
        /// <returns>List of applications.</returns>
        Task<IEnumerable<Fdc3App>> GetApps();

        /// <summary>
        /// Returns an application by appId from the AppDirectory.
        /// </summary>
        /// <param name="appId">Application identifier</param>
        /// <returns>The application</returns>
        /// <exception cref="AppNotFoundException">The app was not found</exception>
        Task<Fdc3App> GetApp(string appId);
    }
}

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

namespace MorganStanley.Fdc3.AppDirectory
{
    /// <summary>
    /// Native application pre-installed on a device and launch via a filesystem path.
    /// </summary>
    public class NativeAppDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NativeAppDetails"/> class.
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="arguments">The arguments</param>
        /// <exception cref="ArgumentNullException">Exception if the path is null</exception>
        public NativeAppDetails(string path, string? arguments)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Arguments = arguments;
        }
        /// <summary>
        /// The path on disk from which the application is launched.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Arguments that must be passed on the command line to launch the app in the expected configuration.
        /// </summary>
        public string? Arguments { get; set; }
    }
}

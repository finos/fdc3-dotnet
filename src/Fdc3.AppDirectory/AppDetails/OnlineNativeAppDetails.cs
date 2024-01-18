﻿/*
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

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Native app that have an online launcher, e.g. online ClickOnce app deployments.
    /// </summary>
    public class OnlineNativeAppDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineNativeAppDetails"/> class.
        /// </summary>
        /// <param name="url">The url</param>
        /// <exception cref="ArgumentNullException">Exception if the url is null</exception>
        public OnlineNativeAppDetails(string url)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }
        /// <summary>
        /// Application URL.
        /// </summary>
        public string Url { get; set; }
    }
}
